using System;
using DVLD_BL;
using DVLD_Models.User;
using DVLD_BL.Validations;
using System.Windows.Forms;
using DVLD_Shared.Operations_Result;
using Main_Screen.Forms._004_Users.Controls;
using static DVLD_Shared.Operations_Result.clsOperationResult;
using DVLD_Shared.Global_Classes;

namespace DVLD_System_Solution.Forms._004_Manage_Users
{
    public partial class frmUpdateLoginInfo : Form
    {
        private int _userID = -1;
        private int _personID = -1;

        public frmUpdateLoginInfo(int userID)
        {
            InitializeComponent();
            
            _userID = userID;
        }

        private void _FillFormByUserInfo(clsUser user)
        {
            _personID = user.PersonID;
            lab_PersonIDToText.Text = Convert.ToString(_personID);
            lab_UserIDToText.Text = Convert.ToString(user.UserID);
            txt_UserName.Text = Convert.ToString(user.UserName);
            txt_UserName.Select();
            txt_UserName.SelectAll();

            if (user.IsActive)
                rdoB_Active.Checked = true;
            else
                rdoB_NotActive.Checked = true;
        }

        private void _GetUserByID(int userID)
        {
            (clsOperationResult result, clsUser user) = clsUserBL.GetUserByID(userID);

            switch (result.Status)
            {
                case enOperationStatus.Success:
                    if (user != null)
                        _FillFormByUserInfo(user);
                    break;

                case enOperationStatus.Failed:
                    MessageBox.Show(result.Message, "Failed Operation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;

                case enOperationStatus.Exception:
                    MessageBox.Show(result.Message, "Database Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }

        private void frmUpdateLoginInfo_Load(object sender, EventArgs e)
        {
            _GetUserByID(_userID);
        }
       
        // >>

        // Save Data To Database
        private bool _ValidateUserName()
        {
            string userName = txt_UserName.Text.Trim();

            clsValidationResult result = clsUserValidations.ValidateUserName(userName, 2, 50, _userID);

            if (!result.IsValid)
            {
                errorProvider1.SetError(txt_UserName, $">> User Name {result.Message}!");
                txt_UserName.Select();
                txt_UserName.SelectAll();
            }

            return result.IsValid;
        }


        

        private clsUser _BuildLoginnfo()
        {
            return new clsUser
            {
                UserID = _userID,
                UserName = txt_UserName.Text.Trim(),
                IsActive = rdoB_Active.Checked
            };
        }

        public delegate void UpdateLoginInfoEventHandler(object sender, bool isCreated);
        public static event UpdateLoginInfoEventHandler UpdateLoginInfo;

        private bool _UpdateUserNameAndStatusInfo(clsUser user)
        {
            clsOperationResult result = clsUserBL.UpdateUserNameAndStatusInfo(user); 

            switch (result.Status)
            {
                case enOperationStatus.Success:
                    MessageBox.Show(result.Message, "Operation Succeeded", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    UpdateLoginInfo?.Invoke(this, true);
                    return true;

                case enOperationStatus.Failed:
                    MessageBox.Show(result.Message, "Operation Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;

                case enOperationStatus.Exception:
                    MessageBox.Show(result.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;

                default:
                    return false;
            }
        }

        private bool _Save()
        {
            if (!_ValidateUserName())
                return false;

            clsUser user = _BuildLoginnfo();

            return _UpdateUserNameAndStatusInfo(user);
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            _Save();
        }

        // >>

        private void btn_UpdatePassword_Click(object sender, EventArgs e)
        {
            frmCheckCurrentUserPassword frm = new frmCheckCurrentUserPassword(_userID, _personID);
            frm.ShowDialog();
        }

        private void txt_UserName_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(txt_UserName, string.Empty);
        }

        private void txt_UserName_MouseClick(object sender, MouseEventArgs e)
        {
            errorProvider1.SetError(txt_UserName, string.Empty);
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
