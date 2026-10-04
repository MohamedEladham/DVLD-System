using DVLD_BL;
using DVLD_Models.Role;
using DVLD_Models.Roles;
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
    public partial class frmUpdateUserRoles : Form
    {
        private int _userID = -1;
        private string _userName = "";

        public frmUpdateUserRoles(int userID, string userName)
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

        private List<string> _currentRoles = null;

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

        // >>

        List<clsActiveRolesInfoGridViewDto> _activeRoles = null;


        private List<clsActiveRolesInfoGridViewDto> _GetActiveRoles()
        {
            (clsOperationResult result, List<clsActiveRolesInfoGridViewDto> activeRoles) = clsRoleBL.GetActiveRoles();

            switch (result.Status)
            {
                case enOperationStatus.Success:
                    return activeRoles;

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
            _activeRoles = _GetActiveRoles();
            chB_Roles.DataSource = _activeRoles;
            chB_Roles.DisplayMember = "RoleName";
            chB_Roles.ValueMember = "RoleID";
        }


        // >>
        private void _CheckForCurrentRoles()
        {
            if (_currentRoles != null && _activeRoles != null)
            {
                for (int i = 0; i < chB_Roles.Items.Count; i++)
                {
                    var role = (clsActiveRolesInfoGridViewDto)chB_Roles.Items[i];

                    if (_currentRoles.Contains(role.RoleName))
                        chB_Roles.SetItemChecked(i, true);
                }
            }
        }

        private void _LoadData()
        {
            lab_UserID.Text = Convert.ToString(_userID);
            lab_UserName.Text = _userName;
            _LoadCurrentRolesToListBox();
            _LoadRolesToCheckedListBox();
            _CheckForCurrentRoles();
        }

        private void frmUpdateRoles_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        
        // >>
        public delegate void UpdateUserRoleEventHandler(object sender, bool isUpdateUserRole);
        public static event UpdateUserRoleEventHandler UpdateUserRole; 

        private List<int> _GteCheckedRoleIDs()
        {
            List<int> roleIDs = new List<int>();

            for (int i = 0; i < chB_Roles.CheckedItems.Count; i++)
            {
                var role = (clsActiveRolesInfoGridViewDto)chB_Roles.CheckedItems[i];
                roleIDs.Add(role.RoleID);
            }

            return roleIDs;
        }

        private bool _UpdateUserRoles() 
        {
            if (!clsCurrentUser.HasPermission(enPermissions.UpdateUserRoles))
            {
                MessageBox.Show(clsUserValidationMessages.PermissionDeniedMessage, "Permission Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            clsOperationResult result = clsRoleBL.UpdateUserRoles(_userID, _GteCheckedRoleIDs());

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
            if(_UpdateUserRoles()) _LoadCurrentRolesToListBox();
        }

        
        // >>
        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
