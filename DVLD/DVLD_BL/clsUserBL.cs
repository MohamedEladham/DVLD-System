using DVLD_BL.Validations;
using DVLD_DAL;
using DVLD_Models.Permissions;
using DVLD_Models.User;
using DVLD_Shared;
using DVLD_Shared.Global_Classes;
using DVLD_Shared.Operations_Result;
using DVLD_Shared.Validation_Messages;
using System;
using System.Collections.Generic;
using static DVLD_Shared.Operations_Result.clsOperationResult;

namespace DVLD_BL
{
    public class clsUserBL
    {

        // >> Fore Login Screen
        public static (clsOperationResult, clsUser) GetUserByUserNameAndPassword(string userName, string password)
        {
            clsValidationResult validateUserName = clsUserValidations.IsValidUserName(userName, 2, 50);

            if (!validateUserName.IsValid)
                return (new clsOperationResult
                {
                    Status = enOperationStatus.Failed,
                    Message = $"> User Name {validateUserName.Message}. ",
                    PropertyName = nameof(clsUser.UserName)

                }, null);


            clsValidationResult validatePassword = clsUserValidations.ValidatePassword(password, 2, 500);

            if (!validatePassword.IsValid)
                return (new clsOperationResult
                {
                    Status = enOperationStatus.Failed,
                    Message = $"> Password {validatePassword.Message}. ",
                    PropertyName = nameof(clsUser.Password)

                }, null);


            try
            {
                string computeHashPassword = clsHashHelper.ComputeHash(password);

                clsUser user = clsUserDAL.GetUserByUserNameAndPassword(userName, computeHashPassword);

                if (user != null)
                    return (new clsOperationResult { Status = enOperationStatus.Success }, user);
                else
                    return (new clsOperationResult
                    {
                        Status = enOperationStatus.Failed,
                        Message = clsUserValidationMessages.UserNotFoundMessage,
                        PropertyName = string.Empty
                    }, null);
            }
            catch (Exception)
            {
                return (new clsOperationResult
                {
                    Status = enOperationStatus.Exception,
                    Message = clsGeneralValidationMessages.DatabaseOperationExceptionMessage,
                    PropertyName = string.Empty
                }, null);
            }

        }

        // >> Fore Login Screen
        public static (clsOperationResult, List<clsPermission>) GetUserPermissions(int userID)
        {
            if (userID <= 0)
                return (new clsOperationResult
                {
                    Status = enOperationStatus.Failed,
                    Message = clsUserValidationMessages.InvalidUserIDMessage
                }, null);

            try
            {
                return (new clsOperationResult { Status = enOperationStatus.Success }, clsUserDAL.GetUserPermissions(userID));
            }
            catch (Exception)
            {
                return (new clsOperationResult
                {
                    Status = enOperationStatus.Exception,
                    Message = clsGeneralValidationMessages.DatabaseOperationExceptionMessage
                }, null);
            }
        }



        // >>
        public static clsValidationResult IsCurrentPasswordValid(string currentPassword, int userID)
        {
            if(string.IsNullOrWhiteSpace(currentPassword))
                return new clsValidationResult { IsValid = false, Message = clsUserValidationMessages.CurrentPasswordRequiredMessage };

            if(userID <= 0)
                return new clsValidationResult { IsValid = false, Message = clsUserValidationMessages.UserIDMustBeGreaterThanZeroMessage };

            try
            {
                string computeHashPassword = clsHashHelper.ComputeHash(currentPassword);

                bool isValidPassword = clsUserDAL.IsCurrentPasswordValid(computeHashPassword, userID);

                if(isValidPassword)
                    return new clsValidationResult { IsValid = true, Message = clsUserValidationMessages.CurrentPasswordVerified };
                else
                    return new clsValidationResult { IsValid = false, Message = clsUserValidationMessages.InvalidCurrentPassword };
            }
            catch (Exception)
            {
                return new clsValidationResult { IsValid = false, Message = clsGeneralValidationMessages.DatabaseOperationExceptionMessage };
            }
        }

