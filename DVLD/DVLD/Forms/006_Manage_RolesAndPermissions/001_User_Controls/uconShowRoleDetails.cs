using DVLD_BL;
using DVLD_Models.Role;
using System.Windows.Forms;
using DVLD_Models.Permissions;
using System.Collections.Generic;
using DVLD_Shared.Operations_Result;
using static DVLD_Shared.Operations_Result.clsOperationResult;

namespace DVLD_System_Solution.Forms._005_Manage_Roles_Permissions._001_User_Controls
{
    public partial class uconShowRoleDetails : UserControl
    {
        public uconShowRoleDetails()
        {
            InitializeComponent();
        }

        private clsRole _GetRoleByID(int roleID)
        {
            (clsOperationResult result, clsRole role) = clsRoleBL.GetRoleByRoleID(roleID);

            switch (result.Status)
            {
                case enOperationStatus.Success:
                    return role;

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

        private void _LoadRoleInfo(int roleID)
        {
            clsRole role = _GetRoleByID(roleID);

            if (role != null)
            {
                lab_RoleID.Text = role.RoleID.ToString();
                lab_RoleName.Text = role.RoleName;
                lab_Description.Text = string.IsNullOrWhiteSpace(role.Description) ? "???" : role.Description;
            }
        }

        
        // >>
        private List<string> _GetUserNamesByRoleID(int roleID)
        {
            (clsOperationResult result, List<string> userNames) = clsUserRolesBL.GetUserNamesByRoleID(roleID);

            switch (result.Status)
            {
                case enOperationStatus.Success:
                    return userNames;

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

        private void _LoadUserNamesToListBox(int roleID)
        {
            List<string> userNames = _GetUserNamesByRoleID(roleID);

            if (userNames != null && userNames.Count > 0)
                listB_UsedBy.DataSource = userNames;
            else
                listB_UsedBy.Items.Add("No users are assigned to this role.");
        }

        
        // >>
        private List<string> _GetRolePermissionNames(int roleID)
        {
            (clsOperationResult result, List<string> permissionNames) = clsRolePermissionsBL.GetRolePermissionNames(roleID);

            switch (result.Status)
            {
                case enOperationStatus.Success:
                    return permissionNames;

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

        private void _LoadPermissionNamesToListBox(int roleID)
        {
            List<string> permissionNames = _GetRolePermissionNames(roleID);

            if (permissionNames != null && permissionNames.Count > 0)
                listB_RolePermissions.DataSource = permissionNames;
            else
                listB_RolePermissions.Items.Add("No Permissions");
        }


        // >>
        private void _FillUserControlByRoleInfo(int roleID)
        {
            _LoadRoleInfo(roleID);
            _LoadUserNamesToListBox(roleID);
            _LoadPermissionNamesToListBox(roleID);
        }


        // >>
        public void LoadRoleInfoByRoleID(int roleID) 
        {
            _FillUserControlByRoleInfo(roleID);
        }
    }
}
