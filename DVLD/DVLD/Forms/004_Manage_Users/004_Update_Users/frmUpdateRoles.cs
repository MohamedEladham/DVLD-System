using DVLD_BL;
using DVLD_Models.Role;
using DVLD_Models.User;
using DVLD_Shared.Global_Classes;
using DVLD_Shared.Operations_Result;
using DVLD_Shared.Validation_Messages;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;
using static DVLD_Shared.Operations_Result.clsOperationResult;

namespace DVLD_System_Solution.Forms._004_Manage_Users._004_Update_Users
{
    public partial class frmUpdateRoles : Form
    {
        private int _userID = -1;
        private string _userName = "";

        public frmUpdateRoles(int userID, string userName)
        {
            InitializeComponent();
            _userID = userID;
            _userName = userName;
        }

        private void chB_Roles_SelectedIndexChanged(object sender, EventArgs e)
        {
            chB_Roles.SelectedIndex = -1;
        }


        // >>

        List<string> _currentRoles = new List<string>();

        private List<string> _GetCurrentRoleNamesByUserID(int userID)
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

        private void _LoadCurrentRolesToListBox()
        {
            _currentRoles = _GetCurrentRoleNamesByUserID(_userID);
            listB_CurrentRoles.DataSource = _currentRoles;
        }


        List<clsRole> _roles = new List<clsRole>();

        private List<clsRole> _GetAllRoles()
        {
            (clsOperationResult result, List<clsRole> roles) = clsRoleBL.GetAllRoles();

            switch (result.Status)
            {
                case enOperationStatus.Success:
                    return roles;

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

        private void _LoadRolesToCheckedListBox()
        {
            _roles = _GetAllRoles();

            if (_roles != null)
            {
                chB_Roles.DataSource = _roles;
                chB_Roles.DisplayMember = "RoleName";
                chB_Roles.ValueMember = "RoleID";
            }
        }

        private void _CheckForCurrentRoles()
        {
            if (_currentRoles != null && _roles != null)
            {
                for (int i = 0; i < chB_Roles.Items.Count; i++)
                {
                    clsRole role = (clsRole)chB_Roles.Items[i];

                    if (_currentRoles.Contains(role.RoleName))
                        chB_Roles.SetItemChecked(i, true);
                }
            }
        }

        private void frmUpdateRoles_Load(object sender, EventArgs e)
        {
            lab_UserID.Text = Convert.ToString(_userID);
            lab_UserName.Text = _userName;
            _LoadCurrentRolesToListBox();
            _LoadRolesToCheckedListBox();
            _CheckForCurrentRoles();
        }

        // >>
        private List<int> _GteCheckedRoleIDs()
        {
            List<int> roleIDs = new List<int>();

            for (int i = 0; i < chB_Roles.CheckedItems.Count; i++)
            {
                clsRole role = (clsRole)chB_Roles.CheckedItems[i];
                roleIDs.Add(role.RoleID);
            }

            return roleIDs;
        }

        public delegate void UpdateUserRoleEventHandler(object sender, bool isUpdateUserRole);
        public static event UpdateUserRoleEventHandler UpdateUserRole; 

        private bool _UpdateUserRoles() 
        {
            List<int> roleIDs = _GteCheckedRoleIDs();

            clsOperationResult result = clsRoleBL.UpdateUserRoles(_userID, roleIDs);

            switch (result.Status)
            {
                case enOperationStatus.Success:
                    UpdateUserRole?.Invoke(this, true);
                    MessageBox.Show(result.Message, "Operation Successed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;

                case enOperationStatus.Failed:
                    MessageBox.Show(result.Message, "Operation Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;

                case enOperationStatus.Exception:
                    MessageBox.Show(result.Message, "Database Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;

                default:
                    return false;
            }
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (!clsCurrentUser.HasPermission(enPermissions.UpdateUserRoles))
            {
                MessageBox.Show(clsUserValidationMessages.PermissionDeniedMessage, "Permission Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool isUpdated = _UpdateUserRoles();

            if(isUpdated)
                _LoadCurrentRolesToListBox();
        }

        
        // >>
        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
