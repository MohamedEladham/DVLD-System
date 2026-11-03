using System;
using DVLD_BL;
using System.IO;
using System.Drawing;
using DVLD_BL.Validations;
using System.Windows.Forms;
using DVLD_Shared.Global_Classes;
using DVLD_Shared.Operations_Result;
using static DVLD_Shared.Operations_Result.clsOperationResult;
using DVLD_Models.User;
using DVLD_Shared.Validation_Messages;

namespace DVLD_System_Solution.Forms._004_Manage_Users
{
    public partial class frmUpdatePassword : Form
    {
        private int _userID = -1;
        private string _userName = "";

        public frmUpdatePassword(int userID, string userName)
        {
            InitializeComponent();
            _userID = userID;
            _userName = userName;
        }

        private void txt_Password_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError((Control)sender, string.Empty);
        }

        private void txt_Password_Click(object sender, EventArgs e)
        {
            errorProvider1.SetError((Control)sender, string.Empty);
        }

        // >> 

        private bool _showHidePasswordClick = false;
        private void _SetPasswordCharacter()
        {
            if (_showHidePasswordClick)
            {
                txt_NewPassword.UseSystemPasswordChar = true;
                txt_ConfirmPassword.UseSystemPasswordChar = true;
                _showHidePasswordClick = false;
            }
            else
            {
                txt_NewPassword.UseSystemPasswordChar = false;
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
            _SetPasswordCharacter();
            _SetDefaultShowPasswordImage(_showHidePasswordClick);
        }


        // >>
        private void _LoadUserInfo()
        {
            lab_UserID.Text = Convert.ToString(_userID);
            lab_UserName.Text = Convert.ToString(_userName);
            txt_NewPassword.Select();
        }

        private void frmUpdatePassword_Load(object sender, EventArgs e)
        {
            _LoadUserInfo();
        }


        // >>

        private Control _GetControlByPropertyName(string propertyName)
        {
            if (propertyName == nameof(clsUser.Password))
                return txt_NewPassword;

            if (propertyName == "ConfirmPassword")
                return txt_ConfirmPassword;

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

        private bool _UpdatePassword()
        {
            if (!clsCurrentUser.HasPermission(enPermissions.UpdateUserPassword))
            {
                MessageBox.Show(clsUserValidationMessages.PermissionDeniedMessage, "Permission Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }


            clsOperationResult result = clsUserBL.UpdateUserPassword(txt_NewPassword.Text, txt_ConfirmPassword.Text, _userID);

            switch (result.Status)
            {
                case enOperationStatus.Success:
                    MessageBox.Show(result.Message, "Operation Succeeded", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            return _UpdatePassword();
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            _Save();
        }


        // >>
        private void btn_Close_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
