using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Shared.Validation_Messages
{
    public class clsCountryValidationMessages
    {
        public static string InvalidCountryIdMessage = "Country ID must be greater than zero.";
        public static string FailedToRetrieveCountriesMessage = "Failed to retrieve countries data.";
    }
}
