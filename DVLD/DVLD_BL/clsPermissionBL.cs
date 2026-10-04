using DVLD_DAL;
using DVLD_Shared.Operations_Result;
using DVLD_Shared.Validation_Messages;
using DVLD_Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DVLD_Shared.Operations_Result.clsOperationResult;
using DVLD_Models.Permissions;
using DVLD_Models.Role;
using DVLD_Models.User;
using DVLD_Shared.Global_Classes;
using DVLD_Models.Roles;
using DVLD_BL.Validations;
using DVLD_Models;

namespace DVLD_BL
{
    public class clsPermissionBL
    {
        public static (clsOperationResult, clsPermission) GetPermissionByPermissionID(int permissionID)
        {
            if (!clsCurrentUser.HasPermission(enPermissions.ViewPermissions))
                return (new clsOperationResult
                {
                    Status = enOperationStatus.Failed,
                    Message = clsPermissionsValidationMessages.PermissionDeniedMessage
                }, null);

            if (permissionID <= 0)
                return (new clsOperationResult
                {
                    Status = enOperationStatus.Failed,
                    Message = clsPermissionsValidationMessages.InvalidPermissionIDMessage
                }, null);

            try
            {
                clsPermission permission = clsPermissionDAL.GetPermissionByPermissionID(permissionID);

                if (permission != null)
                    return (new clsOperationResult { Status = enOperationStatus.Success }, permission);
                else
                    return (new clsOperationResult
                    {
                        Status = enOperationStatus.Failed,
                        Message = clsPermissionsValidationMessages.PermissionNotFoundMessage
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

        public static (clsOperationResult, List<clsPermission>) GetActivePermissions()
        {
            if (!clsCurrentUser.HasPermission(enPermissions.ViewPermissions))
                return (new clsOperationResult
                {
                    Status = enOperationStatus.Failed,
                    Message = clsPermissionsValidationMessages.PermissionDeniedMessage
                }, null);

            try
            {
                List<clsPermission> activePermissions = clsPermissionDAL.GetActivePermissions();

                activePermissions = (activePermissions != null && activePermissions.Count > 0) ? activePermissions : null;

                return (new clsOperationResult { Status = enOperationStatus.Success }, activePermissions);
            }
            catch
            {
                return (new clsOperationResult
                {
                    Status = enOperationStatus.Exception,
                    Message = clsGeneralValidationMessages.DatabaseOperationExceptionMessage
                }, null);
            }
        }

        public static (clsOperationResult, List<clsPermission>) GetInActivePermissions()
        {
            if (!clsCurrentUser.HasPermission(enPermissions.ViewPermissions))
                return (new clsOperationResult
                {
                    Status = enOperationStatus.Failed,
                    Message = clsPermissionsValidationMessages.PermissionDeniedMessage
                }, null);

            try
            {
                List<clsPermission> inActivePermissions = clsPermissionDAL.GetInActivePermissions();

                inActivePermissions = (inActivePermissions != null && inActivePermissions.Count > 0) ? inActivePermissions : null;

                return (new clsOperationResult { Status = enOperationStatus.Success }, inActivePermissions);
            }
            catch
            {
                return (new clsOperationResult
                {
                    Status = enOperationStatus.Exception,
                    Message = clsGeneralValidationMessages.DatabaseOperationExceptionMessage
                }, null);
            }
        }

        
        // >>
        public static clsOperationResult AddNewPermission(clsPermission permission)
        {
            if (!clsCurrentUser.HasPermission(enPermissions.AddPermissions))
                return new clsOperationResult
                {
                    Status = enOperationStatus.Failed,
                    Message = clsPermissionsValidationMessages.PermissionDeniedMessage,
                    PropertyName = string.Empty
                };

            if (permission == null)
                return new clsOperationResult
                {
                    Status = enOperationStatus.Failed,
                    Message = clsPermissionsValidationMessages.PermissionInfoRequiredMessage,
                    PropertyName = string.Empty
                };

            clsOperationResult validatePermissionNameResult =
                clsPermissionValidations.ValidatePermissionNameAndCheckIsExists(permission.PermissionName, null);

            if (validatePermissionNameResult.Status == enOperationStatus.Failed ||
                validatePermissionNameResult.Status == enOperationStatus.Exception)
                return validatePermissionNameResult;

            clsOperationResult validatePermissionCategoryResult =
               clsPermissionValidations.ValidatePermissionCategoryResult(permission.PermissionCategory);

            if (validatePermissionCategoryResult.Status == enOperationStatus.Failed)
                return validatePermissionCategoryResult;
            

            try
            {
                bool isAdded = clsPermissionDAL.AddNewPermissionAndGetNewID(permission, out int newID);

                if (isAdded)
                    return new clsOperationResult
                    {
                        Status = enOperationStatus.Success,
                        Message = clsPermissionsValidationMessages.PermissionAddedSuccessfullyMessage,
                        CreatedID = newID
                    };
                else
                    return new clsOperationResult
                    {
                        Status = enOperationStatus.Failed,
                        Message = clsPermissionsValidationMessages.PermissionAddFailedMessage,
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
        public static clsOperationResult UpdatePermission(clsPermission permission)
        {
            if (!clsCurrentUser.HasPermission(enPermissions.UpdatePermissions))
                return new clsOperationResult
                {
                    Status = enOperationStatus.Failed,
                    Message = clsPermissionsValidationMessages.PermissionDeniedMessage,
                    PropertyName = string.Empty
                };

            if (permission == null)
                return new clsOperationResult
                {
                    Status = enOperationStatus.Failed,
                    Message = clsPermissionsValidationMessages.PermissionInfoRequiredMessage,
                    PropertyName = string.Empty
                };

            clsOperationResult validatePermissionNameResult =
                clsPermissionValidations.ValidatePermissionNameAndCheckIsExists(permission.PermissionName, permission.PermissionID);

            if (validatePermissionNameResult.Status == enOperationStatus.Failed ||
                validatePermissionNameResult.Status == enOperationStatus.Exception)
                return validatePermissionNameResult;

            clsOperationResult validatePermissionCategoryResult =
               clsPermissionValidations.ValidatePermissionCategoryResult(permission.PermissionCategory);

            if (validatePermissionCategoryResult.Status == enOperationStatus.Failed)
                return validatePermissionCategoryResult;


            try
            {
                bool isUpdated = clsPermissionDAL.UpdatePermissionInfo(permission);

                if (isUpdated)
                    return new clsOperationResult
                    {
                        Status = enOperationStatus.Success,
                        Message = clsPermissionsValidationMessages.PermissionUpdatedSuccessfullyMessage,
                        PropertyName = string.Empty

                    };
                else
                    return new clsOperationResult
                    {
                        Status = enOperationStatus.Failed,
                        Message = clsPermissionsValidationMessages.PermissionUpdatedFailedMessage,
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
        public static clsOperationResult DisablingPermission(int permissionID)
        {
            if (!clsCurrentUser.HasPermission(enPermissions.DisablingPermissions))
                return new clsOperationResult 
                {
                    Status = enOperationStatus.Failed,
                    Message = clsPermissionsValidationMessages.PermissionDeniedMessage
                };

            if (permissionID <= 0)
                return new clsOperationResult
                {
                    Status = enOperationStatus.Failed,
                    Message = clsPermissionsValidationMessages.InvalidPermissionIDMessage
                };

            try
            {
                bool isDeleted = clsPermissionDAL.DisablingPermission(permissionID);

                if (isDeleted)
                    return new clsOperationResult
                    {
                        Status = enOperationStatus.Success,
                        Message = clsPermissionsValidationMessages.PermissionInactivatedSuccessfullyMessage
                    };
                else
                    return new clsOperationResult
                    {
                        Status = enOperationStatus.Failed,
                        Message = clsPermissionsValidationMessages.PermissionInactivatedFailedMessage
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
        public static clsOperationResult ActivePermission(int permissionID) 
        {
            if (!clsCurrentUser.HasPermission(enPermissions.ActivePermissions))
                return new clsOperationResult
                {
                    Status = enOperationStatus.Failed,
                    Message = clsPermissionsValidationMessages.PermissionDeniedMessage
                };

            if (permissionID <= 0)
                return new clsOperationResult
                {
                    Status = enOperationStatus.Failed,
                    Message = clsPermissionsValidationMessages.InvalidPermissionIDMessage
                };

            try
            {
                bool isRestored = clsPermissionDAL.ActivePermission(permissionID);

                if (isRestored)
                    return new clsOperationResult
                    {
                        Status = enOperationStatus.Success,
                        Message = clsPermissionsValidationMessages.PermissionActivatedSuccessfullyMessage
                    };
                else
                    return new clsOperationResult
                    {
                        Status = enOperationStatus.Failed,
                        Message = clsPermissionsValidationMessages.PermissionActivatedFailedMessage
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
