using DVLD_DAL;
using DVLD_Models;
using DVLD_Models.Permissions;
using DVLD_Shared;
using DVLD_Shared.Global_Classes;
using DVLD_Shared.Operations_Result;
using DVLD_Shared.Validation_Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DVLD_Shared.Operations_Result.clsOperationResult;

namespace DVLD_BL.Validations
{
    public class clsPermissionValidations
    {
        public static clsValidationResult ValidatePermissionName(string permissionName, int minLength, int maxLength)
        {
            if (string.IsNullOrEmpty(permissionName))
                return new clsValidationResult { IsValid = false, Message = "Required" };

            if (permissionName.Length < minLength)
                return new clsValidationResult { IsValid = false, Message = "Is Too Short Length" };

            if (permissionName.Length > maxLength)
                return new clsValidationResult { IsValid = false, Message = "Out Of Length" };

            if (!clsValidationHelper.IsAlphaNumeric(permissionName))
                return new clsValidationResult { IsValid = false, Message = "Invalid Format" };

            return new clsValidationResult { IsValid = true };
        }
        
        public static clsOperationResult ValidatePermissionNameResult(string permissionName)
        {
            clsValidationResult validatePermissionName = ValidatePermissionName(permissionName, 3, 250);

            if (!validatePermissionName.IsValid)
                return new clsOperationResult
                {
                    Status = enOperationStatus.Failed,
                    Message = $"> Permission Name {validatePermissionName.Message}. ",
                    PropertyName = nameof(clsPermission.PermissionName)
                };


            return new clsOperationResult { Status = enOperationStatus.Success, PropertyName = string.Empty };
        }

        public static clsOperationResult ValidatePermissionNameAndCheckIsExists(string permissionName, int? permissionID = null)
        {
            clsOperationResult validatePermissionNameResult = ValidatePermissionNameResult(permissionName);

            if (validatePermissionNameResult.Status == enOperationStatus.Failed)
                return validatePermissionNameResult;

            try
            {
                bool isExists = permissionID.HasValue ?
                    clsPermissionDAL.isPermissionNameExists(permissionName, permissionID.Value) :
                    clsPermissionDAL.isPermissionNameExists(permissionName);

                if (isExists)
                    return new clsOperationResult
                    {
                        Status = enOperationStatus.Failed,
                        Message = clsPermissionsValidationMessages.PermissionNameAlreadyExistsMessage,
                        PropertyName = nameof(clsPermission.PermissionName)
                    };
                else
                    return new clsOperationResult { Status = enOperationStatus.Success, PropertyName = string.Empty };
            }
            catch
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
        public static clsValidationResult ValidatePermissionCategory(string permissionCategory, int minLength, int maxLength)
        {
           if (permissionCategory.Length > 0 && permissionCategory.Length < minLength)
                return new clsValidationResult { IsValid = false, Message = "Too Short Length" };

            if (permissionCategory.Length > maxLength)
                return new clsValidationResult { IsValid = false, Message = "Out Of Length" };

            if (permissionCategory.Length > 0 && !clsValidationHelper.IsValidInputWithSpace(permissionCategory))
                return new clsValidationResult { IsValid = false, Message = "Invalid Format" };

            return new clsValidationResult { IsValid = true };
        }

        public static clsOperationResult ValidatePermissionCategoryResult(string permissionCategory)
        {
            clsValidationResult validatePermissionCategory = ValidatePermissionCategory(permissionCategory, 3, 250);

            if (!validatePermissionCategory.IsValid)
                return new clsOperationResult
                {
                    Status = enOperationStatus.Failed,
                    Message = $"> Permission Category {validatePermissionCategory.Message}. ",
                    PropertyName = nameof(clsPermission.PermissionCategory)
                };

            return new clsOperationResult { Status = enOperationStatus.Success, PropertyName = string.Empty };
        }
    }
}
