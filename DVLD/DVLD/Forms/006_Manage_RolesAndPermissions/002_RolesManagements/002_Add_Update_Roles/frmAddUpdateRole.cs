using System;
using DVLD_BL;
using DVLD_Models.Role;
using DVLD_BL.Validations;
using System.Windows.Forms;
using DVLD_Shared.Operations_Result;
using static DVLD_Shared.Operations_Result.clsOperationResult;
using static DVLD_Shared.Global_Enums.clsEnumHelpers;
using System.Drawing;
using DVLD_Models.Permissions;
using System.Collections.Generic;
using DVLD_Models.User;
using DVLD_Shared.Global_Classes;
using System.Security;
using DVLD_Shared.Validation_Messages;
using DVLD_BL.Services;
using DVLD_Models.UI_Models;
using System.Security.Permissions;
using System.IO;

namespace DVLD_System_Solution.Forms._005_Manage_Roles._002_AddRoles
{
    public partial class frmAddUpdateRole : Form
    {
        private int _roleID = -1;
        enAddUpdateMode _addUpdateMode = enAddUpdateMode.AddNewInfo;

        public frmAddUpdateRole(enAddUpdateMode addUpdateMode, int roleID = -1) 
        {
            InitializeComponent();
            _addUpdateMode = addUpdateMode;
            _roleID = roleID;
        }


        // >>
        private bool _checkedNotCheckedStatus = false;

        private void _SetDefaultCheckedOrNotCheckedPermissionsImage(bool status)
        {
            string imagePath = clsImageHelper.GetOrCreateResourcesImageFolderPath();

            if (status)
                imagePath = Path.Combine(imagePath, "CheckedListBox_32.png");
            else
                imagePath = Path.Combine(imagePath, "NotCheckedListBox_32.png");

            Image image = clsImageHelper.LoadImageSafe(imagePath);

            if (image != null)
            {
                picB_CheckedNotCheckedPermissions.Image = image;
            }
        }

        private void _CheckedOrNotCheckedAllRolePermissions(bool mode)
        {
            if (chB_Permissions.DataSource != null)
            {
                for (int i = 0; i < chB_Permissions.Items.Count; i++)
                    chB_Permissions.SetItemChecked(i, mode);
            }
        }

        private void picB_CheckedNotCheckedPermissions_Click(object sender, EventArgs e)
        {
            _checkedNotCheckedStatus = _checkedNotCheckedStatus ? false : true;
            _SetDefaultCheckedOrNotCheckedPermissionsImage(_checkedNotCheckedStatus);
            _CheckedOrNotCheckedAllRolePermissions(_checkedNotCheckedStatus);
        }


        // >>
        private bool _HasPermission(enPermissions permissions)
        {
            if (!clsCurrentUser.HasPermission(permissions))
            {
                MessageBox.Show(clsUserValidationMessages.PermissionDeniedMessage, "Permission Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void TextBoxies_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError((Control)sender, string.Empty);
        }

        private void TextBoxies_MouseClick(object sender, MouseEventArgs e)
        {
            errorProvider1.SetError((Control)sender, string.Empty);
        }

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
            if (!(comBox_FilterItems.SelectedValue is string))
                return;

            txt_SearchValue.Visible = (comBox_FilterItems.SelectedValue.ToString() != "None");

            txt_SearchValue.Clear();
            txt_SearchValue.Select();
        }


        // >>
        private void _UpdateModeStatusLabel()
        {
            switch (_addUpdateMode)
            {
                case enAddUpdateMode.AddNewInfo:
                    lab_ModeStatue1.Text = "Add New Role";
                    lab_ModeStatue2.Text = "Add Permissions";
                    break;

                case enAddUpdateMode.UpdateInfo:
                    lab_ModeStatue1.Location = new Point(165, 36);
                    lab_ModeStatue1.Text = "Update Role";
                    lab_ModeStatue2.Text = "Update Permissions";
                    break;
            }
        }
        
        
        private Dictionary<string, Func<clsPermission, string, bool>> _permissionsFilters;

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
        }

        private void _SetFilters()
        {
            _SetupComboBoxFilterItems();
            _permissionsFilters = clsPermissionsFilterService.GetPermissionsFilters();
        }


