using System;
using DVLD_DAL;
using DVLD_Shared;
using DVLD_Models.LicenseClass;
using DVLD_Shared.Operations_Result;
using DVLD_Shared.Validation_Messages;
using static DVLD_Shared.Operations_Result.clsOperationResult;

namespace DVLD_BL
{
    public class clsLicenseBL
    {
        public static clsOperationResult ValidateNoActiveLicenseForClass(int personID, int licenseClassID) 
        {
            if (personID <= 0)
                return new clsOperationResult
                {
                    Status = enOperationStatus.Failed,
                    Message = clsPersonValidationMessages.PersonIDMustBeGreaterThanZeroMessage,
                    PropertyName = null
                };

            if (licenseClassID <= 0)
                return new clsOperationResult
                {
                    Status = enOperationStatus.Failed,
                    Message = clsLicenseClassValidationMessages.LicenseClassRequiredMessage,
                    PropertyName = nameof(clsLicenseClass.LicenseClassID)
                };

            try
            {
                bool exists = clsLicenseDAL.HasActiveLicenseForClass(personID, licenseClassID);

                if (exists)
                    return new clsOperationResult
                    {
                        Status = enOperationStatus.Failed,
                        Message = clsLicenseValidationMessages.PersonAlreadyHasActiveLicenseOfSelectedClass,
                        PropertyName = null
                    };
                    
                return new clsOperationResult
                {
                    Status = enOperationStatus.Success,
                    PropertyName = null
                };
            }
            catch(Exception)
            {
                return new clsOperationResult
                {
                    Status = enOperationStatus.Exception,
                    Message = clsGeneralValidationMessages.DatabaseOperationExceptionMessage,
                    PropertyName = null
                };
            }
        }
    }
}
