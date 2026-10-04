using System;
using DVLD_DAL;
using DVLD_Models;
using DVLD_Models.User;
using DVLD_Shared;
using DVLD_Shared.Global_Classes;
using DVLD_Shared.Operations_Result;
using DVLD_Shared.Validation_Messages;
using static DVLD_Shared.Operations_Result.clsOperationResult;

namespace DVLD_BL.Validations
{
    public class clsUserValidations
    {
        public static clsValidationResult IsValidUserName(string userName, int minLength, int maxLength)
        {
            if (string.IsNullOrEmpty(userName))
                return new clsValidationResult { IsValid = false, Message = "Required" };

            if (userName.Length < minLength)
                return new clsValidationResult { IsValid = false, Message = "Is Too Short Length" };

            if (userName.Length > maxLength)
                return new clsValidationResult { IsValid = false, Message = "Out Of Length" };

            if (!clsValidationHelper.IsValidInputWithSpace(userName))
                return new clsValidationResult { IsValid = false, Message = "Invalid Format" };

            return new clsValidationResult { IsValid = true };
        }
        
        public static clsOperationResult ValidateUserNameAndCheckIsExists(string userName, int? userID = null)
        {
            string propertyName = nameof(clsUser.UserName);

            clsValidationResult validateUserNameResult = IsValidUserName(userName, 3, 200);

            if (!validateUserNameResult.IsValid)
                return new clsOperationResult
                {
                    Status = enOperationStatus.Failed,
                    Message = $"> User Name {validateUserNameResult.Message}. ",
                    PropertyName = propertyName
                };

            try
            {
                bool isUserNameExists = userID.HasValue ? 
                    clsUserDAL.IsUserNameExists(userName, userID.Value) :
                    clsUserDAL.IsUserNameExists(userName);

                if(isUserNameExists)
                    return new clsOperationResult
                    {
                        Status = enOperationStatus.Failed,
                        Message = clsUserValidationMessages.UserNameAlreadyExistsMessage,
                        PropertyName = propertyName
                    };

                return new clsOperationResult
                {
                    Status = enOperationStatus.Success,
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
        public static clsValidationResult ValidatePassword(string password, int minLength, int maxLength)
        {
            if (string.IsNullOrEmpty(password))
                return new clsValidationResult { IsValid = false, Message = "Required" };

            if (password.Length < minLength)
                return new clsValidationResult { IsValid = false, Message = "Is Too Short Length" };

            if (password.Length > maxLength)
                return new clsValidationResult { IsValid = false, Message = "Out Of Length" };

            return new clsValidationResult { IsValid = true };
        }

        public static clsOperationResult ValidatePasswordResult(string password)
        {
            string propertyName = nameof(clsUser.Password);

            clsValidationResult validatePasswordResult = ValidatePassword(password, 3, 500);

            if (!validatePasswordResult.IsValid)
                return new clsOperationResult
                {
                    Status = enOperationStatus.Failed,
                    Message = $"> Password {validatePasswordResult.Message}. ",
                    PropertyName = propertyName
                };

            return new clsOperationResult { Status = enOperationStatus.Success, PropertyName = string.Empty };
        }

        
        // >>
        public static clsValidationResult ValidateConfirmPassword(string confirmPassword, string password)
        {
            if (confirmPassword != password)
                return new clsValidationResult { IsValid = false, Message = ">> The \"Confirm Password\" field must match the confirmPassword." };

            return new clsValidationResult { IsValid = true };
        }

        public static clsOperationResult ValidateConfirmPasswordResult(string confirmPassword, string password)
        {
            string propertyName = "ConfirmPassword";

            clsValidationResult validateConfirmPasswordResult = ValidateConfirmPassword(confirmPassword, password);

            if (!validateConfirmPasswordResult.IsValid)
                return new clsOperationResult
                {
                    Status = enOperationStatus.Failed,
                    Message = validateConfirmPasswordResult.Message,
                    PropertyName = propertyName
                };

            return new clsOperationResult { Status = enOperationStatus.Success, PropertyName = string.Empty };
        }
    }
}
