using DVLD_BL.Validations;
using DVLD_DAL;
using DVLD_Models;
using DVLD_Shared;
using DVLD_Shared.Global_Classes;
using DVLD_Shared.Operations_Result;
using DVLD_Shared.Validation_Messages;
using System;
using static DVLD_Shared.Operations_Result.clsOperationResult;


namespace DVLD_BL.Validations
{
    public class clsPersonValidations
    {
        public static clsValidationResult ValidatePersonID(string value)
        {
            if (string.IsNullOrEmpty(value))
                return new clsValidationResult { IsValid = false, Message = clsPersonValidationMessages.PersonIDRequiredMessage };

            if (!int.TryParse(value, out int personID))
                return new clsValidationResult { IsValid = false, Message = clsPersonValidationMessages.InvalidPersonIDMessage };

            if (personID <= 0)
                return new clsValidationResult { IsValid = false, Message = clsPersonValidationMessages.PersonIDMustBeGreaterThanZeroMessage };

            return new clsValidationResult { IsValid = true, ID = personID};
        }

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

        private static clsOperationResult GetValidateNameResult(string name, string lable, string propertyName)
        {
            clsValidationResult validateNameResult = ValidateName(name, 3, 50);

            if (!validateNameResult.IsValid)
                return new clsOperationResult
                {
                    Status = enOperationStatus.Failed,
                    Message = $"> {lable} {validateNameResult.Message}. ",
                    PropertyName = propertyName
                };


            return new clsOperationResult { Status = enOperationStatus.Success, PropertyName = string.Empty };
        }

        public static clsOperationResult ValidateFullName(string firstName, string secondName, string thirdName, string lastdName)
        {
            clsOperationResult validateFirstNameResult = GetValidateNameResult(firstName, "> First Name3", nameof(clsPerson.FirstName));

            if (validateFirstNameResult.Status == enOperationStatus.Failed)
                return validateFirstNameResult;

            // >>
            clsOperationResult validateSecondNameResult = GetValidateNameResult(secondName, "> Second Name", nameof(clsPerson.SecondName));

            if (validateSecondNameResult.Status == enOperationStatus.Failed)
                return validateSecondNameResult;

            // >>
            clsOperationResult validateThirdNameResult = GetValidateNameResult(thirdName, "> Third Name", nameof(clsPerson.ThirdName));

            if (validateThirdNameResult.Status == enOperationStatus.Failed)
                return validateThirdNameResult;

            // >>
            clsOperationResult validateLastNameResult = GetValidateNameResult(lastdName, "> Last Name", nameof(clsPerson.LastName));

            if (validateLastNameResult.Status == enOperationStatus.Failed)
                return validateLastNameResult;

            // >>
            return new clsOperationResult
            {
                Status = enOperationStatus.Success,
                PropertyName = string.Empty
            };
        }


        // >>

        public static clsValidationResult ValidateNationalNumber(string nationalNumber, int minLength = 2, int maxLength = 50)
        {
            if (string.IsNullOrWhiteSpace(nationalNumber))
                return new clsValidationResult { IsValid = false, Message = clsPersonValidationMessages.NationalNumberRequiredMessage };

            if (!clsValidationHelper.IsAlphaNumeric(nationalNumber))
                return new clsValidationResult { IsValid = false, Message = clsPersonValidationMessages.NationalNumberInvalidFormatMessage };

            if (nationalNumber.Length < minLength)
                return new clsValidationResult { IsValid = false, Message = clsPersonValidationMessages.NationalNumberTooShortMessage };

            if (nationalNumber.Length > maxLength)
                return new clsValidationResult { IsValid = false, Message = clsPersonValidationMessages.NationalNumberOutOfLengthMessage };

            return new clsValidationResult { IsValid = true };
        }

        public static clsOperationResult ValidateNationalNumberAndCheckIsExists(string nationalNumber)
        {
            string propertyName = nameof(clsPerson.NationalNO);

            int minLength = 2, maxLength = 50;

            clsValidationResult validationResult = ValidateNationalNumber(nationalNumber, minLength, maxLength);

            if(!validationResult.IsValid)
                return new clsOperationResult { 
                    Status = enOperationStatus.Failed,
                    Message = validationResult.Message,
                    PropertyName = propertyName };

            try
            {
                bool exists = clsPersonDAL.NationalNumberExists(nationalNumber);

                if (exists)
                    return new clsOperationResult { 
                        Status = enOperationStatus.Failed,
                        Message = clsPersonValidationMessages.NationalNumberAlreadyExistsMessage,
                        PropertyName = propertyName }; 
                else
                    return new clsOperationResult { Status = enOperationStatus.Success, PropertyName = string.Empty };
            }
            catch
            {
                return new clsOperationResult { 
                    Status = enOperationStatus.Exception,
                    Message = clsGeneralValidationMessages.DatabaseOperationExceptionMessage,
                    PropertyName = string.Empty };
            }
        }

        // >>

        public static clsValidationResult ValidateEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return new clsValidationResult { IsValid = true };

            if (email.Length > 500)
                return new clsValidationResult { IsValid = false, Message = clsPersonValidationMessages.EmailOutOfLengthMessage };

            if (!clsValidationHelper.IsValidEmail(email))
                return new clsValidationResult { IsValid = false, Message = clsPersonValidationMessages.InvalidEmailAddressMessage };
           
