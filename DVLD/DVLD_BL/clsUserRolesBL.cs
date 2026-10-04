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
using DVLD_Models.User;
using DVLD_Shared.Global_Classes;

namespace DVLD_BL
{
    public class clsUserRolesBL
    {
        public static clsOperationResult IsRoleUsedInAnyUser(int roleID) 
        {
            if (roleID <= 0)
                return new clsOperationResult
                {
                    Status = enOperationStatus.Failed,
                    Message = clsRoleValidationMessages.InvalidRoleIDMessage
                };

            try
            {
                bool isExists = clsUserRolesDAL.IsRoleUsedInAnyUser(roleID);

                if (isExists)
                    return new clsOperationResult
                    {
                        Status = enOperationStatus.Failed,
                        Message = clsRoleValidationMessages.RoleIsCurrentlyUseMessage
                    };

                return new clsOperationResult { Status = enOperationStatus.Success };
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

        public static (clsOperationResult, List<string>) GetUserNamesByRoleID(int roleID) 
        {
            if (!clsCurrentUser.HasPermission(enPermissions.ViewRoles))
                return (new clsOperationResult
                {
                    Status = enOperationStatus.Failed,
                    Message = clsUserValidationMessages.PermissionDeniedMessage
                }, null);


            if (roleID <= 0)
                return (new clsOperationResult
                {
                    Status = enOperationStatus.Failed,
                    Message = clsRoleValidationMessages.InvalidRoleIDMessage
                }, null);

            try
            {
                return (new clsOperationResult { Status = enOperationStatus.Success }, clsUserRolesDAL.GetUserNamesByRoleID(roleID));
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
