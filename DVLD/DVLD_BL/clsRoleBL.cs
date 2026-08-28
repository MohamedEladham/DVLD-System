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

namespace DVLD_BL
{
    public class clsRoleBL
    {
        public static (clsOperationResult, List<clsRole>) GetAllRoles()
        {
            try
            {
                List<clsRole> roles = clsRoleDAL.GetAllRoles();

                if (roles != null && roles.Count > 0)
                    return (new clsOperationResult { Status = clsOperationResult.enOperationStatus.Success }, roles);
                else
                    return (new clsOperationResult
                    {
                        Status = clsOperationResult.enOperationStatus.Failed,
                        Message = clsRoleValidationMessages.FailedToRetrieveRolsMessage
                    }, null);
            }
            catch
            {
                return (new clsOperationResult
                {
                    Status = clsOperationResult.enOperationStatus.Exception,
                    Message = clsGeneralValidationMessages.DatabaseOperationExceptionMessage
                }, null);
            }
        }

        public static (clsOperationResult, List<string>) GetRoleNamesByUserID(int userID)
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
                List<string> roleNames = clsRoleDAL.GetRoleNamesByUserID(userID);

                if (roleNames != null && roleNames.Count > 0)
                    return (new clsOperationResult { Status = enOperationStatus.Success }, roleNames);
                else
                    return (new clsOperationResult
                    {
                        Status = enOperationStatus.Failed,
                        Message = clsRoleValidationMessages.RolesNameNotFoundMessage
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
    }
}