            return new clsValidationResult { IsValid = true };
        }

        public static clsOperationResult ValidateEmailAndCheckIsExists(string email, int? personID = null)
        {
            string propertyName = nameof(clsPerson.Email);

            clsValidationResult validationResult = ValidateEmail(email);

            if (!validationResult.IsValid)
                return new clsOperationResult{
                    Status = enOperationStatus.Failed,
                    Message = validationResult.Message,
                    PropertyName = propertyName };

            try
            {
                bool exists = personID.HasValue ?
                    clsPersonDAL.EmailExists(email, personID.Value) :
                    clsPersonDAL.EmailExists(email);

                if (exists)
                    return new clsOperationResult {
                        Status = enOperationStatus.Failed,
                        Message = clsPersonValidationMessages.EmailAddressAlreadyExistsMessage,
                        PropertyName = propertyName };
                else
                    return new clsOperationResult { 
                        Status = enOperationStatus.Success,
                        PropertyName = string.Empty };
            }
            catch
            {
                return new clsOperationResult{
                    Status = enOperationStatus.Exception,
                    Message = clsGeneralValidationMessages.DatabaseOperationExceptionMessage,
                    PropertyName = string.Empty};
            }
        }

        // >>

        public static bool IsPersonOldEnough(DateTime dateOfBirth, int minimumAllowedAge)
        {
            DateTime today = DateTime.Today;

            int age = today.Year - dateOfBirth.Year;

            if (dateOfBirth.Date > today.AddYears(-age))
                age--;

            return age >= minimumAllowedAge;
        }

        public static clsValidationResult ValidateAge(DateTime dateOfBirth, int minAge, int maxAge)
        {
            if (dateOfBirth > clsValidationHelper.GetToDayDate())
                return new clsValidationResult { IsValid = false, Message = clsPersonValidationMessages.DateOfBirthInvalidMessage };


            if (!clsValidationHelper.IsValidAgeRange(dateOfBirth, minAge, maxAge))
                return new clsValidationResult { IsValid = false, Message = clsPersonValidationMessages.AgeMustBeBetween18And50YearsMessage };

            return new clsValidationResult { IsValid = true };
        }

        public static clsOperationResult ValidateAgeResult(DateTime dateOfBirth) 
        {
            string propertyName = nameof(clsPerson.DateOfBirth);

            int minAge = 18, maxAge = 50;

            clsValidationResult validateAgeResult = ValidateAge(dateOfBirth, minAge, maxAge);

            if (!validateAgeResult.IsValid)
                return new clsOperationResult{
                    Status = enOperationStatus.Failed,
                    Message = validateAgeResult.Message,
                    PropertyName = propertyName};


            return new clsOperationResult {
                Status = enOperationStatus.Success,
                PropertyName = string.Empty };
        }


        // >>

        public static clsValidationResult ValidatePhone(string phoneNumber, int? personID = null)
        {
            if (string.IsNullOrWhiteSpace(phoneNumber))
                return new clsValidationResult { IsValid = false, Message = clsPersonValidationMessages.PhoneNumberRequiredMessage };

            if (!clsValidationHelper.IsValidPhoneNumber(phoneNumber))
                return new clsValidationResult { IsValid = false, Message = clsPersonValidationMessages.InvalidPhoneNumberMessage };

            return new clsValidationResult { IsValid = true };
        }

        public static clsOperationResult ValidatePhoneAndCheckIsExists(string phone, int? personID = null)
        {
            string propertyName = nameof(clsPerson.Phone);

            clsValidationResult validationResult = ValidatePhone(phone);

            if (!validationResult.IsValid)
                return new clsOperationResult
                {
                    Status = enOperationStatus.Failed,
                    Message = validationResult.Message,
                    PropertyName = propertyName
                };

            try
            {
                bool exists = personID.HasValue ?
                    clsPersonDAL.PhoneExists(phone, personID.Value) :
                    clsPersonDAL.PhoneExists(phone);

                if (exists)
                    return new clsOperationResult
                    {
                        Status = enOperationStatus.Failed,
                        Message = clsPersonValidationMessages.PhoneNumberAlreadyExistsMessage,
                        PropertyName = propertyName
                    };
                else
                    return new clsOperationResult
                    {
                        Status = enOperationStatus.Success,
                        PropertyName = string.Empty
                    };
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

        public static clsValidationResult ValidateAddress(string address, int maxLength)
        {
            if (address.Length > maxLength)
                return new clsValidationResult { IsValid = false, Message = clsPersonValidationMessages.AddressOutOfLengthMessage };

            return new clsValidationResult { IsValid = true };
        }

        public static clsOperationResult ValidateAddressResult(string address)
        {
            string propertyName = nameof(clsPerson.Address);

            int maxLength = 1000;

            clsValidationResult validateAgeResult = ValidateAddress(address, maxLength);

            if (!validateAgeResult.IsValid)
                return new clsOperationResult
                {
                    Status = enOperationStatus.Failed,
                    Message = validateAgeResult.Message,
                    PropertyName = propertyName
                };


            return new clsOperationResult
            {
                Status = enOperationStatus.Success,
                PropertyName = string.Empty
            };
        }
    }
}
