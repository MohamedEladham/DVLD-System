using DVLD_BL.Validations;
using DVLD_DAL;
using DVLD_Shared;
using DVLD_Shared.Global_Classes;
using DVLD_Shared.Validation_Messages;
using System;


namespace DVLD_BL.Validations
{
    public class clsPersonValidations
    {
        public static clsValidationResult ValidateName(string name, int minLength, int maxLength)
        {
            if (string.IsNullOrEmpty(name))
                return new clsValidationResult { IsValid = false, Message = "Required" };

            if (name.Length < minLength)
                return new clsValidationResult { IsValid = false, Message = "Is Too Short Length" };

            if (name.Length > maxLength)
                return new clsValidationResult { IsValid = false, Message = "Out Of Length" };

            if (!clsValidationHelper.IsAlphaNumeric(name))
                return new clsValidationResult { IsValid = false, Message = "Invalid Format" };

            return new clsValidationResult { IsValid = true };
        }

        public static clsValidationResult ValidateNationalNumber(string nationalNumber, int minLength, int maxLength)
        {
            if (string.IsNullOrWhiteSpace(nationalNumber))
                return new clsValidationResult { IsValid = false, Message = clsPersonValidationMessages.NationalNumberRequiredMessage };

            if (!clsValidationHelper.IsAlphaNumeric(nationalNumber))
                return new clsValidationResult { IsValid = false, Message = clsPersonValidationMessages.NationalNumberInvalidFormatMessage };

            if (nationalNumber.Length < minLength)
                return new clsValidationResult { IsValid = false, Message = clsPersonValidationMessages.NationalNumberTooShortMessage };

            if (nationalNumber.Length > maxLength)
                return new clsValidationResult { IsValid = false, Message = clsPersonValidationMessages.NationalNumberOutOfLengthMessage };

            try
            {
                bool exists = clsPersonDAL.NationalNumberExists(nationalNumber);

                if (exists)
                    return new clsValidationResult { IsValid = false, Message = clsPersonValidationMessages.NationalNumberAlreadyExistsMessage };
                else
                    return new clsValidationResult { IsValid = true, Message = "" };
            }
            catch
            {
                return new clsValidationResult { IsValid = false, Message = clsGeneralValidationMessages.DatabaseOperationExceptionMessage };
            }
        }

        public static clsValidationResult ValidateEmail(string email, int maxLength, int? personID = null)
        {
            if (string.IsNullOrWhiteSpace(email))
                return new clsValidationResult { IsValid = true };

            if (!clsValidationHelper.IsValidEmail(email))
                return new clsValidationResult { IsValid = false, Message = clsPersonValidationMessages.InvalidEmailAddressMessage };
            
            if (email.Length > maxLength)
                return new clsValidationResult { IsValid = false, Message = clsPersonValidationMessages.EmailOutOfLengthMessage };

            try
            {
                bool exists = personID.HasValue ? clsPersonDAL.EmailExists(email, personID.Value) : clsPersonDAL.EmailExists(email);

                if (exists)
                    return new clsValidationResult { IsValid = false, Message = clsPersonValidationMessages.EmailAddressAlreadyExistsMessage };
                else
                    return new clsValidationResult { IsValid = true };
            }
            catch
            {
                return new clsValidationResult { IsValid = false, Message = clsGeneralValidationMessages.DatabaseOperationExceptionMessage };
            }
        }

        public static clsValidationResult ValidateAge(DateTime dateOfBirth, int minAge, int maxAge)
        {
            if (dateOfBirth > clsValidationHelper.GetToDayDate())
                return new clsValidationResult { IsValid = false, Message = clsPersonValidationMessages.DateOfBirthInvalidMessage };

            if (!clsValidationHelper.IsValidAgeRange(dateOfBirth, minAge, maxAge))
                return new clsValidationResult { IsValid = false, Message = clsPersonValidationMessages.AgeMustBeBetween18And50YearsMessage };

            return new clsValidationResult { IsValid = true };
        }

        public static clsValidationResult ValidatePhone(string phoneNumber, int? personID = null)
        {
            if (string.IsNullOrWhiteSpace(phoneNumber))
                return new clsValidationResult { IsValid = false, Message = clsPersonValidationMessages.PhoneNumberRequiredMessage };

            if (!clsValidationHelper.IsValidPhoneNumber(phoneNumber))
                return new clsValidationResult { IsValid = false, Message = clsPersonValidationMessages.InvalidPhoneNumberMessage };

            try
            {
                bool exists = personID.HasValue ? clsPersonDAL.PhoneExists(phoneNumber, personID.Value) : clsPersonDAL.PhoneExists(phoneNumber);

                if (exists)
                    return new clsValidationResult { IsValid = false, Message = clsPersonValidationMessages.PhoneNumberAlreadyExistsMessage };
                else
                    return new clsValidationResult { IsValid = true };
            }
            catch
            {
                return new clsValidationResult { IsValid = false, Message = clsGeneralValidationMessages.DatabaseOperationExceptionMessage };
            }
        }

        public static clsValidationResult ValidateAddress(string address, int maxLength)
        {
            if (address.Length > maxLength)
                return new clsValidationResult { IsValid = false, Message = clsPersonValidationMessages.AddressOutOfLengthMessage };

            return new clsValidationResult { IsValid = true };
        }
    }
}
