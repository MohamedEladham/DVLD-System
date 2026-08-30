using System;
using DVLD_BL;
using System.IO;
using System.Drawing;
using DVLD_Models.User;
using DVLD_BL.Validations;
using System.Windows.Forms;
using System.Threading.Tasks;
using DVLD_Shared.Global_Classes;
using System.Collections.Generic;
using DVLD_Shared.Operations_Result;
using System.Runtime.InteropServices;
using DVLD_System_Solution.Properties;
using static DVLD_Shared.Operations_Result.clsOperationResult;
using DVLD_Shared.Validation_Messages;
using DVLD_Models.Permissions;

namespace Main_Screen.Forms._001_Login_Screen
{
    public partial class frmLoginScreen : Form
    {
        // Win32 API
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        const int WM_NCLBUTTONDOWN = 0xA1;
        const int HTCAPTION = 0x2;

        private void _FrmLogin_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }

        private void _ClearErrorProviderOn_MouseClick(object sender, MouseEventArgs e)
        {
            errorProvider1.SetError((Control)sender, string.Empty);
            lab_LoginResult.Visible = false;
        }

        private void _ClearErrorProviderOn_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError((Control)sender, string.Empty);
            lab_LoginResult.Visible = false;
        }

        public frmLoginScreen()
        {
            InitializeComponent();
        }

        private void frmLoginScreen_Load(object sender, EventArgs e)
        {
            if (Settings.Default.RememberUserName)
            {
                txt_UserName.Text = Settings.Default.UserName;
                checkBox_RememberMe.Checked = true;
            }

            lab_LoginResult.Visible = false;
        }

        // >>
     
        private bool _IsValidUserName(string userName)
        {
            clsValidationResult result = clsUserValidations.IsValidUserName(userName, 2, 50);

            if (!result.IsValid)
            {
                errorProvider1.SetError(txt_UserName, $">> User Name {result.Message}!");
                txt_UserName.Select();
                txt_UserName.SelectAll();
            }

            return result.IsValid;
        }

        private bool _IsValidPassword(string password)
        {
            clsValidationResult result = clsUserValidations.ValidatePassword(password, 2, 50);

            if (!result.IsValid)
            {
                errorProvider1.SetError(txt_Password, $">> Password {result.Message}!");
                txt_Password.Select();
                txt_Password.SelectAll();
            }

            return result.IsValid;
        }

        private bool _ValidateLoginInfo(string userName, string password)
        {
            if (!_IsValidUserName(userName) || !_IsValidPassword(password))
                return false;

            return true;
        }

        private clsUser _GetUserByUserNameAndPassword(string userName, string password)
        {
            (clsOperationResult result, clsUser user) = clsUserBL.GetUserByUserNameAndPassword(userName, password);

            switch(result.Status)
            {
                case enOperationStatus.Success:
                    return user;

                case enOperationStatus.Failed:
                    return null;

                case enOperationStatus.Exception:
                    MessageBox.Show(result.Message, "Database Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;

                default:
                    return null;
            }
        }

        private List<clsPermission> _GetUserPermissions(int userID)
        {
            (clsOperationResult result, List<clsPermission> permissions) = clsPermissionBL.GetUserPermissions(userID);

            switch (result.Status)
            {
                case enOperationStatus.Success:
                    return permissions;

                case enOperationStatus.Failed:
                    MessageBox.Show(result.Message, "Operation Faild", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return null;

                case enOperationStatus.Exception:
                    MessageBox.Show(result.Message, "Database Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;

                default:
                    return null;
            }
        }

        private void _BuildCurrentUser(clsUser user, List<clsPermission> userPermissions)
        {
            clsCurrentUser.UserID = user.UserID;
            clsCurrentUser.UserName = user.UserName;
            clsCurrentUser.UserPermissions = userPermissions;
        }

        private void _SetLoginResult(bool isValid, string message)
        {
            if (isValid)
            {
                lab_LoginResult.Text = message;
                lab_LoginResult.ForeColor = Color.LimeGreen;
            }
            else
            {
                lab_LoginResult.Text = message;
                lab_LoginResult.ForeColor = Color.Red;
            }

            lab_LoginResult.Visible = true;
        }

        private void _SaveUserInfoToProperties()
        {
            if (checkBox_RememberMe.Checked)
            {
                Settings.Default.RememberUserName = true;
                Settings.Default.UserName = txt_UserName.Text;
            }
            else
            {
                Settings.Default.RememberUserName = false;
                Settings.Default.UserName = "";
            }

            Settings.Default.Save();
        }

        private async void btn_Login_Click(object sender, EventArgs e)
        {
            string userName = txt_UserName.Text.Trim();
            string password = txt_Password.Text;

            if (!_ValidateLoginInfo(userName, password))
                return;

            clsUser user = _GetUserByUserNameAndPassword(userName, password);

            if(user != null)
            {
                List<clsPermission> userPermissions = _GetUserPermissions(user.UserID);

                if(userPermissions != null)
                {
                    _BuildCurrentUser(user, userPermissions);

                    _SetLoginResult(true, clsUserValidationMessages.LoginSuccessfulMessage);

                    _SaveUserInfoToProperties();

                    await Task.Delay(1000);

                    txt_Password.Text = "";
                    lab_LoginResult.Visible = false;

                    frmMainScreen frm = new frmMainScreen();
                    frm.ShowDialog();

                    txt_UserName.Select();
                    txt_UserName.SelectAll();
                }
                else
                    _SetLoginResult(false, "Faild To Git Permissions....");
            }
            else
                _SetLoginResult(false, clsUserValidationMessages.LoginFailedMessage);
        }

        // >>

        private bool _isPasswordVisible = false;

        private void _SetPasswordCharacter()
        {
            if (_isPasswordVisible)
            {
                txt_Password.UseSystemPasswordChar = true;
                _isPasswordVisible = false;
            }
            else
            {
                txt_Password.UseSystemPasswordChar = false;
                _isPasswordVisible = true;
            }
        }

        private void _SetShowHidePasswordImage(bool status)
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
            _SetShowHidePasswordImage(_isPasswordVisible);
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
