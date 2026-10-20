using System;
using DVLD_BL;
using DVLD_Models.User;
using DVLD_BL.Validations;
using System.Windows.Forms;
using DVLD_Shared.Operations_Result;
using static DVLD_Shared.Operations_Result.clsOperationResult;
using DVLD_Shared.Global_Classes;
using DVLD_Shared.Validation_Messages;
using DVLD_System_Solution.Forms._004_Manage_Users._004_Update_Users;

namespace DVLD_System_Solution.Forms._004_Manage_Users
{
    public partial class frmUpdateLoginInfo : Form
    {
        private int _userID = -1;
        private int _personID = -1;
        private string _userName = "";

        public frmUpdateLoginInfo(int userID)
        {
            InitializeComponent();
            _userID = userID;
        }

        private void txt_UserName_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(txt_UserName, string.Empty);
        }

        private void txt_UserName_MouseClick(object sender, MouseEventArgs e)
        {
            errorProvider1.SetError(txt_UserName, string.Empty);
        }

        
        // >>
        private clsUser _GetUserByID()
        {
            (clsOperationResult result, clsUser user) = clsUserBL.GetUserByUserID(_userID);

            switch (result.Status)
            {
                case enOperationStatus.Success:
                    return user;

                case enOperationStatus.Failed:
                    MessageBox.Show(result.Message, "Failed Operation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return null;

                case enOperationStatus.Exception:
                    MessageBox.Show(result.Message, "Database Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;

                default:
                    return null;
            }
        }

        private void _LoadUserInfo()
        {
            clsUser user = _GetUserByID();

            if (user != null)
            {
                _personID = user.PersonID;
                _userName = user.UserName;
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
        }

        private void frmUpdateLoginInfo_Load(object sender, EventArgs e)
        {
            btn_UpdateRoles.Enabled = clsCurrentUser.HasPermission(enPermissions.UpdateUserRoles);
            btn_ChangePassword.Enabled = clsCurrentUser.HasPermission(enPermissions.UpdateUserPassword);
            _LoadUserInfo();
        }


        // >>
        public delegate void UpdateLoginInfoEventHandler(object sender, bool isCreated);
        public static event UpdateLoginInfoEventHandler UpdateLoginInfo;

        private clsUser _BuildLoginnfo()
        {
            return new clsUser
            {
                UserID = _userID,
                UserName = txt_UserName.Text.Trim(),
                IsActive = rdoB_Active.Checked
            };
        }

        private Control _GetControlByPropertyName(string propertyName)
        {
            if (propertyName == nameof(clsUser.UserName))
                return txt_UserName;
           
            return null;
        }

        private void _SetErrorProvider(string propertyName, string message)
        {
            Control control = _GetControlByPropertyName(propertyName);
            errorProvider1.SetError(control, message);
            control.Select();
        }

        private bool _UpdateUserNameAndStatusInfo(clsUser user)
        {
            if (!clsCurrentUser.HasPermission(enPermissions.UpdateUserLoginInfo))
            {
                MessageBox.Show(clsUserValidationMessages.PermissionDeniedMessage, "Permission Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            clsOperationResult result = clsUserBL.UpdateUserNameAndStatusInfo(user); 

            switch (result.Status)
            {
                case enOperationStatus.Success:
                    MessageBox.Show(result.Message, "Operation Succeeded", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    UpdateLoginInfo?.Invoke(this, true);
                    return true;

                case enOperationStatus.Failed:
                    if (string.IsNullOrEmpty(result.PropertyName))
                        MessageBox.Show(result.Message, "Operation Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else
                        _SetErrorProvider(result.PropertyName, result.Message);
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
            return _UpdateUserNameAndStatusInfo(_BuildLoginnfo());
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            _Save();
        }

        // >>

        private void btn_UpdateRoles_Click(object sender, EventArgs e)
        {
            if (!clsCurrentUser.HasPermission(enPermissions.UpdateUserRoles))
            {
                MessageBox.Show(clsUserValidationMessages.PermissionDeniedMessage, "Permission Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            frmUpdateUserRoles frm = new frmUpdateUserRoles(_userID, _userName);
            frm.ShowDialog();
        }

        private void btn_UpdatePassword_Click(object sender, EventArgs e)
        {
            if (!clsCurrentUser.HasPermission(enPermissions.UpdateUserPassword))
            {
                MessageBox.Show(clsUserValidationMessages.PermissionDeniedMessage, "Permission Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            frmUpdatePassword frm = new frmUpdatePassword(_userID, _userName);
            frm.ShowDialog();
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
