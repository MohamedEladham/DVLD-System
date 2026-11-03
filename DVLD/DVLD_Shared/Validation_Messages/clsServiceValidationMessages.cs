using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Shared.Validation_Messages
{
    public class clsServiceValidationMessages
    {
        public const string ServiceIDMustBeGreaterThanZeroMessage = "Invalid Service ID. Service ID must be greater than zero.";
        public const string InvalidServiceIDMessage = "Invalid service ID, enter A valid ID.";
        public const string ServiceNotFoundMessage = "No service was found with the specified ID.";
        public const string ServiceIDNotCompatibleWithOperationMessage = "The specified service ID is not compatible with this operation.";
        
    }
}
