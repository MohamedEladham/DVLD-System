using System;
using DVLD_BL;
using DVLD_Shared;
using System.Drawing;
using System.Windows.Forms;
using DVLD_System_Solution.Forms._003_Manage_People.Controls;

namespace DVLD_System_Solution.Forms._004_Manage_Users.Controls
{
    public partial class uconPersonCardWithIsUserFilter : UserControl
    {
        private int _personID = -1;

        public uconPersonCardWithIsUserFilter()
        {
            InitializeComponent();
        }

        private void _ResetLabelIsUser(bool isUser)
        {
            if(isUser)
            {
                lab_IsUserToText.Text = "Yes";
                lab_IsUserToText.ForeColor = Color.Red;
            }
            else
            {
                lab_IsUserToText.Text = "No";
                lab_IsUserToText.ForeColor = Color.LimeGreen;
            }
        }

        public delegate void SendIsUserEventHandler(object sender, bool isUser);
        public static event SendIsUserEventHandler SendIsUser;

        private void _GetPersonIDAndCheckIsUser(object sender, int personID)
        {
            _personID = personID;
            
            if(_personID > 0)
            {
                try
                {
                    bool isUser = clsUserBL.CheckPersonIsUser(_personID);
                    SendIsUser?.Invoke(this, isUser);
                    _ResetLabelIsUser(isUser);
                }
                catch
                {
                    MessageBox.Show(clsGeneralValidationMessages.DatabaseOperationExceptionMessage, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void _ResetLabelIsUser(object sender, bool isUser)
        {
            _ResetLabelIsUser(isUser);
        }

        private void uconPersonCardWithUserFilter_Load(object sender, EventArgs e)
        {
            frmCreateLoginInfo.CreatedLoginInfo += _ResetLabelIsUser;
            uconShowPersonInfo.SendPersonID += _GetPersonIDAndCheckIsUser; 
        }
    }
}