        public static (clsOperationResult, bool) CheckPersonIsUser(int personID)
        {
            if (personID <= 0)
                return (new clsOperationResult
                {
                    Status = enOperationStatus.Failed,
                    Message = clsPersonValidationMessages.PersonIDMustBeGreaterThanZeroMessage
                }, false);

            try
            {
                return (new clsOperationResult { Status = enOperationStatus.Success }, clsUserDAL.CheckPersonIsUser(personID));
            }
            catch(Exception)
            {
                return (new clsOperationResult 
                {
                    Status = enOperationStatus.Exception,
                    Message = clsGeneralValidationMessages.DatabaseOperationExceptionMessage
                }, false);
            }
        }

        public static clsValidationResult AuthenticateUser(string userName, string password)
        {
            try
            {
                string computeHashPassword = clsHashHelper.ComputeHash(password);

                bool isAuthenticated = clsUserDAL.AuthenticateUser(userName, computeHashPassword);

                if (isAuthenticated)
                    return new clsValidationResult { IsValid = true, Message = clsUserValidationMessages.LoginSuccessfulMessage };
                else
                    return new clsValidationResult { IsValid = false, Message = clsUserValidationMessages.InvalidUserNameOrPasswordMessage };
            }
            catch (Exception)
            {
                return new clsValidationResult { IsValid = false, Message = clsGeneralValidationMessages.DatabaseOperationExceptionMessage };
            }
        }


        // >>
        public static (clsOperationResult, clsUser) GetUserByUserID(int userID)
        {
            if (!clsCurrentUser.HasPermission(enPermissions.ViewUsers))
                return (new clsOperationResult
                {
                    Status = enOperationStatus.Failed,
                    Message = clsUserValidationMessages.PermissionDeniedMessage
                }, null);


            if (userID <= 0)
                return (new clsOperationResult
                {
                    Status = enOperationStatus.Failed,
                    Message = clsUserValidationMessages.InvalidUserIDMessage
                }, null);

            try
            {
                clsUser user = clsUserDAL.GetUserByID(userID);

                if (user != null)
                    return (new clsOperationResult { Status = enOperationStatus.Success }, user);
                else
                    return (new clsOperationResult
                    {
                        Status = enOperationStatus.Failed,
                        Message = clsUserValidationMessages.UserNotFoundMessage
                    }, null);
            }
            catch (Exception)
            {
                return (new clsOperationResult
                {
                    Status = enOperationStatus.Exception,
                    Message = clsGeneralValidationMessages.DatabaseOperationExceptionMessage
                }, null);
            }

        }
        
        
        // >>
        public static (clsOperationResult, List<clsUserInfoGridViewDto>) GetActiveUsersForGridView()
        {
            if (!clsCurrentUser.HasPermission(enPermissions.ViewUsers))
                return (new clsOperationResult
                {
                    Status = enOperationStatus.Failed,
                    Message = clsPermissionsValidationMessages.PermissionDeniedMessage
                }, null);

            try
            {
                List<clsUserInfoGridViewDto> activeUsersInfos = clsUserDAL.GetActiveUsersForGridView();

                activeUsersInfos = (activeUsersInfos != null && activeUsersInfos.Count > 0) ? activeUsersInfos : null;

                return (new clsOperationResult { Status = enOperationStatus.Success }, activeUsersInfos);
            }
            catch (Exception)
            {
                return (new clsOperationResult
                {
                    Status = enOperationStatus.Exception,
                    Message = clsGeneralValidationMessages.DatabaseOperationExceptionMessage
                }, null);
            }
        }


