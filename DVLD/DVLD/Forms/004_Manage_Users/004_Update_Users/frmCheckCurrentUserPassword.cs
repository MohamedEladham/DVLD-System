using System;
using DVLD_BL;
using System.IO;
using System.Drawing;
using DVLD_BL.Validations;
using System.Windows.Forms;
using System.Threading.Tasks;
using DVLD_Shared.Global_Classes;
using DVLD_System_Solution.Forms._004_Manage_Users;

namespace Main_Screen.Forms._004_Users.Controls
{
    public partial class frmCheckCurrentUserPassword : Form
    {
        private int _userID = -1;
        private int _personID = -1;

        public frmCheckCurrentUserPassword(int userID, int personID)
        {
            InitializeComponent();
            _userID = userID;
            _personID = personID;
        }

        private void txt_CurrentPassword_MouseClick(object sender, MouseEventArgs e)
        {
            lab_CurrentPasswordResult.Visible = false;
        }

        private void txt_CurrentPassword_TextChanged(object sender, EventArgs e)
        {
            lab_CurrentPasswordResult.Visible = false;
        }

        private void _ShowStatusMessage(string message, bool isSuccess)
        {
            lab_CurrentPasswordResult.Text = message;
            lab_CurrentPasswordResult.ForeColor = isSuccess ? Color.LimeGreen : Color.Red;
            lab_CurrentPasswordResult.Visible = true;
            txt_CurrentPassword.Select();
            txt_CurrentPassword.SelectAll();
        }

        private bool _IsCurrentPasswordValid()
        {
            clsValidationResult result = clsUserBL.IsCurrentPasswordValid(txt_CurrentPassword.Text.Trim(), _userID);

            _ShowStatusMessage(result.Message, result.IsValid);

            return result.IsValid;
        }

        private async void btn_CheckPassword_Click(object sender, EventArgs e)
        {
            bool isCurrentPasswordValid =  _IsCurrentPasswordValid();

            if(isCurrentPasswordValid)
            {
                await Task.Delay(1000);

                frmUpdatePassword frm = new frmUpdatePassword(_userID, _personID);
                frm.ShowDialog();
            }
        }

        // >>

        private bool _showHidePasswordClick = false;

        private void _SetPasswordCharacter(bool status)
        {
            if (_showHidePasswordClick)
            {
                txt_CurrentPassword.UseSystemPasswordChar = true;
                _showHidePasswordClick = false;
            }
            else
            {
                txt_CurrentPassword.UseSystemPasswordChar = false;
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

        
    }
}
