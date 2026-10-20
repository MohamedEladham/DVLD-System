using DVLD_BL;
using DVLD_Models.Permissions;
using DVLD_Models.Role;
using DVLD_Shared.Operations_Result;
using System.Collections.Generic;
using System.Windows.Forms;
using static DVLD_Shared.Operations_Result.clsOperationResult;

namespace DVLD_System_Solution.Forms._005_Manage_Roles_Permissions._001_User_Controls
{
    public partial class uconShowPermissionDetails : UserControl
    {
        public uconShowPermissionDetails()
        {
            InitializeComponent();
        }

        // >>
        private clsPermission _GetPermissionByID(int permissionID)
        {
            (clsOperationResult result, clsPermission permission) = clsPermissionBL.GetPermissionByPermissionID(permissionID);

            switch (result.Status)
            {
                case enOperationStatus.Success:
                    return permission;

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

        private void _LoadPermissionInfo(int permissionID)
        {
            clsPermission permission = _GetPermissionByID(permissionID);

            if (permission != null)
            {
                lab_PermissionID.Text = permission.PermissionID.ToString();
                lab_PermissionName.Text = permission.PermissionName;
                lab_Category.Text = string.IsNullOrWhiteSpace(permission.PermissionCategory) ? "???" : permission.PermissionCategory;
            }
        }


        // >>
        private List<string> _GetRoleNamesByPermissionID(int permissionID)
        {
            (clsOperationResult result, List<string> roleNames) = clsRolePermissionsBL.GetRoleNamesByPermissionID(permissionID);

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

        private void _LoadRoleNamesToListBox(int permissionID)
        {
            List<string> roleNames = _GetRoleNamesByPermissionID(permissionID);

            if (roleNames != null && roleNames.Count > 0)
                listB_RoleNames.DataSource = roleNames;
            else
                listB_RoleNames.Items.Add("No roles are assigned to this permission.");
        }


        // >>
        private void _FillUserControlByPermissionInfo(int permissionID)
        {
            _LoadPermissionInfo(permissionID);
            _LoadRoleNamesToListBox(permissionID);
        }


        // >>
        public void LoadPermissionInfoByPermissionID(int permissionID)
        {
            _FillUserControlByPermissionInfo(permissionID); 
        }
    }
}
