using DVLD_DAL;
using DVLD_Models.Role;
using DVLD_Models.User;
using DVLD_Shared.Global_Classes;
using DVLD_Shared.Operations_Result;
using DVLD_Shared.Validation_Messages;
using DVLD_Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DVLD_Shared.Operations_Result.clsOperationResult;
using DVLD_Models.LicenseClass;

namespace DVLD_BL
{
    public class clsLicenseClassBL
    {
        public static (clsOperationResult, byte?) GetMinimumAllowedAgeForLicenseClass(int licenseClassID)
        {
            if (licenseClassID <= 0)
                return (new clsOperationResult
                {
                    Status = enOperationStatus.Failed,
                    Message = clsLicenseClassValidationMessages.LicenseClassIDMustBeGreaterThanZeroMessage
                }, null);

            try
            {
                byte? minimumAllowedAge = clsLicenseClassDAL.GetMinimumAllowedAgeForLicenseClass(licenseClassID);

                if (minimumAllowedAge != null)
                    return (new clsOperationResult { Status = enOperationStatus.Success }, minimumAllowedAge);
                else
                    return (new clsOperationResult
                    {
                        Status = enOperationStatus.Failed,
                        Message = clsLicenseClassValidationMessages.LicenseClassNotFoundMessage
                    }, null);
            }
            catch (Exception)
            {
                return (new clsOperationResult
                {
                    Status = enOperationStatus.Exception,
                    Message = clsGeneralValidationMessages.DatabaseOperationExceptionMessage
                }, null);
            }
        }

        public static (clsOperationResult, List<clsLicenseClass>) GetAllActiveLicenseClassesBasicInfo()
        {
            try
            {
                List<clsLicenseClass> licenseClasses = clsLicenseClassDAL.GetAllActiveLicenseClassesBasicInfo();

                if(licenseClasses != null && licenseClasses.Count > 0)
                    return (new clsOperationResult { Status = enOperationStatus.Success }, licenseClasses);
                else
                    return (new clsOperationResult
                    { 
                        Status = enOperationStatus.Failed,
                        Message = clsLicenseClassValidationMessages.FailedToRetrieveLicenseClassesInfodMessage
                    }, null);
            }
            catch
            {
                return (new clsOperationResult
                {
                    Status = enOperationStatus.Exception,
                    Message = clsGeneralValidationMessages.DatabaseOperationExceptionMessage
                }, null);
            }
        }
    }
}
