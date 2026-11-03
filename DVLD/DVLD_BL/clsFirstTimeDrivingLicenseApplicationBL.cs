using DVLD_BL.Validations;
using DVLD_Models.Application;
using DVLD_Models.LicenseClass;
using DVLD_Shared;
using DVLD_Shared.Operations_Result;
using DVLD_Shared.Validation_Messages;
using System;
using static DVLD_Shared.Global_Enums.clsEnumHelpers;
using static DVLD_Shared.Operations_Result.clsOperationResult;

namespace DVLD_BL
{
    public class clsFirstTimeDrivingLicenseApplicationBL
    {
        private static clsOperationResult _ValidateNoNewApplicationForPersonAndService(int personID, int serviceID)
        {
            return clsApplicationBL.ValidateNoNewApplicationForPersonAndService(personID, serviceID);
        }

        private static clsOperationResult _ValidateNoActiveLicenseForClass(int personID, int licenseClassID)
        {
            return clsLicenseBL.ValidateNoActiveLicenseForClass(personID, licenseClassID);
        }

        private static clsOperationResult _IsPersonOldEnough(int personID, int licenseClassID)
        {
            (clsOperationResult personDateOfBirthResult, DateTime? personDateOfBirth) = clsPersonBL.GetPersonDateOfBirth(personID);

            switch (personDateOfBirthResult.Status)
            {
                case enOperationStatus.Failed:
                    return new clsOperationResult
                    {
                        Status = enOperationStatus.Failed,
                        Message = personDateOfBirthResult.Message,
                        PropertyName = null
                    };

                case enOperationStatus.Exception:
                    return new clsOperationResult
                    {
                        Status = enOperationStatus.Exception,
                        Message = personDateOfBirthResult.Message,
                        PropertyName = null
                    };
            }


            (clsOperationResult minimumAllowedAgeResult, byte? minimumAllowedAge) = clsLicenseClassBL.GetMinimumAllowedAgeForLicenseClass(licenseClassID);

            switch (minimumAllowedAgeResult.Status)
            {
                case enOperationStatus.Failed:
                    return new clsOperationResult
                    {
                        Status = enOperationStatus.Failed,
                        Message = minimumAllowedAgeResult.Message,
                        PropertyName = null
                    };

                case enOperationStatus.Exception:
                    return new clsOperationResult
                    {
                        Status = enOperationStatus.Exception,
                        Message = minimumAllowedAgeResult.Message,
                        PropertyName = null
                    };
            }


            if (!personDateOfBirth.HasValue || !minimumAllowedAge.HasValue)
            {
                return new clsOperationResult
                {
                    Status = enOperationStatus.Failed,
                    Message = "Unable to validate the condition because required data is missing.",
                    PropertyName = null
                };
            }


            if (!clsPersonValidations.IsPersonOldEnough(personDateOfBirth.Value, minimumAllowedAge.Value))
                return new clsOperationResult
                {
                    Status = enOperationStatus.Failed,
                    Message = clsPersonValidationMessages.PersonAgeNotAllowedMessage,
                    PropertyName = null
                };

            return new clsOperationResult
            {
                Status = enOperationStatus.Success,
                PropertyName = null
            };
        }

        private static clsOperationResult _ValidateApplicationPaidFees(int serviceID, decimal applicationPaidFees) 
        {
            (clsOperationResult result, decimal? requiredApplicationFees) = clsServiceBL.GetApplicationFeesByServiceID(serviceID);

            switch (result.Status)
            {
                case enOperationStatus.Failed:
                    return new clsOperationResult
                    {
                        Status = enOperationStatus.Failed,
                        Message = result.Message,
                        PropertyName = null
                    };

                case enOperationStatus.Exception:
                    return new clsOperationResult
                    {
                        Status = enOperationStatus.Exception,
                        Message = result.Message,
                        PropertyName = null
                    };
            }

            if (!requiredApplicationFees.HasValue)
            {
                return new clsOperationResult
                {
                    Status = enOperationStatus.Failed,
                    Message = "Unable to validate the condition because required data is missing.",
                    PropertyName = null
                };
            }

            if (applicationPaidFees != requiredApplicationFees.Value) 
                return new clsOperationResult
                {
                    Status = enOperationStatus.Failed,
                    Message = clsApplicationValidationMessages.InvalidApplicationPaidFeesMessage,
                    PropertyName = nameof(clsApplication.ApplicationPaidFees)
                };

            return new clsOperationResult
            {
                Status = enOperationStatus.Success,
                PropertyName = null
            };
        }