        // >>
        private List<clsPermission> _permissions = null;

        private void _BindData(List<clsPermission> permissions)
        {
            chB_Permissions.DataSource = permissions;
            chB_Permissions.DisplayMember = "PermissionName";
            chB_Permissions.ValueMember = "PermissionID";
        }

        private List<clsPermission> _GetActivePermissions()
        {
            (clsOperationResult result, List<clsPermission> activePermissions) = clsPermissionBL.GetActivePermissions();

            switch (result.Status)
            {
                case enOperationStatus.Success:
                    return activePermissions;

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
        
        private void _LoadActivePermissionsToCheckedListBox()
        {
            _permissions = _GetActivePermissions();
            _BindData(_permissions);
        }


        // >>
        private List<int> _currentRolePermissionIDs = null;
        
        private clsRole _GetRoleInfoByRoleID(int roleID)
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

        private List<int> _GetCurrentRolePermissionIDs() 
        {
            (clsOperationResult result, List<int> rolePermissionIDs) = clsRolePermissionsBL.GetRolePermissionIDs(_roleID);

            switch (result.Status)
            {
                case enOperationStatus.Success:
                    return rolePermissionIDs;

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

        private void _CheckedListBoxByCurrentRolePermissions()
        {
            if (chB_Permissions.DataSource != null && chB_Permissions.Items.Count > 0 && _currentRolePermissionIDs != null)
            {
                for (int i = 0; i < chB_Permissions.Items.Count; i++)
                {
                    clsPermission permission = (clsPermission)chB_Permissions.Items[i];

                    if (_currentRolePermissionIDs.Contains(permission.PermissionID))
                        chB_Permissions.SetItemChecked(i, true);
                    else
                        chB_Permissions.SetItemChecked(i, false);
                }
            }
        }

        private void _FillFormByRoleInfo(clsRole role)
        {
            lab_RoleID.Text = role.RoleID.ToString();
            txt_RoleName.Text = role.RoleName;
            txt_Description.Text = role.Description;
            _CheckedListBoxByCurrentRolePermissions();
        }

        private void _LoadRoleAndCurrentRolePermissions(int roleID)
        {
            clsRole role = _GetRoleInfoByRoleID(roleID);

            if (role != null)
            {
                _currentRolePermissionIDs = _GetCurrentRolePermissionIDs();
                _FillFormByRoleInfo(role);
            }
        }

        private void frmAddUpdateRole_Load(object sender, EventArgs e)
        {
            _SetFilters();
            _UpdateModeStatusLabel();
            _LoadActivePermissionsToCheckedListBox();

            if (_addUpdateMode == enAddUpdateMode.UpdateInfo)
                _LoadRoleAndCurrentRolePermissions(_roleID);
        }


        // >>
        private void _ApplyFilter()
        {
            string searchValue = txt_SearchValue.Text.Trim();


            if (string.IsNullOrWhiteSpace(searchValue))
            {
                _BindData(_permissions);
                chB_Permissions.SelectedIndex = 0;
            }
            else
            {
                string filterSelected = comBox_FilterItems.SelectedValue.ToString();

                if (_permissionsFilters.ContainsKey(filterSelected))
                {
                    List<clsPermission> permissionsResult = clsPermissionsFilterService.PermissionsFilters(
                        _permissions, _permissionsFilters, filterSelected, searchValue);
                    _BindData(permissionsResult);
                }
            }

            _CheckedRolePermissionsToSave();
        }

        private void txt_SearchValue_TextChanged(object sender, EventArgs e)
        {
            _ApplyFilter();
        }


        // >>
        private List<int> _checkedRolePermissionIDsToSave = new List<int>();

        private void _CheckedRolePermissionsToSave()
        {
            if (chB_Permissions.DataSource != null && _checkedRolePermissionIDsToSave != null)
            {
                for (int i = 0; i < chB_Permissions.Items.Count; i++)
                {
                    clsPermission permission = (clsPermission)chB_Permissions.Items[i];

                    if (_checkedRolePermissionIDsToSave.Contains(permission.PermissionID))
                        chB_Permissions.SetItemChecked(i, true);
                    else
                        chB_Permissions.SetItemChecked(i, false);
                }
            }
        }

        private void chB_Permissions_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            clsPermission permission = (clsPermission)chB_Permissions.Items[e.Index];

            if (e.NewValue == CheckState.Checked)
            {
                if (!_checkedRolePermissionIDsToSave.Contains(permission.PermissionID))
                    _checkedRolePermissionIDsToSave.Add(permission.PermissionID);
            }
            else if (e.NewValue == CheckState.Unchecked)
            {
                _checkedRolePermissionIDsToSave.Remove(permission.PermissionID);
            }
        }


        // >>
        public delegate void AddUpdateRoleEventHandler(object sender, bool isAdded);
        public static event AddUpdateRoleEventHandler AddUpdateRole;

        private void _HandleSuccessfulSave()
        {
            lab_RoleID.Text = Convert.ToString(_roleID);

            if (!clsCurrentUser.HasPermission(enPermissions.UpdateRoleAndPermissions))
                return;

            _addUpdateMode = enAddUpdateMode.UpdateInfo;
            _UpdateModeStatusLabel();
        }

        private clsRole _BuildRoleInfo()
        {
            return new clsRole
            {
                RoleID = _roleID,
                RoleName = txt_RoleName.Text.Trim(),
                Description = txt_Description.Text.Trim(),
            };
        }

        private Control _GetControlByPropertyName(string propertyName)
        {
            if (propertyName == nameof(clsRole.RoleName))
                return txt_RoleName;

            if (propertyName == nameof(clsRole.Description))
                return txt_Description;

            return null;
        }

        private void _SetErrorProvider(string propertyName, string message)
        {
            Control control = _GetControlByPropertyName(propertyName);

            if (control != null)
            {
                errorProvider1.SetError(control, message);
                if (control is TextBox) control.Select();
            }
            else
                MessageBox.Show(message, "Operation Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private bool _AddRoleAndPermissions(clsRole role, List<int> permissionIDs)
        {
            if (!_HasPermission(enPermissions.AddRoleAndPermissions))
                return false;

            clsOperationResult result = clsRoleBL.AddRoleAndPermissions(role, permissionIDs); 

            switch (result.Status)
            {
                case enOperationStatus.Success:
                    _roleID = result.CreatedID;
                    AddUpdateRole?.Invoke(this, true);
                    MessageBox.Show(result.Message, "Operation Successded", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;

                case enOperationStatus.Failed:
                    if (string.IsNullOrEmpty(result.PropertyName))
                        MessageBox.Show(result.Message, "Operation Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else
                        _SetErrorProvider(result.PropertyName, result.Message);
                    return false;

                case enOperationStatus.Exception:
                    MessageBox.Show(result.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;

                default:
                    return false;
            }
        }
      
        private bool _UpdateRoleAndPermissions(clsRole role, List<int> permissionIDs)
        {
            if (!_HasPermission(enPermissions.UpdateRoleAndPermissions))
                return false;

            clsOperationResult result = clsRoleBL.UpdateRoleAndPermissions(role, permissionIDs);

            switch (result.Status)
            {
                case enOperationStatus.Success:
                    AddUpdateRole?.Invoke(this, true);
                    MessageBox.Show(result.Message, "Operation Successded", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;

                case enOperationStatus.Failed:
                    if (string.IsNullOrEmpty(result.PropertyName))
                        MessageBox.Show(result.Message, "Operation Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else
                        _SetErrorProvider(result.PropertyName, result.Message);
                    return false;

                case enOperationStatus.Exception:
                    MessageBox.Show(result.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;

                default:
                    return false;
            }
        }

        private bool _Save()
        {
            switch(_addUpdateMode)
            {
                case enAddUpdateMode.AddNewInfo:
                    bool isAdded = _AddRoleAndPermissions(_BuildRoleInfo(), _checkedRolePermissionIDsToSave);
                    if (isAdded)
                        _HandleSuccessfulSave();
                    return isAdded;

                case enAddUpdateMode.UpdateInfo:
                    return _UpdateRoleAndPermissions(_BuildRoleInfo(), _checkedRolePermissionIDsToSave);

                default:
                    return false;
            }
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            _Save();
        }


        // >>
        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
