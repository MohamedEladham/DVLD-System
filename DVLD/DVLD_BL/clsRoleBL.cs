using DVLD_DAL;
using DVLD_Models;
using DVLD_Models.Role;
using DVLD_Models.User;
using DVLD_Shared.Operations_Result;
using DVLD_Shared.Validation_Messages;
using DVLD_Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_Shared.Global_Classes;
using static DVLD_Shared.Operations_Result.clsOperationResult;
using DVLD_BL.Validations;
using System.Data.SqlClient;
using DVLD_Models.Roles;

namespace DVLD_BL
{
    public class clsRoleBL
    {
        public static clsOperationResult IsRoleNameNotExists(string roleName, int? roleID = null)
        {
            try
            {
                bool isRoleNameNotExists = roleID.HasValue ? 
                    clsRoleDAL.IsRoleNameNotExists(roleName, roleID.Value) :
                    clsRoleDAL.IsRoleNameNotExists(roleName);

                if (isRoleNameNotExists)
                    return new clsOperationResult
                    {
                        Status = enOperationStatus.Failed,
                        Message = clsRoleValidationMessages.RoleNameAleadyExsistMessage,
                        PropertyName = nameof(clsRole.RoleName)
                    };
                    
                return new clsOperationResult {Status = enOperationStatus.Success};
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

        public static (clsOperationResult, List<string>) GetRoleNamesByUserID(int userID)
        {
            if (!clsCurrentUser.HasPermission(enPermissions.ViewUserRoles))
                return (new clsOperationResult
                {
                    Status = enOperationStatus.Failed,
                    Message = clsPermissionsValidationMessages.PermissionDeniedMessage
                }, null);


            if (userID <= 0)
                return (new clsOperationResult
                {
                    Status = enOperationStatus.Failed,
                    Message = clsUserValidationMessages.InvalidUserIDMessage
                }, null);

            try
            {
                return (new clsOperationResult { Status = enOperationStatus.Success }, clsRoleDAL.GetRoleNamesByUserID(userID));
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

        public static (clsOperationResult, clsRole) GetRoleByRoleID(int roleID)
        {
            if (!clsCurrentUser.HasPermission(enPermissions.ViewRoles))
                return (new clsOperationResult
                {
                    Status = enOperationStatus.Failed,
                    Message = clsPermissionsValidationMessages.PermissionDeniedMessage
                }, null);

            if (roleID <= 0)
                return (new clsOperationResult
                {
                    Status = enOperationStatus.Failed,
                    Message = clsRoleValidationMessages.InvalidIDMessage
                }, null);

            try
            {
                clsRole role = clsRoleDAL.GetRoleByRoleID(roleID);

                if (role != null)
                    return (new clsOperationResult { Status = enOperationStatus.Success }, role);
                else
                    return (new clsOperationResult
                    {
                        Status = enOperationStatus.Failed,
                        Message = clsRoleValidationMessages.RoleNotFoundMessage
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

        public static (clsOperationResult, List<clsRole>) GetAllRoles()
        {
            if (!clsCurrentUser.HasPermission(enPermissions.ViewRoles))
                return (new clsOperationResult
                {
                    Status = enOperationStatus.Failed,
                    Message = clsPermissionsValidationMessages.PermissionDeniedMessage
                }, null);

            try
            {
                List<clsRole> roles = clsRoleDAL.GetAllRoles();

                roles = (roles != null && roles.Count > 0) ? roles : null;

                return (new clsOperationResult { Status = enOperationStatus.Success }, roles);
            }
            catch
            {
                return (new clsOperationResult
                {
                    Status  = enOperationStatus.Exception,
                    Message = clsGeneralValidationMessages.DatabaseOperationExceptionMessage
                }, null);
            }
        }

        public static (clsOperationResult, List<clsActiveRolesInfoGridViewDto>) GetActiveRoles()
        {
            if (!clsCurrentUser.HasPermission(enPermissions.ViewRoles))
                return (new clsOperationResult
                {
                    Status = enOperationStatus.Failed,
                    Message = clsPermissionsValidationMessages.PermissionDeniedMessage
                }, null);

            try
            {
                List<clsActiveRolesInfoGridViewDto> activeRoles = clsRoleDAL.GetActiveRoles();

                activeRoles = (activeRoles != null && activeRoles.Count > 0) ? activeRoles : null;

                return (new clsOperationResult { Status = enOperationStatus.Success }, activeRoles);
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

        public static (clsOperationResult, List<clsDeleteRolesInfoGridViewDto>) GetDeletedRoles()
        {
            if (!clsCurrentUser.HasPermission(enPermissions.ViewRoles))
                return (new clsOperationResult
                {
                    Status = enOperationStatus.Failed,
                    Message = clsPermissionsValidationMessages.PermissionDeniedMessage
                }, null);

            try
            {
                List<clsDeleteRolesInfoGridViewDto> deletedRoles = clsRoleDAL.GetDeletedRoles();

                if(deletedRoles.Count > 0)
                    return (new clsOperationResult { Status = enOperationStatus.Success }, deletedRoles);
                else
                    return (new clsOperationResult { Status = enOperationStatus.Success }, null);
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
        public static clsOperationResult AddRoleAndPermissions(clsRole role, List<int> permissionIDs) 
        {
            if (!clsCurrentUser.HasPermission(enPermissions.AddRoleAndPermissions))
                return new clsOperationResult
                {
                    Status = enOperationStatus.Failed,
                    Message = clsPermissionsValidationMessages.PermissionDeniedMessage,
                    PropertyName = string.Empty
                };
            
            if (role == null)
                return new clsOperationResult
                {
                    Status = enOperationStatus.Failed,
                    Message = clsRoleValidationMessages.RoleInfoRequiredMessage,
                    PropertyName = string.Empty
                };


            clsOperationResult validateRoleNameResult = clsRoleValidations.ValidateRoleNameAndCheckIsExistsResult(role.RoleName);

            if (validateRoleNameResult.Status == enOperationStatus.Failed ||
                validateRoleNameResult.Status == enOperationStatus.Exception)
                return validateRoleNameResult;


            clsOperationResult validateRoleDescriptionResult = clsRoleValidations.ValidateRoleDescriptionResult(role.Description);

            if (validateRoleDescriptionResult.Status == enOperationStatus.Failed)
                return validateRoleDescriptionResult;


            try
            {
                bool isAdded = clsRoleDAL.AddRoleAndPermissions(role, permissionIDs, out int newID);

                if (isAdded)
                    return new clsOperationResult
                    {
                        Status = enOperationStatus.Success,
                        Message = clsRoleValidationMessages.RoleAddedSuccessfullyMessage,
                        CreatedID = newID,
                        PropertyName = string.Empty
                    };
                else
                    return new clsOperationResult
                    {
                        Status = enOperationStatus.Failed,
                        Message = clsRoleValidationMessages.RoleAddFailedMessage,
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

        public static clsOperationResult UpdateRoleAndPermissions(clsRole role, List<int> permissionIDs)
        {
            if (!clsCurrentUser.HasPermission(enPermissions.UpdateRoleAndPermissions))
                return new clsOperationResult
                {
                    Status = enOperationStatus.Failed,
                    Message = clsPermissionsValidationMessages.PermissionDeniedMessage,
                    PropertyName = string.Empty
                };

            if (role == null)
                return new clsOperationResult
                {
                    Status = enOperationStatus.Failed,
                    Message = clsRoleValidationMessages.RoleInfoRequiredMessage,
                    PropertyName = string.Empty
                };
       

            clsOperationResult validateRoleNameResult = clsRoleValidations.ValidateRoleNameAndCheckIsExistsResult(role.RoleName, role.RoleID);

            if (validateRoleNameResult.Status == enOperationStatus.Failed ||
                validateRoleNameResult.Status == enOperationStatus.Exception)
                return validateRoleNameResult;


            clsOperationResult validateRoleDescriptionResult = clsRoleValidations.ValidateRoleDescriptionResult(role.Description);

            if (validateRoleDescriptionResult.Status == enOperationStatus.Failed)
                return validateRoleDescriptionResult;


            try
            {
                bool isUpdated = clsRoleDAL.UpdateRoleAndPermissions(role, permissionIDs);

                if (isUpdated)
                    return new clsOperationResult
                    {
                        Status = enOperationStatus.Success,
                        Message = clsRoleValidationMessages.RoleUpdatedSuccessfullyMessage,
                        PropertyName = string.Empty
                    };
                else
                    return new clsOperationResult
                    {
                        Status = enOperationStatus.Failed,
                        Message = clsRoleValidationMessages.RoleUpdateFailedMessage,
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

        public static clsOperationResult UpdateUserRoles(int userID, List<int> roleIDs)
        {
            if (!clsCurrentUser.HasPermission(enPermissions.UpdateUserRoles))
                return new clsOperationResult
                {
                    Status = enOperationStatus.Failed,
                    Message = clsPermissionsValidationMessages.PermissionDeniedMessage
                };

            if (userID <= 0)
                return new clsOperationResult
                {
                    Status = enOperationStatus.Failed,
                    Message = clsUserValidationMessages.InvalidUserIDMessage
                };

            if (roleIDs == null)
                return new clsOperationResult
                {
                    Status = enOperationStatus.Failed,
                    Message = clsRoleValidationMessages.RoleRequiredMessage
                };

            if (roleIDs.Count != roleIDs.Distinct().Count())
                return new clsOperationResult
                {
                    Status = enOperationStatus.Failed,
                    Message = clsRoleValidationMessages.DuplicateRolesMessage
                };

            try
            {
                bool isUpdated = clsRoleDAL.UpdateUserRoles(userID, roleIDs);

                if (isUpdated)
                    return new clsOperationResult
                    {
                        Status = enOperationStatus.Success,
                        Message = clsRoleValidationMessages.RoleUpdatedSuccessfullyMessage
                    };
                else
                    return new clsOperationResult
                    {
                        Status = enOperationStatus.Failed,
                        Message = clsRoleValidationMessages.RoleUpdateFailedMessage
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

        public static clsOperationResult SoftDeleteRoleAndDeleteRolePermission(int roleID)
        {
            if (!clsCurrentUser.HasPermission(enPermissions.DeleteRole))
                return new clsOperationResult
                {
                    Status = enOperationStatus.Failed,
                    Message = clsUserValidationMessages.PermissionDeniedMessage
                };

            if (roleID <= 0)
                return new clsOperationResult
                {
                    Status = enOperationStatus.Failed,
                    Message = clsRoleValidationMessages.InvalidRoleIDMessage
                };

            try
            {
                bool isDeleted = clsRoleDAL.SoftDeleteRoleAndDeleteRolePermission(roleID);

                if (isDeleted)
                    return new clsOperationResult
                    {
                        Status = enOperationStatus.Success,
                        Message = clsRoleValidationMessages.RoleDeletedSuccessfullyMessage
                    };
                else
                    return new clsOperationResult
                    {
                        Status = enOperationStatus.Failed,
                        Message = clsRoleValidationMessages.RoleDeletedFailedMessage
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

        public static clsOperationResult RestoreRole(int roleID)
        {
            if (!clsCurrentUser.HasPermission(enPermissions.RestoreRole))
                return new clsOperationResult
                {
                    Status = enOperationStatus.Failed,
                    Message = clsUserValidationMessages.PermissionDeniedMessage
                };

            if (roleID <= 0)
                return new clsOperationResult
                {
                    Status = enOperationStatus.Failed,
                    Message = clsRoleValidationMessages.InvalidRoleIDMessage
                };

            try
            {
                bool isRestored = clsRoleDAL.RestoreRole(roleID);

                if (isRestored)
                    return new clsOperationResult
                    {
                        Status = enOperationStatus.Success,
                        Message = clsRoleValidationMessages.RoleRestoredSuccessfullyMessage
                    };
                else
                    return new clsOperationResult
                    {
                        Status = enOperationStatus.Failed,
                        Message = clsRoleValidationMessages.RoleRestoredFailedMessage
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
