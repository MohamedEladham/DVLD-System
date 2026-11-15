using System;
using DVLD_BL;
using System.IO;
using System.Drawing;
using DVLD_Models.User;
using DVLD_BL.Validations;
using System.Windows.Forms;
using DVLD_Shared.Global_Classes;
using DVLD_Shared.Operations_Result;
using static DVLD_Shared.Operations_Result.clsOperationResult;
using DVLD_Shared.Validation_Messages;
using DVLD_Models;
using System.Collections.Generic;
using DVLD_Models.Role;
using DVLD_Models.Roles;

namespace DVLD_System_Solution.Forms._004_Manage_Users
{
    public partial class frmCreateLoginInfo : Form
    {
        private int _userID = -1;
        private int _personID = -1;

        public frmCreateLoginInfo(int personID)
        {
            InitializeComponent();

            _personID = personID;
        }

        private void comBox_Roles_MouseClick(object sender, MouseEventArgs e)
        {
            errorProvider1.SetError(comBox_Roles, string.Empty);
        }

        private void _ClearErrorProviderOn_MouseClick(object sender, MouseEventArgs e)
        {
            errorProvider1.SetError((Control)sender, string.Empty);
        }

        private void _ClearErrorProviderOn_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError((Control)sender, string.Empty);
        }

        private void _LinkEventsToControls(Control parent)
        {
            foreach (Control control in parent.Controls)
            {
                if (control is TextBox)
                {
                    control.MouseClick += _ClearErrorProviderOn_MouseClick;
                    control.TextChanged += _ClearErrorProviderOn_TextChanged;
                }

                if (control.HasChildren)
                {
                    _LinkEventsToControls(control);
                }
            }
        }

        private void _FillUserInfo(clsUser user)
        {
            lab_UserIDToText.Text = Convert.ToString(_userID);

            txt_UserName.Text = Convert.ToString(user.UserName);
            txt_Password.Text = Convert.ToString(user.Password);
            txt_ConfirmPassword.Text = Convert.ToString(user.Password);

            if (user.IsActive)
                rdoB_Active.Checked = true;
            else
                rdoB_NotActive.Checked = true;
        }

        private void _GetUserByID(int userID)
        {
            (clsOperationResult result, clsUser user) = clsUserBL.GetUserByUserID(userID);

            switch (result.Status)
            {
                case enOperationStatus.Success:
                    if (user != null)
                        _FillUserInfo(user);
                    break;

                case enOperationStatus.Failed:
                    MessageBox.Show(result.Message, "Failed Operation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;

                case enOperationStatus.Exception:
                    MessageBox.Show(result.Message, "Database Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }



        // >>

        List<clsActiveRolesInfoGridViewDto> _activeRoles = null;
        private List<clsActiveRolesInfoGridViewDto> _GetActiveRoles()
        {
            (clsOperationResult result, List<clsActiveRolesInfoGridViewDto> activeRoles) = clsRoleBL.GetActiveRoles();

            switch (result.Status)
            {
                case enOperationStatus.Success:
                    return activeRoles;

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
        private void _LoadRolesToComboBox()
        {
            _activeRoles = _GetActiveRoles();
            comBox_Roles.DataSource = _activeRoles;
            comBox_Roles.DisplayMember = "RoleName";
            comBox_Roles.ValueMember = "RoleID";
            comBox_Roles.SelectedIndex = -1;
        }

        private void _Load()
        {
            _LoadRolesToComboBox();
            _LinkEventsToControls(this);
            txt_UserName.Select();
            lab_PersonIDToText.Text = Convert.ToString(_personID);
        }

        private void frmCreateLoginInfo_Load(object sender, EventArgs e)
        {
            _Load();
        }


        // >>
        private clsUser _BuildUserInfo()
        {
            return new clsUser
            {
                UserID = _userID,
                PersonID = _personID,
                UserName = txt_UserName.Text.Trim(),
                Password = txt_Password.Text.Trim(),
                IsActive = rdoB_Active.Checked
            };
        }

        
        public delegate void CreatedLoginInfoEventHandler(object sender, bool isCreated);
        public static event CreatedLoginInfoEventHandler CreatedLoginInfo;


        private bool _showHidePasswordClick = false;

        private void _SetPasswordCharacter(bool status)
        {
            if (_showHidePasswordClick)
            {
                txt_Password.UseSystemPasswordChar = true;
                txt_ConfirmPassword.UseSystemPasswordChar = true;
                _showHidePasswordClick = false;
            }
            else
            {
                txt_Password.UseSystemPasswordChar = false;
                txt_ConfirmPassword.UseSystemPasswordChar = false;
                _showHidePasswordClick = true;
            }
        }

        private void _SetDefaultShowPasswordImage(bool status)
        {
            picB_ShowHidePassword.Image = status ?
                global::DVLD_System_Solution.Properties.Resources.Show_Passowrd_32 :
                global::DVLD_System_Solution.Properties.Resources.Hide_Passowrd_32;
        }

        private void picB_ShowHidePassword_Click(object sender, EventArgs e)
        {
            _SetPasswordCharacter(_showHidePasswordClick);
            _SetDefaultShowPasswordImage(_showHidePasswordClick);
        }

        private void _HandleSuccessfulSave()
        {
            lab_UserIDToText.Text = Convert.ToString(_userID);

            txt_UserName.Enabled = false;
            txt_Password.Enabled = false;
            txt_ConfirmPassword.Enabled = false;
            rdoB_Active.Enabled = false;
            rdoB_NotActive.Enabled = false;
            btn_Save.Enabled = false;
            picB_ShowHidePassword.Enabled = false;
            comBox_Roles.Enabled = false;
            _showHidePasswordClick = false;
            _SetPasswordCharacter(_showHidePasswordClick = true);
            _SetDefaultShowPasswordImage(false);
        }

        private Control _GetControlByPropertyName(string propertyName)
        {
            if (propertyName == nameof(clsUser.UserName))
                return txt_UserName;

            if (propertyName == nameof(clsUser.Password))
                return txt_Password;

            if (propertyName == "ConfirmPassword")
                return txt_ConfirmPassword;

            if (propertyName == "Role")
                return comBox_Roles;

            return null;
        }

        private void _SetErrorProvider(string propertyName, string message)
        {
            Control control = _GetControlByPropertyName(propertyName);

            if (control != null)
            {
                errorProvider1.SetError(control, message);
                if (control is TextBox) control.Select();
            }
            else
                MessageBox.Show(message, "Operation Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private bool _AddNewUser(clsUser user)
        {
            if (!clsCurrentUser.HasPermission(enPermissions.AddUserAndRole))
            {
                MessageBox.Show(clsUserValidationMessages.PermissionDeniedMessage, "Permission Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            string confirmPassword = txt_ConfirmPassword.Text.Trim();
            int roleID = Convert.ToInt32(comBox_Roles.SelectedValue);

            clsOperationResult result = clsUserBL.AddNewUserAndRole(user, confirmPassword, roleID);

            switch (result.Status)
            {
                case enOperationStatus.Success:
                    _userID = result.CreatedID;
                    CreatedLoginInfo?.Invoke(this, true);
                    _HandleSuccessfulSave();
                    MessageBox.Show(clsUserValidationMessages.UserAddedSuccessfullyMessage,
                        "Operation Succeeded", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;

                case enOperationStatus.Failed:
                    if(string.IsNullOrEmpty(result.PropertyName))
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
            return _AddNewUser(_BuildUserInfo());
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            _Save();
        }

        
        // >>
        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