        // >>
        public static (clsOperationResult, List<clsUserInfoGridViewDto>) GetInActiveUsersForGridView()
        {
            if (!clsCurrentUser.HasPermission(enPermissions.ViewUsers))
                return (new clsOperationResult
                {
                    Status = enOperationStatus.Failed,
                    Message = clsPermissionsValidationMessages.PermissionDeniedMessage
                }, null);

            try
            {
                List<clsUserInfoGridViewDto> inActiveUsersInfos = clsUserDAL.GetInActiveUsersForGridView();

                inActiveUsersInfos = (inActiveUsersInfos != null && inActiveUsersInfos.Count > 0) ? inActiveUsersInfos : null;

                return (new clsOperationResult { Status = enOperationStatus.Success }, inActiveUsersInfos);
            }
            catch (Exception)
            {
                return (new clsOperationResult
                {
                    Status = enOperationStatus.Exception,
                    Message = clsGeneralValidationMessages.DatabaseOperationExceptionMessage
                }, null);
            }
        }


        // >>
        public static (clsOperationResult, List<clsDeleteUserInfoGridViewDto>) GetDeletedUsersForGridView()
        {
            if (!clsCurrentUser.HasPermission(enPermissions.ViewUsers))
                return (new clsOperationResult
                {
                    Status = enOperationStatus.Failed,
                    Message = clsPermissionsValidationMessages.PermissionDeniedMessage
                }, null);

            try
            {
                List<clsDeleteUserInfoGridViewDto> deletedUsersInfos = clsUserDAL.GetDeletedUsersForGridView();

                deletedUsersInfos = (deletedUsersInfos != null && deletedUsersInfos.Count > 0) ? deletedUsersInfos : null;

                return (new clsOperationResult { Status = enOperationStatus.Success }, deletedUsersInfos);
            }
            catch (Exception)
            {
                return (new clsOperationResult
                {
                    Status = enOperationStatus.Exception,
                    Message = clsGeneralValidationMessages.DatabaseOperationExceptionMessage
                }, null);
            }
        }

        
        // >>
        public static clsOperationResult AddNewUserAndRole(clsUser user, string confirmPassword, int roleID)
        {
            if (!clsCurrentUser.HasPermission(enPermissions.AddUserAndRole))
                return new clsOperationResult { Status = enOperationStatus.Failed,
                    Message = clsUserValidationMessages.PermissionDeniedMessage,
                    PropertyName = string.Empty };

            if (user == null)
                return new clsOperationResult { Status = enOperationStatus.Failed,
                    Message = clsUserValidationMessages.UserInfoRequiredMessage,
                    PropertyName = string.Empty };


            clsOperationResult validateUserNameResult = clsUserValidations.ValidateUserNameAndCheckIsExists(user.UserName);

            if (validateUserNameResult.Status == enOperationStatus.Failed || 
                validateUserNameResult.Status == enOperationStatus.Exception)
                return validateUserNameResult;


            clsOperationResult validatePasswordResult = clsUserValidations.ValidatePasswordResult(user.Password);

            if (validatePasswordResult.Status == enOperationStatus.Failed)
                return validatePasswordResult;

            
            clsOperationResult validateConfirmPasswordResult = clsUserValidations.ValidateConfirmPasswordResult(confirmPassword, user.Password);

            if (validateConfirmPasswordResult.Status == enOperationStatus.Failed)
                return validateConfirmPasswordResult;

            if (roleID <= 0)
                return new clsOperationResult
                {
                    Status = enOperationStatus.Failed,
                    Message = clsRoleValidationMessages.RoleRequiredMessage,
                    PropertyName = "Role"
                };

            try
            {
                user.Password = clsHashHelper.ComputeHash(user.Password);

                bool isAdded = clsUserDAL.AddNewUserAndRole(user, roleID, out int newID);

                if (isAdded)
                    return new clsOperationResult
                    {
                        Status = enOperationStatus.Success,
                        Message = clsUserValidationMessages.UserAddedSuccessfullyMessage,
                        CreatedID = newID,
                        PropertyName = string.Empty
                    };
                else
                    return new clsOperationResult
                    {
                        Status = enOperationStatus.Failed,
                        Message = clsUserValidationMessages.UserAddFailedMessage,
                        PropertyName = string.Empty
                    };
            }
            catch (Exception)
            {
                return new clsOperationResult
                {
                    Status = enOperationStatus.Exception,
                    Message = clsGeneralValidationMessages.DatabaseOperationExceptionMessage,
                    PropertyName = string.Empty
                };
            }
        }


