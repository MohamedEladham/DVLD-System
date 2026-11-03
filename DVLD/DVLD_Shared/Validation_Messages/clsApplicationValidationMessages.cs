using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Shared.Validation_Messages
{
    public class clsApplicationValidationMessages
    {
        public static string CannotSaveEmptyApplication = "Cannot save the application because no application information was provided.";
        public static string FailedToRetrieveApplicationMessage = "Failed to retrieve Application data.";

        public static string InvalidApplicationPaidFeesMessage = "The application paid fees must equal the required fees for the selected license class.";
        public static string ApplicationPaidFeesRequiredMessage = "Please enter the application paid fees.";
        public static string InvalidApplicationPaidFeesValueMessage = "The application paid fees must contain a valid numeric value.";
        public static string ApplicationFeesNotFoundMessage = "Application fees were not found.";
        public static string ApplicationFeesNotSetMessage = "Application fees have not been set for this service yet.";

        public const string NewApplicationAlreadyExistsMessage =
    "Cannot create this application because a new application for the same service already exists for this person.";

        public static string ApplicationSavedSuccessfully = "Application has been saved successfully.";
        public static string ApplicationSaveFailed = "Failed to save the application. Please try again.";
        public static string ApplicationSaveException = "An unexpected error occurred while saving the application.";
    }
}
