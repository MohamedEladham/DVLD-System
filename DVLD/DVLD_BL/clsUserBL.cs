using System;
using DVLD_DAL;
using DVLD_Shared;
using DVLD_Models.User;
using System.Collections.Generic;
using DVLD_Shared.Global_Classes;
using DVLD_Shared.Operations_Result;
using DVLD_Shared.Validation_Messages;
using static DVLD_Shared.Operations_Result.clsOperationResult;
using System.Data.SqlClient;
using DVLD_BL.Validations;

namespace DVLD_BL
{
    public class clsUserBL
    {
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

        public static bool CheckPersonIsUser(int personID)
        {
            return clsUserDAL.CheckPersonIsUser(personID);
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

        public static (clsOperationResult, clsUser) GetUserByUserNameAndPassword(string userName, string password)
        {
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

        public static List<clsUser> GetAllUsersInfo()
        {
            return clsUserDAL.GetAllUsersInfo();
        }

        public static List<clsUserInfoGridViewDto> GetActiveUsersForGridView()
        {
            List <clsUserInfoGridViewDto> activeUsersInfos = clsUserDAL.GetActiveUsersForGridView();

            return activeUsersInfos.Count > 0 ? activeUsersInfos : null;
        }

        public static List<clsUserInfoGridViewDto> GetInActiveUsersForGridView()
        {
            List<clsUserInfoGridViewDto> InActiveUsersInfos = clsUserDAL.GetInActiveUsersForGridView();

            return InActiveUsersInfos.Count > 0 ? InActiveUsersInfos : null;
        }

        public static List<clsDeleteUserInfoGridViewDto> GetDeletedUsersForGridView()
        {
            List<clsDeleteUserInfoGridViewDto> deletedUsersInfos = clsUserDAL.GetDeletedUsersForGridView();

            return deletedUsersInfos.Count > 0 ? deletedUsersInfos : null;
        }

        // >>

        public static clsOperationResult AddNewUser(clsUser user)
        {
            if (!clsCurrentUser.HasPermission(enPermissions.AddUser))
                return new clsOperationResult
                {
                    Status = enOperationStatus.Failed,
                    Message = clsUserValidationMessages.PermissionDeniedMessage
                };

            if (user == null)
                return new clsOperationResult
                {
                    Status = enOperationStatus.Failed,
                    Message = clsUserValidationMessages.UserInfoRequiredMessage
                };

            try
            {
                user.Password = clsHashHelper.ComputeHash(user.Password);

                bool isAdded = clsUserDAL.AddNewUserAndGetNewID(user, out int newID);

                if (isAdded)
                    return new clsOperationResult
                    {
                        Status = enOperationStatus.Success,
                        Message = clsUserValidationMessages.UserAddedSuccessfullyMessage,
                        CreatedID = newID
                    };
                else
                    return new clsOperationResult
                    {
                        Status = enOperationStatus.Failed,
                        Message = clsUserValidationMessages.UserAddFailedMessage 
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

        public static clsOperationResult AddUserRole(int userID, int roleID)
        {
            if (!clsCurrentUser.HasPermission(enPermissions.AddUser))
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

            if (roleID <= 0)
                return new clsOperationResult
                {
                    Status = enOperationStatus.Failed,
                    Message = clsUserValidationMessages.RoleIDMustBeGreaterThanZeroMessage
                };

            try
            {
                bool isAdded = clsUserDAL.AddUserRole(userID, roleID);

                if (isAdded)
                    return new clsOperationResult
                    {
                        Status = enOperationStatus.Success,
                        Message = clsUserValidationMessages.UserRoleAddedSuccessfullyMessage,
                    };
                else
                    return new clsOperationResult
                    {
                        Status = enOperationStatus.Failed,
                        Message = clsUserValidationMessages.UserRoleAddFailedMessage
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

        public static clsOperationResult UpdatePassword(string newPassword, int userID)
        {
            if (!clsCurrentUser.HasPermission(enPermissions.UpdateUserPassword))
                return new clsOperationResult
                {
                    Status = enOperationStatus.Failed,
                    Message = clsUserValidationMessages.PermissionDeniedMessage
                };

            if (string.IsNullOrEmpty(newPassword))
                return new clsOperationResult
                {
                    Status = enOperationStatus.Failed,
                    Message = clsUserValidationMessages.NewPasswordRequiredMessage
                };

            try
            {
                string computeHashPassword = clsHashHelper.ComputeHash(newPassword);

                bool isUpdated = clsUserDAL.UpdatePassword(computeHashPassword, userID);

                if (isUpdated)
                    return new clsOperationResult
                    {
                        Status = enOperationStatus.Success,
                        Message = clsUserValidationMessages.PasswordUpdatedSuccessfullyMessage
                    };
                else
                    return new clsOperationResult
                    {
                        Status = enOperationStatus.Failed,
                        Message = clsUserValidationMessages.PasswordUpdatedFailedMessage
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

        public static clsOperationResult UpdateUserNameAndStatusInfo(clsUser user)
        {
            if(!clsCurrentUser.HasPermission(enPermissions.UpdateUserLoginInfo))
                return new clsOperationResult
                {
                    Status = enOperationStatus.Failed,
                    Message = clsUserValidationMessages.PermissionDeniedMessage
                };

            if (user == null)
                return new clsOperationResult
                {
                    Status = enOperationStatus.Failed,
                    Message = clsUserValidationMessages.UserInfoRequiredMessage
                };

            try
            {
                bool isUpdated = clsUserDAL.UpdateUserNameAndStatusInfo(user);

                if (isUpdated)
                    return new clsOperationResult
                    {
                        Status = enOperationStatus.Success,
                        Message = clsUserValidationMessages.UserUpdatedSuccessfullyMessage
                    };
                else
                    return new clsOperationResult
                    {
                        Status = enOperationStatus.Failed,
                        Message = clsUserValidationMessages.UserUpdatedFailedMessage
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
    }
}
