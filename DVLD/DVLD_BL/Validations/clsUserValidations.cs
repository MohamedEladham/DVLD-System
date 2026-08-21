using System;
using DVLD_DAL;
using DVLD_Shared;
using DVLD_Shared.Global_Classes;

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

            if (!clsValidationHelper.IsAlphaNumeric(userName))
                return new clsValidationResult { IsValid = false, Message = "Invalid Format" };

            return new clsValidationResult { IsValid = true };
        }

        public static clsValidationResult ValidateUserName(string userName, int minLength, int maxLength, int? userID = null)
        {
            if (string.IsNullOrEmpty(userName))
                return new clsValidationResult { IsValid = false, Message = "Required" };

            if (userName.Length < minLength)
                return new clsValidationResult { IsValid = false, Message = "Is Too Short Length" };

            if (userName.Length > maxLength)
                return new clsValidationResult { IsValid = false, Message = "Out Of Length" };

            if (!clsValidationHelper.IsAlphaNumeric(userName))
                return new clsValidationResult { IsValid = false, Message = "Invalid Format" };

            try
            {
                bool isUserNameExists = userID.HasValue ? 
                    clsUserDAL.IsUserNameExists(userName, userID.Value) :
                    clsUserDAL.IsUserNameExists(userName);

                if(isUserNameExists)
                    return new clsValidationResult { IsValid = false, Message = "Already Exists, Enter Another One." };

            }
            catch (Exception)
            {
                return new clsValidationResult { IsValid = false, Message = clsGeneralValidationMessages.DatabaseOperationExceptionMessage };
            }

            return new clsValidationResult { IsValid = true };
        }

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

        public static clsValidationResult ValidateConfirmPassword(string confirmPassword, string password)
        {
            if (confirmPassword != password)
                return new clsValidationResult { IsValid = false, Message = ">> The \"Confirm Password\" field must match the password." };

            return new clsValidationResult { IsValid = true };
        }
    }
}
