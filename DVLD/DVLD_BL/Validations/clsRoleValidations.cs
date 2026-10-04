using DVLD_DAL;
using DVLD_Shared.Validation_Messages;
using DVLD_Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_Shared.Global_Classes;
using DVLD_Models.User;
using DVLD_Shared.Operations_Result;
using static DVLD_Shared.Operations_Result.clsOperationResult;
using DVLD_Models.Role;

namespace DVLD_BL.Validations
{
    public class clsRoleValidations
    {
        public static clsValidationResult ValidateRoleName(string roleName, int minLength, int maxLength)
        {
            if (string.IsNullOrEmpty(roleName))
                return new clsValidationResult { IsValid = false, Message = "Role Name is required." };

            if (roleName.Length < minLength)
                return new clsValidationResult { IsValid = false, Message = "Role Name Is Too Short Length" };

            if (roleName.Length > maxLength)
                return new clsValidationResult { IsValid = false, Message = "Role Name Out Of Length" };

            if (!clsValidationHelper.IsValidInputWithSpace(roleName))
                return new clsValidationResult { IsValid = false, Message = "Role Name Invalid Format" };

            return new clsValidationResult { IsValid = true };
        }

        public static clsOperationResult ValidateRoleNameAndCheckIsExistsResult(string roleName, int? roleID = null)
        {
            string propertyName = nameof(clsRole.RoleName);

            clsValidationResult validateUserNameResult = ValidateRoleName(roleName, 3, 200);

            if (!validateUserNameResult.IsValid)
                return new clsOperationResult
                {
                    Status = enOperationStatus.Failed,
                    Message = validateUserNameResult.Message, 
                    PropertyName = propertyName
                };

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
                        PropertyName = propertyName
                    };

                return new clsOperationResult { Status = enOperationStatus.Success, PropertyName = string.Empty };
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

        public static clsValidationResult ValidateRoleDescription(string description, int minLength, int maxLength)
        {
            if (description.Length > 0 && description.Length < minLength)
                return new clsValidationResult { IsValid = false, Message = "Description Is Too Short Length" };

            if (description.Length > maxLength)
                return new clsValidationResult { IsValid = false, Message = "Description Out Of Length" };

            if (description.Length > 0 && !clsValidationHelper.IsValidInputWithSpace(description))
                return new clsValidationResult { IsValid = false, Message = "Description Invalid Format" };

            return new clsValidationResult { IsValid = true };
        }

        public static clsOperationResult ValidateRoleDescriptionResult(string description)
        {
            string propertyName = nameof(clsRole.Description);

            clsValidationResult validateRoleDescriptionResult = ValidateRoleDescription(description, 3, 500);

            if (!validateRoleDescriptionResult.IsValid)
                return new clsOperationResult
                {
                    Status = enOperationStatus.Failed,
                    Message = validateRoleDescriptionResult.Message,
                    PropertyName = propertyName
                };

            return new clsOperationResult { Status = enOperationStatus.Success, PropertyName = string.Empty };
        }
    }
}