        public static clsOperationResult AddFirstTimeDrivingLicenseApplication(int personID, int serviceID, int licenseClassID, string applicationPaidFeesString)
        {
            if (personID <= 0)
                return new clsOperationResult
                {
                    Status = enOperationStatus.Failed,
                    Message = clsPersonValidationMessages.PersonIDMustBeGreaterThanZeroMessage,
                    PropertyName = null
                };

            if (serviceID <= 0)
                return new clsOperationResult
                {
                    Status = enOperationStatus.Failed,
                    Message = clsServiceValidationMessages.ServiceIDMustBeGreaterThanZeroMessage,
                    PropertyName = null
                };

            if (serviceID != (int)enServices.FirstTimeLicenseIssuance)
                return new clsOperationResult
                {
                    Status = enOperationStatus.Failed,
                    Message = clsServiceValidationMessages.ServiceIDNotCompatibleWithOperationMessage,
                    PropertyName = null
                };

            if (licenseClassID <= 0)
                return new clsOperationResult
                {
                    Status = enOperationStatus.Failed,
                    Message = clsLicenseClassValidationMessages.LicenseClassRequiredMessage,
                    PropertyName = nameof(clsLicenseClass.LicenseClassID)
                };

            if (string.IsNullOrWhiteSpace(applicationPaidFeesString))
                return new clsOperationResult
                {
                    Status = enOperationStatus.Failed,
                    Message = clsApplicationValidationMessages.ApplicationPaidFeesRequiredMessage,
                    PropertyName = nameof(clsApplication.ApplicationPaidFees)
                };

            if (!decimal.TryParse(applicationPaidFeesString, out decimal applicationPaidFees))
                return new clsOperationResult
                {
                    Status = enOperationStatus.Failed,
                    Message = clsApplicationValidationMessages.InvalidApplicationPaidFeesValueMessage,
                    PropertyName = nameof(clsApplication.ApplicationPaidFees)
                };


            clsOperationResult validateNoNewApplicationForPersonAndServiceResult =
                _ValidateNoNewApplicationForPersonAndService(personID, serviceID);

            if (validateNoNewApplicationForPersonAndServiceResult.Status == enOperationStatus.Failed ||
                validateNoNewApplicationForPersonAndServiceResult.Status == enOperationStatus.Exception)
                return validateNoNewApplicationForPersonAndServiceResult;


            clsOperationResult validateNoActiveLicenseForClassResult =
               _ValidateNoActiveLicenseForClass(personID, licenseClassID);

            if (validateNoActiveLicenseForClassResult.Status == enOperationStatus.Failed ||
                validateNoActiveLicenseForClassResult.Status == enOperationStatus.Exception)
                return validateNoActiveLicenseForClassResult;


            clsOperationResult isPersonOldEnoughResult =
                _IsPersonOldEnough(personID, licenseClassID);

            if (isPersonOldEnoughResult.Status == enOperationStatus.Failed ||
                isPersonOldEnoughResult.Status == enOperationStatus.Exception)
                return isPersonOldEnoughResult;


            clsOperationResult validateApplicationPaidFeesResult =
                _ValidateApplicationPaidFees(serviceID, applicationPaidFees);

            if (validateApplicationPaidFeesResult.Status == enOperationStatus.Failed ||
                validateApplicationPaidFeesResult.Status == enOperationStatus.Exception)
                return validateApplicationPaidFeesResult;


            return clsApplicationBL.AddNewFirstTimeDrivingLicenseApplication(personID, applicationPaidFees, licenseClassID);
        }
    }
}
