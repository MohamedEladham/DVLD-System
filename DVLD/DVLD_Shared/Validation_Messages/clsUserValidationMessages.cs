using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Shared.Validation_Messages
{
    public class clsUserValidationMessages
    {
        public const string InvalidUserIDMessage = "Invalid ID Number, Enter A Valid Number.";
        public const string UserIDMustBeGreaterThanZeroMessage = "Invalid user id, user id must be greater than zero.";
        public const string UserNotFoundMessage = "No User was found with the specified ID.";
        public static string UserInfoRequiredMessage = "User information is required.";

        // Current Password
        public const string CurrentPasswordRequiredMessage = "Please enter your current password for verification.";
        public const string CurrentPasswordVerified = "Current password verified successfully.....";
        public const string InvalidCurrentPassword = "The current password you entered is incorrect....";

        // User Added Messages
        public static string UserAddedSuccessfullyMessage = "User added successfully.";
        public static string UserAddFailedMessage = "Failed to add User.";

        // Update Password Messages
        public static string NewPasswordRequiredMessage  = "Please enter your New password to updated.";
        public static string PasswordUpdatedSuccessfullyMessage = "Password Updated successfully.";
        public static string PasswordUpdatedFailedMessage = "Failed to Update Password.";

        // User Updated Messages
        public static string UserUpdatedSuccessfullyMessage = "User Updated successfully.";
        public static string UserUpdatedFailedMessage = "Failed to Update User.";

        // User Activated
        public static string UserActivatedSuccessfullyMessage = "User has been activated successfully.";
        public static string UserActivationFailedMessage = "Failed to activate user.";

        // User Activated
        public static string UserRestoredSuccessfullyMessage = "User has been restored successfully.";
        public static string UserRestoredFailedMessage = "Failed to restored user.";

        // User Updated Messages
        public static string UserDeletedSuccessfullyMessage = "User Deleted successfully.";
        public static string UserDeletedFailedMessage = "Failed to Deleted User.";


        // Login Process Messages
        public static string LoginSuccessfulMessage = "Login process successfully....";
        public static string LoginFailedMessage = "Login process failed.";
        public static string InvalidUserNameOrPasswordMessage = "Invalid username or password.";

    }
}
