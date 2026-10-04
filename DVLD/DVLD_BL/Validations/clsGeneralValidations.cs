using DVLD_Shared.Global_Classes;
using DVLD_Shared.Operations_Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DVLD_Shared.Operations_Result.clsOperationResult;

namespace DVLD_BL.Validations
{
    public class clsGeneralValidations
    {
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

        public static clsOperationResult ValidateNameResult(string name, string lable, string propertyName, int minLength, int maxLength)
        {
            clsValidationResult validateNameResult = ValidateName(name, minLength, maxLength);

            if (!validateNameResult.IsValid)
                return new clsOperationResult
                {
                    Status = enOperationStatus.Failed,
                    Message = $"> {lable} {validateNameResult.Message}. ",
                    PropertyName = propertyName
                };


            return new clsOperationResult { Status = enOperationStatus.Success, PropertyName = string.Empty };
        }

    }
}
