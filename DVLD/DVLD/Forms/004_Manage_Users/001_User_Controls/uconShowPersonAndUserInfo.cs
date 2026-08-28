using System;
using DVLD_BL;
using System.IO;
using System.Drawing;
using DVLD_Models.User;
using System.Windows.Forms;
using DVLD_Shared.Global_Classes;
using DVLD_Shared.Operations_Result;
using static DVLD_Shared.Global_Enums.clsEnumHelpers;
using static DVLD_Shared.Operations_Result.clsOperationResult;
using DVLD_Models.Role;
using System.Collections.Generic;

namespace DVLD_System_Solution.Forms._004_Manage_Users.Controls
{
    public partial class uconShowPersonAndUserInfo : UserControl
    {
        public uconShowPersonAndUserInfo()
        {
            InitializeComponent();
        }

        public void SetLinkLabelEditPerson(enPersonStatus personStatus)
        {
            uconShowPersonInfo1.SetLinkLabelEditPerson(personStatus);
        }

        // >>

        private clsUser _GetUserByID(int userID)
        {
            (clsOperationResult result, clsUser user) = clsUserBL.GetUserByUserID(userID);

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

        private List<string> _GetRoleNamesByUserID(int userID)
        {
            (clsOperationResult result, List<string> roleNames) = clsRoleBL.GetRoleNamesByUserID(userID);

            switch (result.Status)
            {
                case enOperationStatus.Success:
                    return roleNames;

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

        private void _DisplayRoleNames(List<string> roleNames)
        {
            Label label = new Label();
            label.AutoSize = true;
            label.Text = string.Join(", ", roleNames);
            panel1.Controls.Add(label);
        }

        private void _LoadUserByID(int userID) 
        {
            clsUser user = _GetUserByID(userID);

            if(user != null)
            {
                List<string> roleNames = _GetRoleNamesByUserID(userID);

                if(roleNames != null)
                {
                    lab_UserID.Text = Convert.ToString(user.UserID);
                    lab_UserName.Text = Convert.ToString(user.UserName);
                    _ResetLabelIsActive(user.IsActive);
                    _DisplayRoleNames(roleNames);
                }
            }
        }
        
        
        public void LoadPersonAndUserInfo(int personID, int userID)
        {
            uconShowPersonInfo1.LoadPersonByID(personID);
            _LoadUserByID(userID);
        }
    }
}
