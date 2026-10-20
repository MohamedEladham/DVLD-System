using DVLD_BL;
using DVLD_BL.Services;
using DVLD_Models.Permissions;
using DVLD_Models.UI_Models;
using DVLD_Models.User;
using DVLD_Shared;
using DVLD_Shared.Global_Classes;
using DVLD_Shared.Operations_Result;
using DVLD_Shared.Validation_Messages;
using DVLD_System_Solution.Forms._005_Manage_Roles_Permissions._003_PermissionsManagements._002_Add_Update_Permissions;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static DVLD_Shared.Global_Enums.clsEnumHelpers;
using static DVLD_Shared.Operations_Result.clsOperationResult;

namespace DVLD_System_Solution.Forms._005_Manage_Roles_Permissions._003_PermissionsManagements._001_Manage_Permissions
{
    public partial class frmPermissionsManagement : Form
    {
        public frmPermissionsManagement()
        {
            InitializeComponent();
        }

        private int _GetID(string message)
        {
            var id = dataGridView_ShowPermissionsInfo.CurrentRow.Cells[message].Value;
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
            if (dataGridView_ShowPermissionsInfo.CurrentRow == null)
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

            if (filterSelected == "PermissionID")
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

        private void comBox_FilterItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comBox_FilterItems.Text == "None")
                txt_SearchValue.Visible = false;
            else
                txt_SearchValue.Visible = true;
            txt_SearchValue.Clear();
            txt_SearchValue.Select();
        }

        private void _UpdateContextMenues()
        {
            if (dataGridView_ShowPermissionsInfo.DataSource != null)
            {
                toolStripMenuItem_ShowActivePermissionDetails.Enabled = clsCurrentUser.HasPermission(enPermissions.ViewPermissions);

                btn_AddNewPermission.Enabled = clsCurrentUser.HasPermission(enPermissions.AddPermissions);

                toolStripMenuItem_AddNewPermission.Enabled = clsCurrentUser.HasPermission(enPermissions.AddPermissions);

                toolStripMenuItem_UpdatePermission.Enabled = clsCurrentUser.HasPermission(enPermissions.UpdatePermissions);

                toolStripMenuItem_DisablingPermission.Enabled = clsCurrentUser.HasPermission(enPermissions.DisablingPermissions);

                toolStripMenuItem_ShowDeletedPermissionDetails.Enabled = clsCurrentUser.HasPermission(enPermissions.ViewPermissions);

                toolStripMenuItem_ActivePermission.Enabled = clsCurrentUser.HasPermission(enPermissions.ActivePermissions);
            }
            else
            {
                toolStripMenuItem_ShowActivePermissionDetails.Enabled = false;

                btn_AddNewPermission.Enabled = clsCurrentUser.HasPermission(enPermissions.AddPermissions);

                toolStripMenuItem_AddNewPermission.Enabled = clsCurrentUser.HasPermission(enPermissions.AddPermissions);

                toolStripMenuItem_UpdatePermission.Enabled = false;

                toolStripMenuItem_DisablingPermission.Enabled = false;

                toolStripMenuItem_ShowDeletedPermissionDetails.Enabled = false;

                toolStripMenuItem_ActivePermission.Enabled = false;
            }
        }

        private void dataGridView_ShowPermissionsInfo_MouseDown(object sender, MouseEventArgs e)
        {
            _UpdateContextMenues();
        }


        // >>
        private void _UpdateComboBoxFilterItems()
        {
            if (dataGridView_ShowPermissionsInfo.DataSource == null)
            {
                comBox_FilterItems.SelectedValue = "None";
                comBox_FilterItems.Enabled = false;
            }
            else
                comBox_FilterItems.Enabled = true;
        }


        // >>
        private Dictionary<string, Func<clsPermission, string, bool>> _permissionsFilters;
        
        private void _SetupComboBoxRolesStatusItems()
        {
            List<clsComboBoxFilterItem> comboBoxFiltersItems = new List<clsComboBoxFilterItem>
            {
                new clsComboBoxFilterItem { Display = "Active Permissions"       , Value = "ActivePermissions" },
                new clsComboBoxFilterItem { Display = "In Active Permissions"  , Value = "DisablingPermissions" }
            };

            comBox_DisplayStatus.DataSource = comboBoxFiltersItems;
            comBox_DisplayStatus.DisplayMember = "Display";
            comBox_DisplayStatus.ValueMember = "Value";
            comBox_DisplayStatus.Text = "Active Permissions";
        }

