using System;
using DVLD_BL;
using DVLD_Models.Person;
using DVLD_Models.Service;
using System.Windows.Forms;
using DVLD_Shared.Operations_Result;
using static DVLD_Shared.Global_Enums.clsEnumHelpers;
using static DVLD_Shared.Operations_Result.clsOperationResult;
using DVLD_System_Solution.Forms._003_Applications_Managements._002_FirstTimeDrivingLicenesApplication_Screen;
using DVLD_Shared.Events;

namespace DVLD_System_Solution.Forms._003_Applications_Managements._001_User_Controls
{
    public partial class uconApplicationDetails : UserControl
    {
        public uconApplicationDetails()
        {
            InitializeComponent();
        }

        private clsPersonBasicInfo _GetPersonBasicInfoByID(int personID)
        {
            (clsOperationResult result, clsPersonBasicInfo personBasicInfo) = clsPersonBL.GetPersonBasicInfoByID(personID);

            switch (result.Status)
            {
                case enOperationStatus.Success:
                    return personBasicInfo;

                case enOperationStatus.Failed:
                    MessageBox.Show(result.Message, "Filed To Retrive Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return null;

                case enOperationStatus.Exception:
                    MessageBox.Show(result.Message, "Database Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;

                default:
                    return null;
            }
        }

        private clsService _GetServiceInfoByID(int serviceID)
        {
            (clsOperationResult result, clsService serviceInfo) = clsServiceBL.GetServiceInfoByID(serviceID);

            switch (result.Status)
            {
                case enOperationStatus.Success:
                    return serviceInfo;

                case enOperationStatus.Failed:
                    MessageBox.Show(result.Message, "Filed To Retrive Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return null;

                case enOperationStatus.Exception:
                    MessageBox.Show(result.Message, "Database Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;

                default:
                    return null;
            }
        }

        private void _FillPersonBasicInfoAndServiceBasicInfo(clsPersonBasicInfo personBasicInfo, clsService serviceInfo)
        {
            lab_PersonID.Text = Convert.ToString(personBasicInfo.PersonID);
            lab_PersonName.Text = personBasicInfo.PersonName;
            lab_PersonAge.Text = Convert.ToString(personBasicInfo.Age);
            lab_ServiceName.Text = serviceInfo.ServiceName;
            lab_ApplicationFees.Text = !serviceInfo.ApplicationFees.HasValue ? "???" : Convert.ToString(serviceInfo.ApplicationFees);
        }

        public void LoadPersonBasicInfoAndServiceBasicInfo(int personID, int serviceID) 
        {
            clsPersonBasicInfo personBasicInfo = _GetPersonBasicInfoByID(personID);

            if(personBasicInfo != null)
            {
                clsService serviceInfo = _GetServiceInfoByID(serviceID);

                if (serviceInfo != null)
                    _FillPersonBasicInfoAndServiceBasicInfo(personBasicInfo, serviceInfo);
            }
        }

        private void _ApplicationCreated(int applicationID)
        {
            lab_ApplicationID.Text = (applicationID > 0) ? Convert.ToString(applicationID) : "???";
        }

        private void uconApplicationDetails_Load(object sender, EventArgs e)
        {
            clsApplicationEvents.ApplicationCreated += _ApplicationCreated;
        }
    }
}
