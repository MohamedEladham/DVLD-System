using System;
using DVLD_BL;
using DVLD_Shared;
using DVLD_BL.Services;
using DVLD_Models.Role;
using DVLD_Models.User;
using System.Windows.Forms;
using DVLD_Models.UI_Models;
using DVLD_Shared.Global_Classes;
using System.Collections.Generic;
using DVLD_Shared.Operations_Result;
using DVLD_Shared.Validation_Messages;
using static DVLD_Shared.Global_Enums.clsEnumHelpers;
using static DVLD_Shared.Operations_Result.clsOperationResult;
using DVLD_System_Solution.Forms._005_Manage_Roles._002_AddRoles;
using DVLD_System_Solution.Forms._005_Manage_Roles_Permissions._001_RolesManagements;
using DVLD_Models.Roles;

namespace DVLD_System_Solution.Forms._005_Manage_Roles._001_ShowRoles
{
    public partial class frmRolesManagements : Form
    {
        public frmRolesManagements()
        {
            InitializeComponent();
        }

        private int _GetID(string message)
        {
            var id = dataGridView_ShowRolesInfo.CurrentRow.Cells[message].Value;
            return id != null ? Convert.ToInt32(id) : -1;
        }

        private bool _HasPermission(enPermissions permissions)
        {
            if (!clsCurrentUser.HasPermission(permissions))
            {
                MessageBox.Show(clsUserValidationMessages.PermissionDeniedMessage, "Permission Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private bool _HasCurrentRowAndPermission(enPermissions permissions)
        {
            if (dataGridView_ShowRolesInfo.CurrentRow == null)
            {
                MessageBox.Show(clsGeneralValidationMessages.NoDataInDataGridMessage, "No Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!_HasPermission(permissions))
                return false;

            return true;
        }


        // >>
        private void txt_SearchValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            string filterSelected = comBox_FilterItems.SelectedValue.ToString();

            if (filterSelected == "RoleID")
            {
                // Allow control keys (Backspace, Delete, etc.)
                if (char.IsControl(e.KeyChar))
                    return;

                // Allow digits
                if (char.IsDigit(e.KeyChar))
                    return;

                // Allow '+' only at the beginning and only once
                //if (e.KeyChar == '+' && txt_SearchValue.SelectionStart == 0 && !txt_SearchValue.Text.Contains("+"))
                //    return;

                e.Handled = true;
            }
        }

        
        private void _UpdateContextMenues()
        {
            if (dataGridView_ShowRolesInfo.DataSource != null)
            {
                toolStripMenuItem_ShowActiveRoleDetails.Enabled = clsCurrentUser.HasPermission(enPermissions.ViewRoles);

                btn_AddNewRole.Enabled = clsCurrentUser.HasPermission(enPermissions.AddRoleAndPermissions);
                
                toolStripMenuItem_AddNewRole.Enabled = clsCurrentUser.HasPermission(enPermissions.AddRoleAndPermissions);

                toolStripMenuItem_UpdateRoleInfo.Enabled = clsCurrentUser.HasPermission(enPermissions.UpdateRoleAndPermissions);
                
                toolStripMenuItem_SoftDeleteRole.Enabled = clsCurrentUser.HasPermission(enPermissions.DeleteRole);

                toolStripMenuItem_ShowDeletedRoleDetails.Enabled = clsCurrentUser.HasPermission(enPermissions.ViewRoles);

                toolStripMenuItem_RestoreRole.Enabled = clsCurrentUser.HasPermission(enPermissions.RestoreRole);
            }
            else
            {
                toolStripMenuItem_ShowActiveRoleDetails.Enabled = false;

                btn_AddNewRole.Enabled = clsCurrentUser.HasPermission(enPermissions.AddRoleAndPermissions);

                toolStripMenuItem_AddNewRole.Enabled = clsCurrentUser.HasPermission(enPermissions.AddRoleAndPermissions);

                toolStripMenuItem_UpdateRoleInfo.Enabled = false;

                toolStripMenuItem_SoftDeleteRole.Enabled = false;

                toolStripMenuItem_ShowDeletedRoleDetails.Enabled = false;

                toolStripMenuItem_RestoreRole.Enabled = false;
            }
        }

        private void dataGridView_ShowRolesInfo_MouseDown(object sender, MouseEventArgs e)
        {
            _UpdateContextMenues();
        }


        // >>
        private void _ApplyFilter()
        {
            string searchValue = txt_SearchValue.Text.Trim();

            string selectedDisplayStatus = comBox_DisplayStatus.SelectedValue.ToString();

            if (string.IsNullOrWhiteSpace(searchValue))
            {
                if (selectedDisplayStatus == "ActiveRoles")
                    _BindData(_activeRoles);

                if (selectedDisplayStatus == "DeletedRoles")
                    _BindData(_deletedRoles);

                return;
            }

            string filterSelected = comBox_FilterItems.SelectedValue.ToString();

            if (_filtersForActiveRoles.ContainsKey(filterSelected))
            {
                if (selectedDisplayStatus == "ActiveRoles")
                {
                    List<clsActiveRolesInfoGridViewDto> activeRolesResult = clsRolesFilterService.ActiveRolesFilters(
                    _activeRoles, _filtersForActiveRoles, filterSelected, searchValue);
                    _BindData(activeRolesResult);
                }

                if (selectedDisplayStatus == "DeletedRoles")
                {
                    List<clsDeleteRolesInfoGridViewDto> deletedRolesResult = clsRolesFilterService.DeletedRolesFilters(
                    _deletedRoles, _filtersForDeletedRoles, filterSelected, searchValue);
                    _BindData(deletedRolesResult);
                }
            }
        }

        private void txt_SearchValue_TextChanged(object sender, EventArgs e)
        {
            _ApplyFilter();
        }


        // >>
        private void _UpdateComboBoxFilterItems()
        {
            if (dataGridView_ShowRolesInfo.DataSource == null)
            {
                comBox_FilterItems.SelectedValue = "None";
                comBox_FilterItems.Enabled = false;
            }
            else
                comBox_FilterItems.Enabled = true;
        }


        // >>
        private void _SetupComboBoxDisplayStatus()
        {
            List<clsComboBoxFilterItem> comboBoxFiltersItems = new List<clsComboBoxFilterItem>
            {
                new clsComboBoxFilterItem { Display = "Active Roles"       , Value = "ActiveRoles" },
                new clsComboBoxFilterItem { Display = "Deleted Roles"  , Value = "DeletedRoles" }
            };

            comBox_DisplayStatus.DataSource = comboBoxFiltersItems;
            comBox_DisplayStatus.DisplayMember = "Display";
            comBox_DisplayStatus.ValueMember = "Value";
        }

        private void _SetupComboBoxFilterItems()
        {
            List<clsComboBoxFilterItem> comboBoxFiltersItems = new List<clsComboBoxFilterItem>
            {
                new clsComboBoxFilterItem { Display = "None"       , Value = "None" },
                new clsComboBoxFilterItem { Display = "Role ID"  , Value   = "RoleID" },
                new clsComboBoxFilterItem { Display = "Role Name" , Value  = "RoleName" }
            };

            comBox_FilterItems.DataSource = comboBoxFiltersItems;
            comBox_FilterItems.DisplayMember = "Display";
            comBox_FilterItems.ValueMember = "Value";
        }

        private Dictionary<string, Func<clsActiveRolesInfoGridViewDto, string, bool>> _filtersForActiveRoles;
        private Dictionary<string, Func<clsDeleteRolesInfoGridViewDto, string, bool>> _filtersForDeletedRoles; 
        
        private void _SetComboBoxes()
        {
            _SetupComboBoxDisplayStatus();
            _SetupComboBoxFilterItems();
            _filtersForActiveRoles = clsRolesFilterService.GetActiveRolesFilters();
            _filtersForDeletedRoles = clsRolesFilterService.GetDeletedRolesFilters();
        }

        

        // >>
        List<clsActiveRolesInfoGridViewDto> _activeRoles = null;

        private void _BindData(List<clsActiveRolesInfoGridViewDto> activeRoles)
        {
            dataGridView_ShowRolesInfo.DataSource = activeRoles;

            if (activeRoles != null)
            {
                dataGridView_ShowRolesInfo.Columns["RoleID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView_ShowRolesInfo.Columns["IsDeleted"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }

            _UpdateComboBoxFilterItems();
            lab_RecordsCount.Text = activeRoles == null ? "0" : activeRoles.Count.ToString();
        }

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

        private void _LoadActiveRolesToDataGridView()
        {
            _activeRoles = _GetActiveRoles();
            _BindData(_activeRoles);
        }

        

        // >>
        private bool _isAddOrUpdateRole = false;

        private void _GetIsAddOrUpdateRole(object sender, bool mode)
        {
            _isAddOrUpdateRole = mode;
        }



        // >>
        private void frmShowRoles_Load(object sender, EventArgs e)
        {
            _SetComboBoxes();
            
            _LoadActiveRolesToDataGridView();
            
            btn_AddNewRole.Enabled = clsCurrentUser.HasPermission(enPermissions.AddRoleAndPermissions);

            frmAddUpdateRole.AddUpdateRole += _GetIsAddOrUpdateRole;
        }


        // >>
        List<clsDeleteRolesInfoGridViewDto> _deletedRoles = null;

        private void _BindData(List<clsDeleteRolesInfoGridViewDto> deletedRoles)
        {
            dataGridView_ShowRolesInfo.DataSource = deletedRoles;

            if (deletedRoles != null)
            {
                dataGridView_ShowRolesInfo.Columns["RoleID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView_ShowRolesInfo.Columns["IsDeleted"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }

            _UpdateComboBoxFilterItems();
            lab_RecordsCount.Text = deletedRoles == null ? "0" : deletedRoles.Count.ToString();
        }

        private List<clsDeleteRolesInfoGridViewDto> _GetDeletedRoles()
        {
            (clsOperationResult result, List<clsDeleteRolesInfoGridViewDto> deletedRoles) = clsRoleBL.GetDeletedRoles();

            switch (result.Status)
            {
                case enOperationStatus.Success:
                    return deletedRoles;

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

        private void _LoadDeletedRolesToDataGridView()
        {
            _deletedRoles = _GetDeletedRoles();
            _BindData(_deletedRoles);
        }


        // >>
        private void comBox_DisplayStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!(comBox_DisplayStatus.SelectedValue is string))
                return;

            comBox_FilterItems.SelectedValue = "None";

            string selectedValue = comBox_DisplayStatus.SelectedValue.ToString();

            switch (selectedValue)
            {
                case "ActiveRoles":
                    _LoadActiveRolesToDataGridView();
                    dataGridView_ShowRolesInfo.ContextMenuStrip = contextMenuStrip_ActiveRoles;
                    btn_AddNewRole.Visible = true;
                    break;

                case "DeletedRoles":
                    _LoadDeletedRolesToDataGridView();
                    dataGridView_ShowRolesInfo.ContextMenuStrip = contextMenuStrip_DeletedRoles;
                    btn_AddNewRole.Visible = false;
                    break;
            }
        }

        private void comBox_FilterItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!(comBox_FilterItems.SelectedValue is string))
                return;

            txt_SearchValue.Visible = (comBox_FilterItems.SelectedValue.ToString() != "None");

            txt_SearchValue.Clear();
            txt_SearchValue.Select();
        }


        // >>
        private void _OpenFormShowRoleDetails()
        {
            if (!_HasCurrentRowAndPermission(enPermissions.ViewRoles) || !_HasCurrentRowAndPermission(enPermissions.ViewRolePermissions))
                return;

            int roleID = _GetID("RoleID");

            frmShowRoleDetails frm = new frmShowRoleDetails(roleID);
            frm.ShowDialog();
        }

        private void toolStripMenuItem_ShowRoleDetails_Click(object sender, EventArgs e)
        {
            _OpenFormShowRoleDetails();
        }

        private void dataGridView_ShowRolesInfo_DoubleClick(object sender, EventArgs e)
        {
            _OpenFormShowRoleDetails();
        }
        
        
        // >>
        private void _OpenFormAddUpdateRole(enAddUpdateMode mode, int roleID = -1)
        {
            frmAddUpdateRole frm = new frmAddUpdateRole(mode, roleID);
            frm.ShowDialog();

            if(_isAddOrUpdateRole)
            {
                _LoadActiveRolesToDataGridView();
                _isAddOrUpdateRole = false;
            }
        }

        private void btn_AddNewRole_Click(object sender, EventArgs e)
        {
            if (!_HasCurrentRowAndPermission(enPermissions.AddRoleAndPermissions) ||
                !_HasCurrentRowAndPermission(enPermissions.ViewRolePermissions) ||
                !_HasCurrentRowAndPermission(enPermissions.ViewPermissions))
                return;

            _OpenFormAddUpdateRole(enAddUpdateMode.AddNewInfo);
        }

        private void toolStripMenuItem_AddNewRole_Click(object sender, EventArgs e)
        {
            if (!_HasCurrentRowAndPermission(enPermissions.AddRoleAndPermissions) ||
                !_HasCurrentRowAndPermission(enPermissions.ViewRolePermissions) ||
                !_HasCurrentRowAndPermission(enPermissions.ViewPermissions))
                return;

            _OpenFormAddUpdateRole(enAddUpdateMode.AddNewInfo);
        }


        // >>
        private void toolStripMenuItem_UpdateRoleInfo_Click(object sender, EventArgs e)
        {
            if (!_HasCurrentRowAndPermission(enPermissions.UpdateRoleAndPermissions) ||
                !_HasCurrentRowAndPermission(enPermissions.ViewRolePermissions) ||
                !_HasCurrentRowAndPermission(enPermissions.ViewPermissions))
                return;

            _OpenFormAddUpdateRole(enAddUpdateMode.UpdateInfo, _GetID("RoleID"));
        }



        // >>
        private string _GetColumnName(string columnName)
        {
            if (dataGridView_ShowRolesInfo.CurrentRow.Cells[columnName].Value != null &&
                dataGridView_ShowRolesInfo.CurrentRow.Cells[columnName].Value != DBNull.Value)
                return dataGridView_ShowRolesInfo.CurrentRow.Cells[columnName].Value.ToString();
            else
                return "???";
        }

        private bool _SoftDeleteRole()
        {
            if (!_HasCurrentRowAndPermission(enPermissions.DeleteRole))
                return false;

            DialogResult dialogResult =
               MessageBox.Show("Are you sure you want to delete this role? \n\n" +
               $">> RoleID   : {_GetColumnName("RoleID")}   \n" +
               $">> Role Name: {_GetColumnName("RoleName")} \n" +
               $">> Description: {_GetColumnName("Description")} \n",
               "Delete Role",
               MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (dialogResult != DialogResult.Yes)
                return false;

            int roleID = _GetID("roleID");

            clsOperationResult isRoleUsedResult = clsUserRolesBL.IsRoleUsedInAnyUser(roleID);

            switch (isRoleUsedResult.Status)
            {
                case enOperationStatus.Failed:
                    MessageBox.Show(isRoleUsedResult.Message, "Operation Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;

                case enOperationStatus.Exception:
                    MessageBox.Show(isRoleUsedResult.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
            }

            clsOperationResult result = clsRoleBL.SoftDeleteRoleAndDeleteRolePermission(roleID);

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

        private void toolStripMenuItem_SoftDeleteRole_Click(object sender, EventArgs e)
        {
            if (_SoftDeleteRole()) _LoadActiveRolesToDataGridView();
        }

        
        // >> 
        private bool _RestoreRole()
        {
            if (!_HasCurrentRowAndPermission(enPermissions.RestoreRole))
                return false;

            DialogResult dialogResult =
               MessageBox.Show("Are you sure you want to restore this role? \n\n" +
               $">> RoleID   : {_GetColumnName("RoleID")}   \n" +
               $">> Role Name: {_GetColumnName("RoleName")} \n" +
               $">> Description: {_GetColumnName("Description")} \n",
               "Restore Role",
               MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);


            if (dialogResult != DialogResult.Yes)
                return false;

            int roleID = _GetID("roleID");

            clsOperationResult result = clsRoleBL.RestoreRole(roleID);

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

        private void toolStripMenuItem_RestoreRole_Click(object sender, EventArgs e)
        {
            if (_RestoreRole()) _LoadDeletedRolesToDataGridView();
        }

      
        // >>
        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
