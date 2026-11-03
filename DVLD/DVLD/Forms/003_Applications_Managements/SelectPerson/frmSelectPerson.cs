using System;
using System.Windows.Forms;
using static DVLD_Shared.Global_Enums.clsEnumHelpers;
using DVLD_System_Solution.Forms._003_Manage_People.Controls;
using DVLD_System_Solution.Forms._003_Applications_Managements._002_FirstTimeDrivingLicenesApplication_Screen;

namespace DVLD_System_Solution.Forms._003_Applications_Managements._002_FirstTimeDrivingLicense_Screens
{
    public partial class frmSelectPerson : Form
    {
        private int _personID = -1;
        private enServices _serviceTypes;

        public frmSelectPerson(enServices serviceTypes)
        {
            InitializeComponent();
            _serviceTypes = serviceTypes;
        }

        private void _UpdateAddNewApplicationButtonState(object sender, int personID)
        {
            _personID = personID;
            btn_AddNewApplication.Enabled = _personID > -1;
        }

        private void frmSelectPerson_Load(object sender, EventArgs e)
        {
            uconShowPersonInfo.SendPersonID += _UpdateAddNewApplicationButtonState;
        }

        private void btn_AddNewApplication_Click(object sender, EventArgs e)
        {
            switch(_serviceTypes)
            {
                case enServices.FirstTimeLicenseIssuance:
                    frmFirstTimeDrivingLicenesApplication frm = new frmFirstTimeDrivingLicenesApplication(_personID);
                    frm.ShowDialog();
                    break;
            }
        }
    }
}
