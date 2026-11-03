using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Shared.Validation_Messages
{
    public class clsLicenseClassValidationMessages
    {
        public const string FailedToRetrieveLicenseClassesInfodMessage = "Failed to retrieve license classes data.";

        public static string LicenseClassIDMustBeGreaterThanZeroMessage = "Invalid license class ID. license class ID must be greater than zero.";
        public static string LicenseClassNotFoundMessage = "No license class were found with the specified ID.";
        public static string LicenseClassRequiredMessage = "Please Select the License Class.";
        public static string MinimumAgeForLicenseClassMustBeGreaterThanZeroMessage = "The minimum age for the license class must be greater than zero.";

    }
}