        // >>
        public static clsOperationResult UpdateUserNameAndStatusInfo(clsUser user)
        {
            if (!clsCurrentUser.HasPermission(enPermissions.UpdateUserLoginInfo))
                return new clsOperationResult
                {
                    Status = enOperationStatus.Failed,
                    Message = clsUserValidationMessages.PermissionDeniedMessage,
                    PropertyName = string.Empty
                };

            if (user == null)
                return new clsOperationResult
                {
                    Status = enOperationStatus.Failed,
                    Message = clsUserValidationMessages.UserInfoRequiredMessage,
                    PropertyName = string.Empty
                };

            clsOperationResult validateUserNameResult = clsUserValidations.ValidateUserNameAndCheckIsExists(user.UserName, user.UserID);

            if (validateUserNameResult.Status == enOperationStatus.Failed ||
                validateUserNameResult.Status == enOperationStatus.Exception)
                return validateUserNameResult;


            try
            {
                bool isUpdated = clsUserDAL.UpdateUserNameAndStatusInfo(user);

                if (isUpdated)
                    return new clsOperationResult
                    {
                        Status = enOperationStatus.Success,
                        Message = clsUserValidationMessages.UserUpdatedSuccessfullyMessage,
                        PropertyName = string.Empty
                    };
                else
                    return new clsOperationResult
                    {
                        Status = enOperationStatus.Failed,
                        Message = clsUserValidationMessages.UserUpdatedFailedMessage,
                        PropertyName = string.Empty
                    };
            }
            catch (Exception)
            {
                return new clsOperationResult
                {
                    Status = enOperationStatus.Exception,
                    Message = clsGeneralValidationMessages.DatabaseOperationExceptionMessage,
                    PropertyName = string.Empty
                };
            }
        }


