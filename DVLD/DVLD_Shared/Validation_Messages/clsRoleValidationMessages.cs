using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Shared.Validation_Messages
{
    public class clsRoleValidationMessages
    {
        public const string InvalidIDMessage = "Invalid ID Number, Enter A Valid Number.";
        public const string InvalidRoleIDMessage = "Invalid Role ID Number, Enter A Valid Number.";

        public static string RoleIsCurrentlyUseMessage = "This role is currently in use and cannot be deleted..";


        public static string RoleInfoRequiredMessage = "Role information is required.";
        public static string RoleNameRequiredMessage = "Role Name is required.";
        public static string RoleNameAleadyExsistMessage = "Role Name Already Exsist, Enter Another Role Name.";

        public static string RoleRequiredMessage = "Please select a role before saving.";
        public static string FailedToRetrieveRolesMessage = "Failed to retrieve Roles data.";
        public const string RoleNotFoundMessage = "No Role was found with the specified ID.";
        public const string RolesNameNotFoundMessage = "No Roles Name was found with the specified ID.";
        public static string DuplicateRolesMessage = "Duplicate roles are not allowed.";

        // Role Updated Messages
        public static string RoleAddedSuccessfullyMessage = "Role Added successfully.";
        public static string RoleAddFailedMessage = "Failed to Add Role.";

        // Role Updated Messages
        public static string RoleUpdatedSuccessfullyMessage = "Role Updated successfully.";
        public static string RoleUpdateFailedMessage = "Failed to Update Role.";

        // Role Deleted Messages
        public static string RoleDeletedSuccessfullyMessage = "Role Deleted successfully.";
        public static string RoleDeletedFailedMessage = "Failed to Deleted Role.";

        // Role Restored Messages
        public static string RoleRestoredSuccessfullyMessage = "Role has been restored successfully.";
        public static string RoleRestoredFailedMessage = "Failed to restored Role.";
    }
}