        private void _SetupComboBoxFilterItems()
        {
            List<clsComboBoxFilterItem> comboBoxFiltersItems = new List<clsComboBoxFilterItem>
            {
                new clsComboBoxFilterItem { Display = "None"       , Value = "None" },
                new clsComboBoxFilterItem { Display = "Permission ID"  , Value   = "PermissionID" },
                new clsComboBoxFilterItem { Display = "Permission Name" , Value  = "PermissionName" },
                new clsComboBoxFilterItem { Display = "Permission Category" , Value  = "PermissionCategory" }
            };

            comBox_FilterItems.DataSource = comboBoxFiltersItems;
            comBox_FilterItems.DisplayMember = "Display";
            comBox_FilterItems.ValueMember = "Value";
            comBox_FilterItems.Text = "None";
        }

        private void _SetupRolesFilters()
        {
            _SetupComboBoxRolesStatusItems();
            _SetupComboBoxFilterItems();
            _permissionsFilters = clsPermissionsFilterService.GetPermissionsFilters();
        }



        // >>
        List<clsPermission> _permissions = null;

        private void _BindData(List<clsPermission> permissions)
        {
            dataGridView_ShowPermissionsInfo.DataSource = permissions;

            if (permissions != null)
            {
                dataGridView_ShowPermissionsInfo.Columns["PermissionID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView_ShowPermissionsInfo.Columns["IsActive"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }

            _UpdateComboBoxFilterItems();
            lab_RecordsCount.Text = permissions == null ? "0" : permissions.Count.ToString();
        }


        // >>
        private List<clsPermission> _GetActivePermissions()
        {
            (clsOperationResult result, List<clsPermission> activePermissions) = clsPermissionBL.GetActivePermissions();

            switch (result.Status)
            {
                case enOperationStatus.Success:
                    return activePermissions;

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

        private void _LoadActivePermissionsToDataGridView()
        {
            _permissions = _GetActivePermissions();
            _BindData(_permissions);
        }



        // >>
        private bool _isAddOrUpdatePermission = false;

        private void _GetIsAddOrUpdatePermission(object sender, bool mode)
        {
            _isAddOrUpdatePermission = mode;
        }

        
        // >>
        private DialogResult _inActivePermissionDialogResult = DialogResult.No;

        private void _GetInActivePermissionDialogResult(object sender, DialogResult dialogResult)
        {
            _inActivePermissionDialogResult = dialogResult;
        }



        // >>
        private void frmPermissionsManagement_Load(object sender, EventArgs e)
        {
            _SetupRolesFilters();
            _LoadActivePermissionsToDataGridView();

            btn_AddNewPermission.Enabled = clsCurrentUser.HasPermission(enPermissions.AddPermissions);

            frmAddUpdatePermission.AddUpdatePermission += _GetIsAddOrUpdatePermission;
        }

     

        // >>
        private List<clsPermission> _GetInActivePermissions()
        {
            (clsOperationResult result, List<clsPermission> inActivePermissions) = clsPermissionBL.GetInActivePermissions();

            switch (result.Status)
            {
                case enOperationStatus.Success:
                    return inActivePermissions;

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

        private void _LoadInActivePermissionsToDataGridView() 
        {
            _permissions = _GetInActivePermissions();
            _BindData(_permissions);
        }

        // >> 

        private void _ApplyFilter()
        {
            string searchValue = txt_SearchValue.Text.Trim();

            string selectedDisplayStatus = comBox_DisplayStatus.SelectedValue.ToString();

            if (string.IsNullOrWhiteSpace(searchValue))
            {
                _BindData(_permissions);
                return;
            }

            string filterSelected = comBox_FilterItems.SelectedValue.ToString();

            if (_permissionsFilters.ContainsKey(filterSelected))
            {
                List<clsPermission> permissionsResult = clsPermissionsFilterService.PermissionsFilters(
                    _permissions, _permissionsFilters, filterSelected, searchValue);
                _BindData(permissionsResult);
            }
        }

        private void txt_SearchValue_TextChanged(object sender, EventArgs e)
        {
            _ApplyFilter();
        }



        // >>
        private void comBox_DisplayStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            comBox_FilterItems.SelectedValue = "None";

            string selectedValue = comBox_DisplayStatus.SelectedValue.ToString();

            switch (selectedValue)
            {
                case "ActivePermissions":
                    _LoadActivePermissionsToDataGridView();
                    dataGridView_ShowPermissionsInfo.ContextMenuStrip = contextMenuStrip_ActivePermissions;
                    btn_AddNewPermission.Visible = true;
                    break;

                case "DisablingPermissions":
                    _LoadInActivePermissionsToDataGridView();
                    dataGridView_ShowPermissionsInfo.ContextMenuStrip = contextMenuStrip_InActivePermissions;
                    btn_AddNewPermission.Visible = false;
                    break;
            }
        }



        // >>
        private void _OpenFormShowPermissionDetails()
        {
            if (!_HasCurrentRowAndPermission(enPermissions.ViewPermissions))
                return;

            int PermissionID = _GetID("PermissionID");

            frmShowPermissionDetails frm = new frmShowPermissionDetails(PermissionID);
            frm.ShowDialog();
        }

        private void _ShowPermissionDetails(object sender, EventArgs e)
        {
            _OpenFormShowPermissionDetails();
        }



        // >>
        private void _OpenFormAddUpdatePermission(enAddUpdateMode mode, int permissionID = -1) 
        {
            frmAddUpdatePermission frm = new frmAddUpdatePermission(mode, permissionID);
            frm.ShowDialog();

            if(_isAddOrUpdatePermission)
            {
                _LoadActivePermissionsToDataGridView();
                _isAddOrUpdatePermission = false;
            }
        }

        private void _AddNewPermission_Click(object sender, EventArgs e)
        {
            if (!_HasPermission(enPermissions.AddPermissions))
                return;

            _OpenFormAddUpdatePermission(enAddUpdateMode.AddNewInfo);
        }

        private void _UpdatePermission_Click(object sender, EventArgs e)
        {
            if (!_HasPermission(enPermissions.UpdatePermissions))
                return;

            _OpenFormAddUpdatePermission(enAddUpdateMode.UpdateInfo, _GetID("PermissionID"));
        }



        // >>

        private string _GetColumnName(string columnName)
        {
            if (dataGridView_ShowPermissionsInfo.CurrentRow.Cells[columnName].Value != null &&
                dataGridView_ShowPermissionsInfo.CurrentRow.Cells[columnName].Value != DBNull.Value)
                return dataGridView_ShowPermissionsInfo.CurrentRow.Cells[columnName].Value.ToString();
            else
                return "???";
        }

        private bool _DisablingPermission()
        {
            if (!_HasCurrentRowAndPermission(enPermissions.DisablingPermissions))
                return false;

            //DialogResult dialogResult =
            //   MessageBox.Show("Are you sure you want to disabling this Permission?", "Disabling Permission", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            DialogResult dialogResult =
               MessageBox.Show("Are you sure you want to disabling this Permission? \n\n" +
               $">> PermissionID   : {_GetColumnName("PermissionID")}   \n" +
               $">> Permission Name: {_GetColumnName("PermissionName")} \n" +
               $">> Permission Category: {_GetColumnName("PermissionCategory")} \n",
               "Disabling Permission",
               MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (dialogResult != DialogResult.Yes)
                return false;

            int permissionID = _GetID("PermissionID");


            clsOperationResult isPermissionUsedResult = clsRolePermissionsBL.IsPermissionUsedInAnyRole(permissionID);

            switch(isPermissionUsedResult.Status)
            {
                case enOperationStatus.Failed:
                    MessageBox.Show(isPermissionUsedResult.Message, "Operation Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;

                case enOperationStatus.Exception:
                    MessageBox.Show(isPermissionUsedResult.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
            }


            clsOperationResult disablingPermissionResult = clsPermissionBL.DisablingPermission(permissionID);

            switch (disablingPermissionResult.Status)
            {
                case enOperationStatus.Success:
                    MessageBox.Show(disablingPermissionResult.Message, "Operation Succeeded", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;

                case enOperationStatus.Failed:
                    MessageBox.Show(disablingPermissionResult.Message, "Operation Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;

                case enOperationStatus.Exception:
                    MessageBox.Show(disablingPermissionResult.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;

                default:
                    return false;
            }
        }

        private void _DisablingPermission_Click(object sender, EventArgs e)
        {
            if (_DisablingPermission()) _LoadActivePermissionsToDataGridView();
        }



        // >>
        private bool _ActivePermission()
        {
            if (!_HasCurrentRowAndPermission(enPermissions.ActivePermissions))
                return false;

            //DialogResult dialogResult =
            //   MessageBox.Show("Are you sure you want to active this permission?", "Active Permission", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            DialogResult dialogResult =
               MessageBox.Show("Are you sure you want to active this Permission? \n\n" +
               $">> PermissionID   : {_GetColumnName("PermissionID")}   \n" +
               $">> Permission Name: {_GetColumnName("PermissionName")} \n" +
               $">> Permission Category: {_GetColumnName("PermissionCategory")} \n",
               "Active Permission",
               MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);


            if (dialogResult != DialogResult.Yes)
                return false;

            int permissionID = _GetID("PermissionID");

            clsOperationResult result = clsPermissionBL.ActivePermission(permissionID);

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

        private void _ActivePermission_Click(object sender, EventArgs e)
        {
            if (_ActivePermission()) _LoadInActivePermissionsToDataGridView();
        }


        // >>
        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
