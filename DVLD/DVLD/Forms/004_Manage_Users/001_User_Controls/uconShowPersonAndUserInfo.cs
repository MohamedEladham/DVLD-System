using DVLD_BL;
using DVLD_Models.User;
using DVLD_Shared.Global_Classes;
using DVLD_Shared.Operations_Result;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using static DVLD_Shared.Operations_Result.clsOperationResult;

namespace DVLD_System_Solution.Forms._004_Manage_Users.Controls
{
    public partial class uconShowPersonAndUserInfo : UserControl
    {
        public uconShowPersonAndUserInfo()
        {
            InitializeComponent();
        }

        private void _SetDefaultActiveUserImage(bool status)
        {
            string imagePath = clsImageHelper.GetOrCreateResourcesImageFolderPath();

            if (status)
                imagePath = Path.Combine(imagePath, "Active_User_32.png");
            else
                imagePath = Path.Combine(imagePath, "Not_Active_User_32.png");

            Image image = clsImageHelper.LoadImageSafe(imagePath);

            if (image != null)
            {
                picB_ActiveStatus.Image = image;
            }
        }

        private void _ResetLabelIsActive(bool status)
        {
            lab_IsActive.Text = Convert.ToString(status);
            lab_IsActive.ForeColor = status ? Color.LimeGreen : Color.Firebrick;
            _SetDefaultActiveUserImage(status);
        }

        private void _FillUserInfo(clsUser user)
        {
            lab_UserID.Text = Convert.ToString(user.UserID);
            lab_UserName.Text = Convert.ToString(user.UserName);
            _ResetLabelIsActive(user.IsActive);
        }

        private void _GetUserByID(int userID)
        {
            (clsOperationResult result, clsUser user) = clsUserBL.GetUserByID(userID);

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
        public void LoadPersonAndUserInfo(int personID, int userID)
        {
            uconShowPersonInfo1.LoadPersonByID(personID);
            _GetUserByID(userID);
        }
    }
}
