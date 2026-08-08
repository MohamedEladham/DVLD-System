using System;
using System.Windows.Forms;
using static DVLD_Shared.Global_Enums.clsEnumHelpers;
using DVLD_System_Solution.Forms._003_Manage_People.Controls;
using DVLD_System_Solution.Forms._004_Manage_Users.Controls;

namespace DVLD_System_Solution.Forms._004_Manage_Users
{
    public partial class frmAddNewUser : Form
    {
        private int _personID = -1;
        
        public frmAddNewUser()
        {
            InitializeComponent();
        }

        private void _GetPersonID(object sender, int personID)
        {
            _personID = personID;
        }

        private void _UpdateButtonModeCreateLoginInfo(object sender, bool mode)
        {
            btn_CreateLoginInfo.Enabled = !mode;
        }

        private void frmAddNewUser_Load(object sender, EventArgs e)
        {
            uconShowPersonInfo.SendPersonID += _GetPersonID;
            frmCreateLoginInfo.CreatedLoginInfo += _UpdateButtonModeCreateLoginInfo;
            uconPersonCardWithUserFilter.SendIsUser += _UpdateButtonModeCreateLoginInfo;
        }
        
        private void btn_CreateLoginInfo_Click(object sender, EventArgs e)
        {
            frmCreateLoginInfo frm = new frmCreateLoginInfo(_personID);
            frm.ShowDialog();
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
