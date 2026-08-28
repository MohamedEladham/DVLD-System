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

        private void _BindRolesToComboBox(List<clsRole> roles)
        {
            comBox_Roles.DataSource = roles;
            comBox_Roles.DisplayMember = "RoleName";
            comBox_Roles.ValueMember = "RoleID";
            comBox_Roles.SelectedIndex = -1;
        }

        private void _GetAllRoles()
        {
            (clsOperationResult result, List<clsRole> roles) = clsRoleBL.GetAllRoles();

            switch (result.Status)
            {
                case enOperationStatus.Success:
                    _BindRolesToComboBox(roles);
                    break;

                case enOperationStatus.Failed:
                    MessageBox.Show(result.Message, "Filed To Retrive Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;

                case enOperationStatus.Exception:
                    MessageBox.Show(result.Message, "Database Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }

        private void frmCreateLoginInfo_Load(object sender, EventArgs e)
        {
            txt_UserName.Select();
            lab_PersonIDToText.Text = Convert.ToString(_personID);
            _LinkEventsToControls(this);
            _GetAllRoles();
        }

        private bool _ValidateUserName()
        {
            string userName = txt_UserName.Text.Trim();

            clsValidationResult result = clsUserValidations.ValidateUserName(userName, 2, 50);

            if (!result.IsValid)
            {
                errorProvider1.SetError(txt_UserName, $">> User Name {result.Message}!");
                txt_UserName.Select();
                txt_UserName.SelectAll();
            }

            return result.IsValid;
        }

        private bool _ValidatePassword()
        {
            string password = txt_Password.Text.Trim();

            clsValidationResult result = clsUserValidations.ValidatePassword(password, 3, 150);

            if (!result.IsValid)
            {
                errorProvider1.SetError(txt_Password, $">> Password {result.Message}!");
                txt_Password.Select();
                txt_Password.SelectAll();
            }

            return result.IsValid;
        }

        private bool _ValidateConfirmPassword()
        {
            string confirmPassword = txt_ConfirmPassword.Text.Trim();

            clsValidationResult result = clsUserValidations.ValidateConfirmPassword(confirmPassword, txt_Password.Text.Trim());

            if (!result.IsValid)
            {
                errorProvider1.SetError(txt_ConfirmPassword, $"{result.Message}!");
                txt_ConfirmPassword.Select();
                txt_ConfirmPassword.SelectAll();
            }

            return result.IsValid;
        }

        private bool _ValidateRole()
        {
            if (comBox_Roles.SelectedIndex == -1)
            {
                errorProvider1.SetError(comBox_Roles, $"{clsRoleValidationMessages.RoleRequiredMessage}!");
                return false;
            }

            return true;
        }

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

        // Save Data To Database
        public delegate void CreatedLoginInfoEventHandler(object sender, bool isCreated);
        public static event CreatedLoginInfoEventHandler CreatedLoginInfo;

        private bool _AddNewUser(clsUser user)
        {
            clsOperationResult result = clsUserBL.AddNewUser(user);

            switch (result.Status)
            {
                case enOperationStatus.Success:
                    _userID = result.CreatedID;
                    CreatedLoginInfo?.Invoke(this, true);
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

        private bool _AddUserRole(int userID, int roleID)
        {
            clsOperationResult result = clsUserBL.AddUserRole(userID, roleID);

            switch (result.Status)
            {
                case enOperationStatus.Success:
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
            _SetPasswordCharacter(false);
            _SetDefaultShowPasswordImage(false);
        }

        private bool _Save()
        {
            if (!_ValidateUserName() || !_ValidatePassword() || !_ValidateConfirmPassword() || !_ValidateRole())
                return false;

            clsUser user = _BuildUserInfo();

            bool isAddedNewUser = _AddNewUser(user);

            if (isAddedNewUser)
            {
                int roleID = Convert.ToInt32(comBox_Roles.SelectedValue);

                bool isAddedUserRole = _AddUserRole(_userID, roleID);

                if(isAddedUserRole)
                {
                    _HandleSuccessfulSave();
                    MessageBox.Show(clsUserValidationMessages.UserAddedSuccessfullyMessage,
                        "Operation Succeeded", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
            }

            return false;
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (!clsCurrentUser.HasPermission(enPermissions.AddUser))
            {
                MessageBox.Show(clsUserValidationMessages.PermissionDeniedMessage, "Permission Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _Save();
        }

        // >>

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
            string imagePath = clsImageHelper.GetOrCreateResourcesImageFolderPath();

            if (status)
                imagePath = Path.Combine(imagePath, "Show_Passowrd_32.png");
            else
                imagePath = Path.Combine(imagePath, "Hide_Passowrd_32.png");

            Image image = clsImageHelper.LoadImageSafe(imagePath);

            if (image != null)
            {
                picB_ShowHidePassword.Image = image;
            }
        }

        private void picB_ShowHidePassword_Click(object sender, EventArgs e)
        {
            _SetPasswordCharacter(_showHidePasswordClick);
            _SetDefaultShowPasswordImage(_showHidePasswordClick);
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comBox_Roles_MouseClick(object sender, MouseEventArgs e)
        {
            errorProvider1.SetError(comBox_Roles, string.Empty);
        }
    }
}
