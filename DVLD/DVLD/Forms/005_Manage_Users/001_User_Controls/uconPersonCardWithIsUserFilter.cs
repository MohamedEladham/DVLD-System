using System;
using DVLD_BL;
using DVLD_Shared;
using System.Drawing;
using System.Windows.Forms;
using DVLD_System_Solution.Forms._003_Manage_People.Controls;
using DVLD_Shared.Operations_Result;

namespace DVLD_System_Solution.Forms._004_Manage_Users.Controls
{
    public partial class uconPersonCardWithIsUserFilter : UserControl
    {
        private int _personID = -1;

        public uconPersonCardWithIsUserFilter()
        {
            InitializeComponent();
        }
        
        
        // >>
        public delegate void SendIsUserEventHandler(object sender, bool isUser);
        public static event SendIsUserEventHandler SendIsUser;

        

        private void _ResetLabelIsUser(bool isUser)
        {
            if (isUser)
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

        private void _ResetLabelIsUser(object sender, bool isUser)
        {
            _ResetLabelIsUser(isUser);
        }


        private void _GetPersonIDAndCheckIsUser(object sender, int personID)
        {
            if(personID == -1)
            {
                SendIsUser?.Invoke(this, true);
                lab_IsUserToText.Text = "???";
                lab_IsUserToText.ForeColor = Color.DimGray;
                return;
            }

            _personID = personID;

            (clsOperationResult result, bool isUser) = clsUserBL.CheckPersonIsUser(_personID);

            switch(result.Status)
            {
                case clsOperationResult.enOperationStatus.Success:
                    SendIsUser?.Invoke(this, isUser);
                    _ResetLabelIsUser(isUser);
                    break;

                case clsOperationResult.enOperationStatus.Failed:
                    MessageBox.Show(result.Message, "Operation Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;

                case clsOperationResult.enOperationStatus.Exception:
                    MessageBox.Show(result.Message, "Database Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }
        
        
        private void uconPersonCardWithUserFilter_Load(object sender, EventArgs e)
        {
            frmCreateLoginInfo.CreatedLoginInfo += _ResetLabelIsUser;
            uconShowPersonInfo.SendPersonID += _GetPersonIDAndCheckIsUser;
        }
    }
}
