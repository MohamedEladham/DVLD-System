
namespace DVLD_Shared.Validation_Messages
{
    public class clsPersonValidationMessages
    {
        public const string InvalidPersonIDMessage = "Invalid Person ID. Person ID must be greater than zero.";
        public const string PersonNotFoundMessage = "No person was found with the specified ID.";

        public static string PersonInfoRequiredMessage = "Person information is required."; 
        
        public static string PersonAddedSuccessfullyMessage = "Person added successfully.";
        public static string PersonAddFailedMessage = "Failed to add person.";
        
        public static string PersonUpdatedSuccessfullyMessage = "Person Updated successfully.";
        public static string PersonUpdatedFailedMessage = "Failed to Update person.";
        

        // Name Messages

        // Name Required Messages
        public static string FirstNameRequiredMessage = "First Name is required.";
        public static string SecondNameRequiredMessage = "Second Name is required.";
        public static string ThirdNameRequiredMessage = "Third Name is required.";
        public static string LastNameRequiredMessage = "Last Name is required.";

        
        // Name Length Messages 
        public static string FirstNameLengthValidationMessage  = "First Name must contain between 4 and 50 letters.";
        public static string SecondNameLengthValidationMessage = "Second Name must contain between 4 and 50 letters.";
        public static string ThirdNameLengthValidationMessage  = "Third Name must contain between 4 and 50 letters.";
        public static string LastNameLengthValidationMessage   = "Last Name must contain between 4 and 50 letters.";

        
        // Name Invalid Format
        public static string FirstNameInvalidFormatMessage  = "First Name contains invalid characters.";
        public static string SecondNameInvalidFormatMessage = "Second Name contains invalid characters.";
        public static string ThirdNameInvalidFormatMessage  = "Third Name contains invalid characters.";
        public static string LastNameInvalidFormatMessage   = "Last Name contains invalid characters.";

        
        // National Number Validation Messages
        public static string NationalNumberRequiredMessage = "National Number is required.";
        public static string NationalNumberTooShortMessage = "National Number is too short.";
        public static string NationalNumberOutOfLengthMessage = "National Number out of length.";
        public static string NationalNumberInvalidFormatMessage = "Please enter a valid National Number.";
        public static string NationalNumberAlreadyExistsMessage = "National Number already exists.";


        // Email Validation Messages
        public static string InvalidEmailAddressMessage = "Please enter a valid email address.";
        public static string EmailAddressAlreadyExistsMessage = "Email Address already exists.";
        public static string EmailOutOfLengthMessage = "Email out of length.";



        // Age Validation Messages
        public static string DateOfBirthInvalidMessage = "Date of birth cannot be in the future.";
        public static string PersonUnder18Message = "Person must be at least 18 years old.";
        public const  string AgeMustBeBetween18And50YearsMessage = "The person's age must be between 18 and 50 years.";


        // Phone Number Validation Messages
        public static string PhoneNumberRequiredMessage = "Phone number is required.";
        public static string InvalidPhoneNumberMessage = "Phone number is invalid.";
        public static string PhoneNumberAlreadyExistsMessage = "Phone number already exists.";


        // Address Validation Messages
        public static string AddressOutOfLengthMessage = "Address out of length.";

    }
}