        // >>
        public static clsOperationResult UpdateUserPassword(string newPassword, string confirmPassword, int userID) 
        {
            if (!clsCurrentUser.HasPermission(enPermissions.UpdateUserPassword))
                return new clsOperationResult
                {
                    Status = enOperationStatus.Failed,
                    Message = clsUserValidationMessages.PermissionDeniedMessage,
                    PropertyName = string.Empty
                };

            clsOperationResult validatePasswordResult = clsUserValidations.ValidatePasswordResult(newPassword);

            if (validatePasswordResult.Status == enOperationStatus.Failed)
                return validatePasswordResult;

            clsOperationResult validateConfirmPasswordResult = clsUserValidations.ValidateConfirmPasswordResult(confirmPassword, newPassword);

            if (validateConfirmPasswordResult.Status == enOperationStatus.Failed)
                return validateConfirmPasswordResult;

            try
            {
                string computeHashPassword = clsHashHelper.ComputeHash(newPassword);

                bool isUpdated = clsUserDAL.UpdateUserPassword(computeHashPassword, userID);

                if (isUpdated)
                    return new clsOperationResult
                    {
                        Status = enOperationStatus.Success,
                        Message = clsUserValidationMessages.PasswordUpdatedSuccessfullyMessage,
                        PropertyName = string.Empty
                    };
                else
                    return new clsOperationResult
                    {
                        Status = enOperationStatus.Failed,
                        Message = clsUserValidationMessages.PasswordUpdatedFailedMessage,
                        PropertyName = string.Empty
                    };
            }
            catch (Exception)
            {
                return new clsOperationResult
                {
                    Status = enOperationStatus.Exception,
                    Message = clsGeneralValidationMessages.DatabaseOperationExceptionMessage,
                    PropertyName = string.Empty
                };
            }
        }

       
        // >>
        public static clsOperationResult ActivateUser(int userID)
        {
            if (!clsCurrentUser.HasPermission(enPermissions.UpdateUserLoginInfo))
                return new clsOperationResult
                {
                    Status = enOperationStatus.Failed,
                    Message = clsUserValidationMessages.PermissionDeniedMessage
                };

            if (userID <= 0)
                return new clsOperationResult
                {
                    Status = enOperationStatus.Failed,
                    Message = clsUserValidationMessages.UserIDMustBeGreaterThanZeroMessage
                };

            try
            {
                bool isActivated = clsUserDAL.ActivateUser(userID);

                if (isActivated)
                    return new clsOperationResult
                    {
                        Status = enOperationStatus.Success,
                        Message = clsUserValidationMessages.UserActivatedSuccessfullyMessage
                    };
                else
                    return new clsOperationResult
                    {
                        Status = enOperationStatus.Failed,
                        Message = clsUserValidationMessages.UserActivationFailedMessage
                    };
            }
            catch (Exception)
            {
                return new clsOperationResult
                {
                    Status = enOperationStatus.Exception,
                    Message = clsGeneralValidationMessages.DatabaseOperationExceptionMessage
                };
            }
        }

        
        // >>
        public static clsOperationResult SoftDeleteUser(int userID)
        {
            if (!clsCurrentUser.HasPermission(enPermissions.DeleteUser))
                return new clsOperationResult
                {
                    Status = enOperationStatus.Failed,
                    Message = clsUserValidationMessages.PermissionDeniedMessage
                };

            if (userID <= 0)
                return new clsOperationResult
                {
                    Status = enOperationStatus.Failed,
                    Message = clsUserValidationMessages.UserIDMustBeGreaterThanZeroMessage
                };

            try
            {
                bool isDeleted = clsUserDAL.SoftDeleteUser(userID);

                if (isDeleted)
                    return new clsOperationResult
                    {
                        Status = enOperationStatus.Success,
                        Message = clsUserValidationMessages.UserDeletedSuccessfullyMessage
                    };
                else
                    return new clsOperationResult
                    {
                        Status = enOperationStatus.Failed,
                        Message = clsUserValidationMessages.UserDeletedFailedMessage
                    };
            }
            catch (Exception)
            {
                return new clsOperationResult
                {
                    Status = enOperationStatus.Exception,
                    Message = clsGeneralValidationMessages.DatabaseOperationExceptionMessage
                };
            }
        }


        // >>
        public static clsOperationResult RestoreUser(int userID)
        {
            if (!clsCurrentUser.HasPermission(enPermissions.RestoreUser))
                return new clsOperationResult
                {
                    Status = enOperationStatus.Failed,
                    Message = clsUserValidationMessages.PermissionDeniedMessage
                };

            if (userID <= 0)
                return new clsOperationResult
                {
                    Status = enOperationStatus.Failed,
                    Message = clsUserValidationMessages.UserIDMustBeGreaterThanZeroMessage
                };

            try
            {
                bool isActivated = clsUserDAL.RestoreUser(userID);

                if (isActivated)
                    return new clsOperationResult
                    {
                        Status = enOperationStatus.Success,
                        Message = clsUserValidationMessages.UserRestoredSuccessfullyMessage
                    };
                else
                    return new clsOperationResult
                    {
                        Status = enOperationStatus.Failed,
                        Message = clsUserValidationMessages.UserRestoredFailedMessage
                    };
            }
            catch (Exception)
            {
                return new clsOperationResult
                {
                    Status = enOperationStatus.Exception,
                    Message = clsGeneralValidationMessages.DatabaseOperationExceptionMessage
                };
            }
        }
    }
}
