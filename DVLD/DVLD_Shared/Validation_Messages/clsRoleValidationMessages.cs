using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Shared.Validation_Messages
{
    public class clsRoleValidationMessages
    {
        public const string InvalidRoleIDMessage = "Invalid Role ID Number, Enter A Valid Number.";
        public static string RoleRequiredMessage = "Please select a role before saving.";
        public static string FailedToRetrieveRolsMessage = "Failed to retrieve Roles data.";
        public const string RoleNotFoundMessage = "No Role was found with the specified ID.";
        public const string RolesNameNotFoundMessage = "No Roles Name was found with the specified ID.";

    }
}
