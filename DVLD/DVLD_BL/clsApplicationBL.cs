using DVLD_DAL;
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
using DVLD_Models.Application;
using System.Dynamic;

namespace DVLD_BL
{
    public class clsApplicationBL
    {

        public static (clsOperationResult, List<clsApplicationGridViewDto>) GetApplicationsForGridView(enApplicationStatuses applicationStatusID)
        {
            if (!clsCurrentUser.HasPermission(enPermissions.ViewApplications))
                return (new clsOperationResult
                {
                    Status = enOperationStatus.Failed,
                    Message = clsUserValidationMessages.PermissionDeniedMessage
                }, null);


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
    }
}
