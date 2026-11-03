using DVLD_DAL;
using DVLD_Models.Person;
using DVLD_Models.User;
using DVLD_Models;
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
using DVLD_Models.Service;

namespace DVLD_BL
{
    public class clsServiceBL
    {

        public static (clsOperationResult, decimal?) GetApplicationFeesByServiceID(int serviceID) 
        {
            if (serviceID <= 0)
                return (new clsOperationResult
                {
                    Status = enOperationStatus.Failed,
                    Message = clsServiceValidationMessages.ServiceIDMustBeGreaterThanZeroMessage 
                }, null);

            try
            {
                (bool serviceExists, decimal? applicationFees) = clsServiceDAL.GetApplicationFeesByServiceID(serviceID);

                if (!serviceExists)
                    return (new clsOperationResult
                    {
                        Status = enOperationStatus.Failed,
                        Message = clsApplicationValidationMessages.ApplicationFeesNotFoundMessage
                    }, null);

                if (serviceExists && applicationFees == null)
                    return (new clsOperationResult
                    {
                        Status = enOperationStatus.Failed,
                        Message = clsApplicationValidationMessages.ApplicationFeesNotSetMessage
                    }, null);
                    
                return (new clsOperationResult { Status = enOperationStatus.Success }, applicationFees);
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

        public static (clsOperationResult, clsService) GetServiceInfoByID(int serviceID)
        {
            if (serviceID <= 0)
                return (new clsOperationResult
                {
                    Status = enOperationStatus.Failed,
                    Message = clsServiceValidationMessages.InvalidServiceIDMessage
                }, null);

            try
            {
                clsService serviceInfo = clsServiceDAL.GetServiceInfoByID(serviceID);

                if (serviceInfo != null)
                    return (new clsOperationResult { Status = enOperationStatus.Success }, serviceInfo);
                else
                    return (new clsOperationResult
                    {
                        Status = enOperationStatus.Failed,
                        Message = clsServiceValidationMessages.ServiceNotFoundMessage
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
    }
}
