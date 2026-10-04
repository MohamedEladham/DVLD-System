using System;
using DVLD_DAL;
using DVLD_Shared;
using DVLD_Models.User;
using DVLD_Models.Permissions;
using System.Collections.Generic;
using DVLD_Shared.Global_Classes;
using DVLD_Shared.Operations_Result;
using DVLD_Shared.Validation_Messages;
using static DVLD_Shared.Operations_Result.clsOperationResult;

namespace DVLD_BL
{
    public class clsRolePermissionsBL
    {
        public static clsOperationResult IsPermissionUsedInAnyRole(int permissionID)
        {
            if (permissionID <= 0)
                return new clsOperationResult
                {
                    Status = enOperationStatus.Failed,
                    Message = clsPermissionsValidationMessages.InvalidPermissionIDMessage
                };

            try
            {
                bool isExists = clsRolePermissionsDAL.IsPermissionUsedInAnyRole(permissionID);

                if (isExists)
                    return new clsOperationResult
                    {
                        Status = enOperationStatus.Failed,
                        Message = clsPermissionsValidationMessages.PermissionIsCurrentlyUseMessage,
                    };

                return new clsOperationResult { Status = enOperationStatus.Success };
            }
            catch(Exception)
            {
                return new clsOperationResult
                {
                    Status = enOperationStatus.Exception,
                    Message = clsGeneralValidationMessages.DatabaseOperationExceptionMessage,
                };
            }
        }


        // >>

        public static (clsOperationResult, List<string>) GetRoleNamesByPermissionID(int permissionID)
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
                return (new clsOperationResult { Status = enOperationStatus.Success }, clsRolePermissionsDAL.GetRoleNamesByPermissionID(permissionID));
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
        public static (clsOperationResult, List<int>) GetRolePermissionIDs(int roleID)
        {
            if (!clsCurrentUser.HasPermission(enPermissions.ViewRolePermissions))
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
                return (new clsOperationResult { Status = enOperationStatus.Success }, clsRolePermissionsDAL.GetRolePermissionIDs(roleID));
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

        public static (clsOperationResult, List<string>) GetRolePermissionNames(int roleID)
        {
            if (!clsCurrentUser.HasPermission(enPermissions.ViewRolePermissions))
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
                return (new clsOperationResult { Status = enOperationStatus.Success }, clsRolePermissionsDAL.GetRolePermissionNames(roleID));
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
        public static (clsOperationResult, List<clsPermission>) GetRolePermissionsByRoleID(int roleID)
        {
            if (!clsCurrentUser.HasPermission(enPermissions.ViewRolePermissions))
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
                return (new clsOperationResult { Status = enOperationStatus.Success }, clsRolePermissionsDAL.GetRolePermissionsByRoleID(roleID));
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
    }
}
