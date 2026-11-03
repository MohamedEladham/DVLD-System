using System;
using DVLD_DAL;
using DVLD_Shared;
using DVLD_Models.Application;
using System.Collections.Generic;
using DVLD_Shared.Operations_Result;
using DVLD_Shared.Validation_Messages;
using static DVLD_Shared.Global_Enums.clsEnumHelpers;
using static DVLD_Shared.Operations_Result.clsOperationResult;
using DVLD_Models.LicenseClass;

namespace DVLD_BL
{
    public class clsApplicationBL
    {
        public static clsOperationResult ValidateNoNewApplicationForPersonAndService(int personID, int serviceID)
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

            try 
            {
                bool exists = clsApplicationDAL.HasNewApplicationForPersonAndService(personID, serviceID);

                if (exists)
                    return new clsOperationResult
                    {
                        Status = enOperationStatus.Failed,
                        Message = clsApplicationValidationMessages.NewApplicationAlreadyExistsMessage,
                        PropertyName = null
                    };

                return new clsOperationResult
                {
                    Status = enOperationStatus.Success,
                    PropertyName = null
                };
            }
            catch (Exception)
            {
                return new clsOperationResult
                {
                    Status = enOperationStatus.Exception,
                    Message = clsGeneralValidationMessages.DatabaseOperationExceptionMessage,
                    PropertyName = null
                };
            }
        }

        public static (clsOperationResult, List<clsApplicationGridViewDto>) GetApplicationsForGridView(enApplicationStatuses applicationStatusID)
        {
            //if (!clsCurrentUser.HasPermission(enPermissions.ViewApplications))
            //    return (new clsOperationResult
            //    {
            //        Status = enOperationStatus.Failed,
            //        Message = clsUserValidationMessages.PermissionDeniedMessage
            //    }, null);


            try
            {
                List<clsApplicationGridViewDto> applicationsList = new List<clsApplicationGridViewDto>();

                if (applicationStatusID == enApplicationStatuses.All)
                    applicationsList = clsApplicationDAL.GetAllApplicationsForGridView();
                else
                    applicationsList = clsApplicationDAL.GetApplicationsByStatus(applicationStatusID);

                if (applicationsList != null)
                    return (new clsOperationResult { Status = enOperationStatus.Success }, applicationsList);
                else
                    return (new clsOperationResult { 
                        Status = enOperationStatus.Failed,
                        Message = clsApplicationValidationMessages.FailedToRetrieveApplicationMessage },
                        null);
            
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

        public static clsOperationResult AddNewFirstTimeDrivingLicenseApplication(int personID, decimal applicationPaidFees, int licenseClassID)
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
                    Message = clsLicenseClassValidationMessages.LicenseClassIDMustBeGreaterThanZeroMessage,
                    PropertyName = nameof(clsLicenseClass.LicenseClassID)
                };

            try
            {
                bool isSuccess = clsApplicationDAL.AddNewFirstTimeDrivingLicenseApplication(personID, applicationPaidFees, licenseClassID, out int newApplicationID);

                if (isSuccess)
                    return new clsOperationResult
                    {
                        CreatedID = newApplicationID,
                        Status = enOperationStatus.Success,
                        Message = clsApplicationValidationMessages.ApplicationSavedSuccessfully,
                        PropertyName = null
                    };

               
                return new clsOperationResult
                {
                    Status = enOperationStatus.Failed,
                    Message = clsApplicationValidationMessages.ApplicationSaveFailed,
                    PropertyName = null
                };

            }
            catch (Exception)
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
