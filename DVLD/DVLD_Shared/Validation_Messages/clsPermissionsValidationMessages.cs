using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Shared.Validation_Messages
{
    public class clsPermissionsValidationMessages
    {
        public const string InvalidIDMessage = "Invalid ID Number, Enter A Valid Number.";
        public const string InvalidPermissionIDMessage = "Invalid Permission ID Number, Enter A Valid Number.";

        public const string PermissionNotFoundMessage = "No Permission was found with the specified ID.";

        public static string PermissionNameAlreadyExistsMessage = "Permission Name already exists.";
        public static string PermissionIsCurrentlyUseMessage = "This permission is currently in use and cannot be deactivated.."; 


        public static string PermissionDeniedMessage = "You do not have permission to perform this operation.";
        public static string PermissionInfoRequiredMessage = "Permission information is required.";
        public static string DuplicatePermissionsMessage = "Duplicate Permissions are not allowed.";
        public static string FailedToRetrievePermissionsMessage = "Failed to retrieve Permissions data.";


        // Permission Added Messages
        public static string PermissionAddedSuccessfullyMessage = "Permission added successfully.";
        public static string PermissionAddFailedMessage = "Failed to add permission.";

        // Permission Updated Messages
        public static string PermissionUpdatedSuccessfullyMessage = "Permission Updated successfully.";
        public static string PermissionUpdatedFailedMessage = "Failed to Update Permission.";

        // Permission Inactivated Messages
        public static string PermissionInactivatedSuccessfullyMessage = "Permission Inactivated successfully.";
        public static string PermissionInactivatedFailedMessage = "Failed to Inactivated Permission.";

        // Permission Activated Messages
        public static string PermissionActivatedSuccessfullyMessage = "Permission Activated successfully.";
        public static string PermissionActivatedFailedMessage = "Failed to Activated Permission.";

    }
}
