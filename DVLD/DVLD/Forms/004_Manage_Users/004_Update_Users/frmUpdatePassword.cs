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

        private void frmUpdatePassword_Load(object sender, EventArgs e)
        {
            lab_UserID.Text = Convert.ToString(_userID);
            lab_UserName.Text = Convert.ToString(_userName);
            txt_NewPassword.Select();
        }

        // >>
       
        private bool _ValidatePassword()
        {
            string password = txt_NewPassword.Text;

            clsValidationResult result = clsUserValidations.ValidatePassword(password, 3, 150);

            if (!result.IsValid)
            {
                errorProvider1.SetError(txt_NewPassword, $">> New Password Is {result.Message}.");
                txt_NewPassword.Select();
                txt_NewPassword.SelectAll();
            }

            return result.IsValid;
        }

        private bool _ValidateConfirmPassword()
        {
            string confirmPassword = txt_ConfirmPassword.Text;

            clsValidationResult result = clsUserValidations.ValidateConfirmPassword(confirmPassword, txt_NewPassword.Text);

            if (!result.IsValid)
            {
                errorProvider1.SetError(txt_ConfirmPassword, $"{result.Message}!");
                txt_ConfirmPassword.Select();
                txt_ConfirmPassword.SelectAll();
            }

            return result.IsValid;
        }

        private bool _UpdatePassword(string newPassword, int userID)
        {
            clsOperationResult result = clsUserBL.UpdatePassword(newPassword, userID);

            switch (result.Status)
            {
                case enOperationStatus.Success:
                    MessageBox.Show(result.Message, "Operation Succeeded", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            if (!_ValidatePassword() || !_ValidateConfirmPassword())
                return false;

            return _UpdatePassword(txt_NewPassword.Text, _userID);
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (!clsCurrentUser.HasPermission(enPermissions.UpdateUserPassword))
            {
                MessageBox.Show(clsUserValidationMessages.PermissionDeniedMessage, "Permission Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _Save();
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

        
        private void txt_Password_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError((Control)sender, string.Empty);
        }

        private void txt_Password_Click(object sender, EventArgs e)
        {
            errorProvider1.SetError((Control)sender, string.Empty);
        }

        private void btn_Close_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
