using System;
using DVLD_BL;
using DVLD_Shared;
using DVLD_BL.Services;
using DVLD_Models.User;
using System.Windows.Forms;
using DVLD_Models.UI_Models;
using Main_Screen.Forms.Persons;
using System.Collections.Generic;
using static DVLD_Shared.Global_Enums.clsEnumHelpers;
using DVLD_System_Solution.Forms._004_Manage_Users._005_Show_User_Info;
using DVLD_Shared.Operations_Result;
using static DVLD_Shared.Operations_Result.clsOperationResult;
using DVLD_Shared.Global_Classes;
using DVLD_Shared.Validation_Messages;
using DVLD_Models;

namespace DVLD_System_Solution.Forms._004_Manage_Users
{
    public partial class frmManageUsers : Form
    {
        public frmManageUsers()
        {
            InitializeComponent();
        }

        private int _GetID(string message)
        {
            var id = dataGridView_ShowUsersInfos.CurrentRow.Cells[message].Value;
            return id != null ? Convert.ToInt32(id) : -1;
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

        private bool _HasCurrentRowAndPermission(enPermissions permissions)
        {
            if (dataGridView_ShowUsersInfos.CurrentRow == null)
            {
                MessageBox.Show(clsGeneralValidationMessages.NoDataInDataGridMessage, "No Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!_HasPermission(permissions))
                return false;

            return true;
        }


        // >>
        private void _UpdateComboBoxFilterItems()
        {
            if (dataGridView_ShowUsersInfos.DataSource == null)
            {
                comBox_FilterItems.SelectedValue = "None";
                comBox_FilterItems.Enabled = false;
            }
            else
                comBox_FilterItems.Enabled = true;
        }

        private void _UpdateUserIDAndPersonIDLabels()
        {
            if (dataGridView_ShowUsersInfos.CurrentRow != null)
            {
                lab_UserIDToText.Text = dataGridView_ShowUsersInfos.CurrentRow.Cells["userID"].Value.ToString();
                lab_PersonIDToText.Text = dataGridView_ShowUsersInfos.CurrentRow.Cells["PersonID"].Value.ToString();
            }
            else
            {
                lab_UserIDToText.Text   = "???";
                lab_PersonIDToText.Text = "???";
            }
        }

        private void dataGridView_ShowUsersInfos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            _UpdateUserIDAndPersonIDLabels();
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

        private void txt_SearchValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            string filterSelected = comBox_FilterItems.SelectedValue.ToString();

            if (filterSelected == "UserID" || filterSelected == "PersonID")
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
            if (dataGridView_ShowUsersInfos.DataSource != null)
            {
                toolStripMenuItem_ShowActiveUserDetails.Enabled = clsCurrentUser.HasPermission(enPermissions.ViewUsers);
                toolStripMenuItem_ShowInActiveUserDetails.Enabled = clsCurrentUser.HasPermission(enPermissions.ViewUsers);
                toolStripMenuItem_ShowDeletedUserDetails.Enabled = clsCurrentUser.HasPermission(enPermissions.ViewUsers);

                btn_AddNewUser.Enabled = clsCurrentUser.HasPermission(enPermissions.AddUserAndRole);
                toolStripMenuItem_AddNewUser.Enabled = clsCurrentUser.HasPermission(enPermissions.AddUserAndRole);

                toolStripMenuItem_UpdateUserInfo.Enabled = clsCurrentUser.HasPermission(enPermissions.UpdateUserLoginInfo);
                toolStripMenuItem_UpdateLoginInfo.Enabled = clsCurrentUser.HasPermission(enPermissions.UpdateUserLoginInfo);
                toolStripMenuItem_ActiveUser.Enabled = clsCurrentUser.HasPermission(enPermissions.UpdateUserLoginInfo);

                toolStripMenuItem_SoftDeleteActiveUser.Enabled = clsCurrentUser.HasPermission(enPermissions.DeleteUser);
                toolStripMenuItem_SoftDeleteInActiveUser.Enabled = clsCurrentUser.HasPermission(enPermissions.DeleteUser);
            }
            else
            {
                toolStripMenuItem_ShowActiveUserDetails.Enabled = false;
                toolStripMenuItem_ShowInActiveUserDetails.Enabled = false;
                toolStripMenuItem_ShowDeletedUserDetails.Enabled = false;

                btn_AddNewUser.Enabled = clsCurrentUser.HasPermission(enPermissions.AddUserAndRole);
                toolStripMenuItem_AddNewUser.Enabled = clsCurrentUser.HasPermission(enPermissions.AddUserAndRole);

                toolStripMenuItem_UpdateUserInfo.Enabled = false;
                toolStripMenuItem_UpdateLoginInfo.Enabled = false;
                toolStripMenuItem_ActiveUser.Enabled = false;

                toolStripMenuItem_SoftDeleteActiveUser.Enabled = false;
                toolStripMenuItem_SoftDeleteInActiveUser.Enabled = false;
            }
        }

        private void dataGridView_ShowUsersInfos_MouseDown(object sender, MouseEventArgs e)
        {
            _UpdateContextMenues();
        }


        // >> 
        private void _BindData(List<clsUserInfoGridViewDto> data)
        {
            dataGridView_ShowUsersInfos.DataSource = data;

            if(dataGridView_ShowUsersInfos.DataSource != null)
            {
                dataGridView_ShowUsersInfos.Columns["userID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView_ShowUsersInfos.Columns["PersonID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView_ShowUsersInfos.Columns["UserName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView_ShowUsersInfos.Columns["IsActive"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
           
            _UpdateComboBoxFilterItems();
            _UpdateUserIDAndPersonIDLabels();
            lab_RecordsCount.Text = data == null ? "0" : data.Count.ToString();
        }

        private void _BindData(List<clsDeleteUserInfoGridViewDto> data)
        {
            dataGridView_ShowUsersInfos.DataSource = data;

            if (data != null)
            {
                dataGridView_ShowUsersInfos.Columns["userID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView_ShowUsersInfos.Columns["PersonID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView_ShowUsersInfos.Columns["UserName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView_ShowUsersInfos.Columns["IsActive"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView_ShowUsersInfos.Columns["IsDeleted"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView_ShowUsersInfos.Columns["DeletedAt"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }

            _UpdateComboBoxFilterItems();
            _UpdateUserIDAndPersonIDLabels();
            lab_RecordsCount.Text = data == null ? "0" : data.Count.ToString();
        }


        // >>
        private void _SetupComboBoxUsersStatusItems()
        {
            List<clsComboBoxFilterItem> comboBoxFiltersItems = new List<clsComboBoxFilterItem>
            {
                new clsComboBoxFilterItem { Display = "Active Users"   , Value = "ActiveUsers" },
                new clsComboBoxFilterItem { Display = "InActive Users" , Value = "InActiveUsers" },
                new clsComboBoxFilterItem { Display = "Deleted Users"  , Value = "DeletedUsers" }
            };

            comBox_DisplayStatus.DataSource = comboBoxFiltersItems;
            comBox_DisplayStatus.DisplayMember = "Display";
            comBox_DisplayStatus.ValueMember   = "Value";
            comBox_DisplayStatus.Text = "Active Users";
        }

        private void _SetupComboBoxFilterItems()
        {
            List<clsComboBoxFilterItem> comboBoxFiltersItems = new List<clsComboBoxFilterItem>
            {
                new clsComboBoxFilterItem { Display = "None"      , Value = "None" },
                new clsComboBoxFilterItem { Display = "User ID"   , Value = "UserID" },
                new clsComboBoxFilterItem { Display = "Person ID" , Value = "PersonID" },
                new clsComboBoxFilterItem { Display = "User Name" , Value = "UserName" },
                new clsComboBoxFilterItem { Display = "Name"      , Value = "Name" }
            };

            comBox_FilterItems.DataSource = comboBoxFiltersItems;
            comBox_FilterItems.DisplayMember = "Display";
            comBox_FilterItems.ValueMember = "Value";
            comBox_FilterItems.Text = "None";
        }

        private Dictionary<string, Func<clsUserInfoGridViewDto, string, bool>> _filtersForActiveAndInActiveUsers;
        private Dictionary<string, Func<clsDeleteUserInfoGridViewDto, string, bool>> _filtersForDeletedUsers;
        private void _SetupUserFilters()
        {
            _SetupComboBoxUsersStatusItems();
            _SetupComboBoxFilterItems();
            _filtersForActiveAndInActiveUsers = clsUserFilterService.GetActiveAndInActiveUserFilters();
            _filtersForDeletedUsers = clsUserFilterService.GetDeletedUserFilters();
        }

        
        
        // >> 
        private void _ApplyFilterWithActiveAndInActiveUsers(string searchValue)
        {
            if (string.IsNullOrWhiteSpace(searchValue))
            {
                _BindData(_activeAndInactiveUsersGridViewDto);
                return;
            }

            string filterSelected = comBox_FilterItems.SelectedValue.ToString();

            if (_filtersForActiveAndInActiveUsers.ContainsKey(filterSelected))
            {
                List<clsUserInfoGridViewDto> result = clsUserFilterService.ActiveAndInActiveUsersFilters(
                    _activeAndInactiveUsersGridViewDto, _filtersForActiveAndInActiveUsers, filterSelected, searchValue);
                _BindData(result);
            }
        }

        private void _ApplyFilterWithDeletedUsers(string searchValue)
        {
            if (string.IsNullOrWhiteSpace(searchValue))
            {
                _BindData(_deletedUsersGridViewDto);
                return;
            }

            string filterSelected = comBox_FilterItems.SelectedValue.ToString();

            if (_filtersForDeletedUsers.ContainsKey(filterSelected))
            {
                List<clsDeleteUserInfoGridViewDto> result = clsUserFilterService.DeletedUsersFilters(
                    _deletedUsersGridViewDto, _filtersForDeletedUsers, filterSelected, searchValue);
                _BindData(result);
            }
        }

        private void _ApplyFilter()
        {
            string searchValue = txt_SearchValue.Text.Trim();

            string selectedValue = comBox_DisplayStatus.SelectedValue.ToString();

            switch (selectedValue)
            {
                case "ActiveUsers":
                case "InActiveUsers":
                    _ApplyFilterWithActiveAndInActiveUsers(searchValue);
                    break;

                case "DeletedUsers":
                    _ApplyFilterWithDeletedUsers(searchValue);
                    break;
            }
        }

        private void txt_SearchValue_TextChanged(object sender, EventArgs e)
        {
            _ApplyFilter();
        }


        // >>
        List<clsUserInfoGridViewDto> _activeAndInactiveUsersGridViewDto = null;

        private List<clsUserInfoGridViewDto> _GetActiveUsers()
        {
            (clsOperationResult result, List<clsUserInfoGridViewDto> activeUsers) = clsUserBL.GetActiveUsersForGridView();

            switch (result.Status)
            {
                case enOperationStatus.Success:
                    return activeUsers;

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

        private void _LoadActiveUsersToDataGridView()
        {
            _activeAndInactiveUsersGridViewDto = _GetActiveUsers();
            _BindData(_activeAndInactiveUsersGridViewDto);
        }

        
        // >>
        private bool _createdLoginIngo = false;

        private void _GetCreatedLoginInfo(object sender, bool isCreated)
        {
            _createdLoginIngo = isCreated;
        }

        private bool _isUpdateLoginInfo = false;
        private void _GetIsUpdateLoginInfo(object sender, bool status)
        {
            _isUpdateLoginInfo = status;
        }
        
        private DialogResult _isAddOrUpdatePersonDialogResult = DialogResult.No;
        private void _GetIsAddOrUpdatePersonDialogResult(object sender, DialogResult dialogResult)
        {
            _isAddOrUpdatePersonDialogResult = dialogResult;
        }

        
        // >>
        private void _LoadData()
        {
            _SetupUserFilters();
            _LoadActiveUsersToDataGridView();
                
            btn_AddNewUser.Enabled = clsCurrentUser.HasPermission(enPermissions.AddUserAndRole);

            frmCreateLoginInfo.CreatedLoginInfo += _GetCreatedLoginInfo;
            frmUpdateLoginInfo.UpdateLoginInfo += _GetIsUpdateLoginInfo;
            frmAddUpdatePersons.AddOrUpdatePersonDialogResultReceived += _GetIsAddOrUpdatePersonDialogResult;
        }

        private void frmManageUsers_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        
        // >>
        private List<clsUserInfoGridViewDto> _GetInActiveUsers()
        {
            (clsOperationResult result, List<clsUserInfoGridViewDto> inActiveUsers) = clsUserBL.GetInActiveUsersForGridView();

            switch (result.Status)
            {
                case enOperationStatus.Success:
                    return inActiveUsers;

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

        private void _LoadInActiveUsersInfoToDataGridView()
        {
            _activeAndInactiveUsersGridViewDto = _GetInActiveUsers();
            _BindData(_activeAndInactiveUsersGridViewDto);
        }


        // >>
        List<clsDeleteUserInfoGridViewDto> _deletedUsersGridViewDto = null;

        private List<clsDeleteUserInfoGridViewDto> _GetDeletedUsers()
        {
            (clsOperationResult result, List<clsDeleteUserInfoGridViewDto> deletedUsers) = clsUserBL.GetDeletedUsersForGridView();

            switch (result.Status)
            {
                case enOperationStatus.Success:
                    return deletedUsers;

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

        private void _LoadDeletedUsersInfoToDataGridView()
        {
            _deletedUsersGridViewDto = _GetDeletedUsers();
            _BindData(_deletedUsersGridViewDto);
        }


        // >>
        private void comBox_DisplayStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            comBox_FilterItems.Text = "None";

            string selectedValue = comBox_DisplayStatus.SelectedValue.ToString();

            switch (selectedValue)
            {
                case "ActiveUsers":
                    _LoadActiveUsersToDataGridView();
                    dataGridView_ShowUsersInfos.ContextMenuStrip = contextMenuStrip_ActiveUsers;
                    btn_AddNewUser.Visible = true;
                    break;

                case "InActiveUsers":
                    _LoadInActiveUsersInfoToDataGridView();
                    dataGridView_ShowUsersInfos.ContextMenuStrip = contextMenuStrip_InActiveUsers;
                    btn_AddNewUser.Visible = false;
                    break;

                case "DeletedUsers":
                    _LoadDeletedUsersInfoToDataGridView();
                    dataGridView_ShowUsersInfos.ContextMenuStrip = contextMenuStrip_DeletedUsers;
                    btn_AddNewUser.Visible = false;
                    break;
            }
        }

        
        // >>
        private void _OpenFormShowUserInfo(enPersonStatus personStatus)
        {
            if (!_HasCurrentRowAndPermission(enPermissions.ViewUsers))
                return;

            int personID = _GetID("PersonID");
            int userID = _GetID("userID");

            frmShowUserInfo frm = new frmShowUserInfo(personID, userID, personStatus);
            frm.ShowDialog();

            if (_isAddOrUpdatePersonDialogResult == DialogResult.OK)
            {
                _LoadActiveUsersToDataGridView();
                _isAddOrUpdatePersonDialogResult = DialogResult.No;
            }
        }

        private void toolStripMenuItem_ShowActiveUserDetails_Click(object sender, EventArgs e)
        {
            _OpenFormShowUserInfo(enPersonStatus.Active);
        }

        private void dataGridView_ShowUsersInfos_DoubleClick(object sender, EventArgs e)
        {
            string selectedValue = comBox_DisplayStatus.SelectedValue.ToString();

            switch (selectedValue)
            {
                case "ActiveUsers":
                    _OpenFormShowUserInfo(enPersonStatus.Active);
                    break;

                case "InActiveUsers":
                case "DeletedUsers":
                    _OpenFormShowUserInfo(enPersonStatus.NotActive);
                    break;
            }
        }


        // >>
        private void _OpenFormAddNewUser()
        {
            if (!_HasPermission(enPermissions.AddUserAndRole))
                return;

            frmAddNewUser frm = new frmAddNewUser(); 
            frm.ShowDialog();

            if (_createdLoginIngo || _isAddOrUpdatePersonDialogResult == DialogResult.OK)
            {
                if(comBox_DisplayStatus.SelectedValue.ToString() == "ActiveUsers")
                    _LoadActiveUsersToDataGridView();

                _createdLoginIngo = false;
                _isAddOrUpdatePersonDialogResult = DialogResult.No;
            }
        }

        private void btn_OpenfrmAddUpdatePersonInfo_Click(object sender, EventArgs e)
        {
            _OpenFormAddNewUser();
        }

        private void toolStripMenuItem_AddNewUser_Click(object sender, EventArgs e)
        {
            _OpenFormAddNewUser();
        }


        // >>
        private void _OpenFormUpdateUserInfo()
        {
            if (!_HasCurrentRowAndPermission(enPermissions.UpdateUserLoginInfo))
                return;

            int personID = _GetID("PersonID");
            int userID = _GetID("userID");

            frmUpdateUserInfo frm = new frmUpdateUserInfo(personID, userID);
            frm.ShowDialog();

            if (_isUpdateLoginInfo || _isAddOrUpdatePersonDialogResult == DialogResult.OK)
            {
                _LoadActiveUsersToDataGridView();
                _isUpdateLoginInfo = false;
                _isAddOrUpdatePersonDialogResult = DialogResult.No;
            }
        }

        private void toolStripMenuItem_UpdateUserInfo_Click(object sender, EventArgs e)
        {
            _OpenFormUpdateUserInfo();
        }

        

        // >>
        private string _GetColumnName(string columnName)
        {
            if (dataGridView_ShowUsersInfos.CurrentRow.Cells[columnName].Value != null &&
                dataGridView_ShowUsersInfos.CurrentRow.Cells[columnName].Value != DBNull.Value)
                return dataGridView_ShowUsersInfos.CurrentRow.Cells[columnName].Value.ToString();
            else
                return "???";
        }

        private bool _SoftDeleteUser()
        {
            if (!_HasCurrentRowAndPermission(enPermissions.DeleteUser))
                return false;


            DialogResult dialogResult =
               MessageBox.Show($"Are you sure you want to delete this user? \n\n" +
               $">> UserID   : {_GetColumnName("userID")}   \n" +
               $">> PersonID : {_GetColumnName("PersonID")} \n" +
               $">> User Name: {_GetColumnName("UserName")} \n" +
               $">> Full Name: {_GetColumnName("FullName")} \n",
               "Delete User", 
               MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (dialogResult != DialogResult.Yes)
                return false;

            int userID = _GetID("userID");

            clsOperationResult result = clsUserBL.SoftDeleteUser(userID);

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

        private void toolStripMenuItem_SoftDeleteActiveUser_Click(object sender, EventArgs e)
        {
            if (_SoftDeleteUser()) _LoadActiveUsersToDataGridView();
        }


        // >>
        private void toolStripMenuItem_UpdateLoginInfo_Click(object sender, EventArgs e)
        {
            if (!_HasCurrentRowAndPermission(enPermissions.UpdateUserLoginInfo))
                return;

            int userID = _GetID("userID");

            frmUpdateLoginInfo frm = new frmUpdateLoginInfo(userID);
            frm.ShowDialog();

            if (_isUpdateLoginInfo)
            {
                _LoadActiveUsersToDataGridView();
                _isUpdateLoginInfo = false;
            }
        }

        
        // >>
        private void toolStripMenuItem_ShowInActiveUserDetails_Click(object sender, EventArgs e)
        {
            _OpenFormShowUserInfo(enPersonStatus.NotActive);
        }


        // >>
        private bool _ActivateUser()
        {
            if (!_HasCurrentRowAndPermission(enPermissions.UpdateUserLoginInfo))
                return false;


            DialogResult dialogResult =
              MessageBox.Show("Are you sure you want to active this user?", "Active User", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult != DialogResult.Yes)
                return false;

            int userID = _GetID("userID");

            clsOperationResult result = clsUserBL.ActivateUser(userID);

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

        private void toolStripMenuItem_ActiveUser_Click(object sender, EventArgs e)
        {
            if (_ActivateUser())
                _LoadInActiveUsersInfoToDataGridView();
        }

        
        // >>
        private void toolStripMenuItem_SoftDeleteInActiveUser_Click(object sender, EventArgs e)
        {
            if (_SoftDeleteUser()) _LoadInActiveUsersInfoToDataGridView();
        }


        // >> 
        private void toolStripMenuItem_ShowDeletedUserDetails_Click(object sender, EventArgs e)
        {
            _OpenFormShowUserInfo(enPersonStatus.NotActive);
        }

       
        // >>
        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
