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

namespace DVLD_System_Solution.Forms._004_Manage_Users
{
    public partial class frmManageUsers : Form
    {
        public frmManageUsers()
        {
            InitializeComponent();
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

        private void _BindData(List<clsUserInfoGridViewDto> data)
        {
            dataGridView_ShowUsersInfos.DataSource = data;

            if(data != null)
            {
                dataGridView_ShowUsersInfos.Columns["userID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView_ShowUsersInfos.Columns["PersonID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView_ShowUsersInfos.Columns["UserName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView_ShowUsersInfos.Columns["IsActive"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
           
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

            lab_RecordsCount.Text = data == null ? "0" : data.Count.ToString();
        }

        // >>

       
        // >>

        private void _SetupComboBoxUsersStatusItems()
        {
            List<clsComboBoxFilterItem> comboBoxFiltersItems = new List<clsComboBoxFilterItem>
            {
                new clsComboBoxFilterItem { Display = "Active Users"       , Value = "ActiveUsers" },
                new clsComboBoxFilterItem { Display = "InActive Users"  , Value = "InActiveUsers" },
                new clsComboBoxFilterItem { Display = "Deleted Users"  , Value = "DeletedUsers" }
            };

            comBox_DisplayStatus.DataSource = comboBoxFiltersItems;
            comBox_DisplayStatus.DisplayMember = "Display";
            comBox_DisplayStatus.ValueMember   = "Value";
            comBox_DisplayStatus.SelectedValue = "ActiveUsers";
        }

        private void _SetupComboBoxFilterItems()
        {
            List<clsComboBoxFilterItem> comboBoxFiltersItems = new List<clsComboBoxFilterItem>
            {
                new clsComboBoxFilterItem { Display = "None"       , Value = "None" },
                new clsComboBoxFilterItem { Display = "User ID"  , Value   = "UserID" },
                new clsComboBoxFilterItem { Display = "Person ID"  , Value = "PersonID" },
                new clsComboBoxFilterItem { Display = "User Name" , Value  = "UserName" },
                new clsComboBoxFilterItem { Display = "Name" , Value = "Name" }
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
            _filtersForActiveAndInActiveUsers = clsUserFilterService.GetActiveAndInActiveUserFilters();
            _filtersForDeletedUsers = clsUserFilterService.GetDeletedUserFilters();
        }

        // >>

        List<clsUserInfoGridViewDto> _usersInfosGridViewDto = null;
        private void _LoadActiveUsersInfoToDataGridView()
        {
            try
            {
                _usersInfosGridViewDto = clsUserBL.GetActiveUsersForGridView();

                _BindData(_usersInfosGridViewDto);
                _UpdateUserIDAndPersonIDLabels();
            }
            catch
            {
                MessageBox.Show(clsGeneralValidationMessages.DatabaseOperationExceptionMessage, "Has Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void _LoadInActiveUsersInfoToDataGridView()
        {
            try
            {
                _usersInfosGridViewDto = clsUserBL.GetInActiveUsersForGridView();

                _BindData(_usersInfosGridViewDto);
                _UpdateUserIDAndPersonIDLabels();
            }
            catch
            {
                MessageBox.Show(clsGeneralValidationMessages.DatabaseOperationExceptionMessage, "Has Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // >>

        List<clsDeleteUserInfoGridViewDto> _deletedUsersGridViewDto = null;
        private void _LoadDeletedUsersInfoToDataGridView()
        {
            try
            {
                _deletedUsersGridViewDto = clsUserBL.GetDeletedUsersForGridView();

                _BindData(_deletedUsersGridViewDto);
                _UpdateUserIDAndPersonIDLabels();
            }
            catch
            {
                MessageBox.Show(clsGeneralValidationMessages.DatabaseOperationExceptionMessage, "Has Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // >>

        private bool _createdLoginIngo = false;

        private void _GetCreatedLoginInfo(object sender, bool isCreated)
        {
            _createdLoginIngo = isCreated;
        }

        private DialogResult _isAddOrUpdatePersonDialogResult = DialogResult.No;

        private void _GetIsAddOrUpdatePersonDialogResult(object sender, DialogResult dialogResult)
        {
            _isAddOrUpdatePersonDialogResult = dialogResult;
        }

        
        private bool _isUpdateLoginInfo = false;
        private void _GetIsUpdateLoginInfo(object sender, bool status)
        {
            _isUpdateLoginInfo = status;
        }

        private void _LoadData()
        {
            _SetupComboBoxUsersStatusItems();
            _SetupComboBoxFilterItems();
            _SetupUserFilters();
            _LoadActiveUsersInfoToDataGridView();
            _UpdateFilterItems();
            frmCreateLoginInfo.CreatedLoginInfo += _GetCreatedLoginInfo;
            frmUpdateLoginInfo.UpdateLoginInfo += _GetIsUpdateLoginInfo;
            frmAddUpdatePersons.AddOrUpdatePersonDialogResultReceived += _GetIsAddOrUpdatePersonDialogResult;
        }

        private void frmManageUsers_Load(object sender, EventArgs e)
        {
            _LoadData();

            toolStripMenuItem_ShowUserDetails.Enabled = clsCurrentUser.HasPermission(enPermissions.ViewUsers);
            toolStripMenuItem_ShowInActiveUserDetails.Enabled = clsCurrentUser.HasPermission(enPermissions.ViewUsers);
            toolStripMenuItem_ShowDeletedUserDetails.Enabled = clsCurrentUser.HasPermission(enPermissions.ViewUsers);

            btn_AddNewUser.Enabled = clsCurrentUser.HasPermission(enPermissions.AddUser);
            toolStripMenuItem_AddNewUser.Enabled = clsCurrentUser.HasPermission(enPermissions.AddUser);

            toolStripMenuItem_UpdateUserInfo.Enabled = clsCurrentUser.HasPermission(enPermissions.UpdateUserLoginInfo);
            toolStripMenuItem_UpdateLoginInfo.Enabled = clsCurrentUser.HasPermission(enPermissions.UpdateUserLoginInfo);
            toolStripMenuItem_ActiveUser.Enabled = clsCurrentUser.HasPermission(enPermissions.UpdateUserLoginInfo);

            toolStripMenuItem_SoftDeleteActiveUser.Enabled = clsCurrentUser.HasPermission(enPermissions.DeleteUser);
            toolStripMenuItem_SoftDeleteInActiveUser.Enabled = clsCurrentUser.HasPermission(enPermissions.DeleteUser);

            toolStripMenuItem_RestoreDeletedUser.Enabled = clsCurrentUser.HasPermission(enPermissions.RestoreUser);
        }

        // >>

        private bool _HasCurrentRowAndPermission()
        {
            if (dataGridView_ShowUsersInfos.CurrentRow == null)
            {
                MessageBox.Show(clsGeneralValidationMessages.NoDataInDataGridMessage, "No Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!clsCurrentUser.HasPermission(enPermissions.ViewUsers))
            {
                MessageBox.Show(clsUserValidationMessages.PermissionDeniedMessage, "Permission Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }


        private void _OpenFormShowUserInfo(enPersonStatus personStatus)
        {
            if (!_HasCurrentRowAndPermission())
                return;

            int personID = _GetID("PersonID");
            int userID = _GetID("userID");

            frmShowUserInfo frm = new frmShowUserInfo(personID, userID, personStatus);
            frm.ShowDialog();

            if (_isAddOrUpdatePersonDialogResult == DialogResult.OK)
            {
                _LoadActiveUsersInfoToDataGridView();
                _isAddOrUpdatePersonDialogResult = DialogResult.No;
            }
        }

        private void toolStripMenuItem_ShowUserDetails_Click(object sender, EventArgs e)
        {
            _OpenFormShowUserInfo(enPersonStatus.Active);
        }

        private void dataGridView_ShowUsersInfos_DoubleClick(object sender, EventArgs e)
        {
            if (!_HasCurrentRowAndPermission())
                return;

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

        private void _OpenFormAddNewUser()
        {
            frmAddNewUser frm = new frmAddNewUser(); 
            frm.ShowDialog();

            if (_createdLoginIngo || _isAddOrUpdatePersonDialogResult == DialogResult.OK)
            {
                if(comBox_DisplayStatus.SelectedValue.ToString() == "ActiveUsers")
                {
                    _LoadActiveUsersInfoToDataGridView();
                    _UpdateComboBoxFilterItems();
                }

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

        private int _GetID(string message)
        {
            var id = dataGridView_ShowUsersInfos.CurrentRow.Cells[message].Value;
            return id != null ? Convert.ToInt32(id) : -1;
        }

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

        private void toolStripMenuItem_UpdateUserInfo_Click(object sender, EventArgs e)
        {
            if (!_HasCurrentRowAndPermission())
                return;

            int personID = _GetID("PersonID");
            int userID = _GetID("userID");

            frmUpdateUserInfo frm = new frmUpdateUserInfo(personID, userID);
            frm.ShowDialog();

            if (_isUpdateLoginInfo || _isAddOrUpdatePersonDialogResult == DialogResult.OK)
            {
                _LoadActiveUsersInfoToDataGridView();
                _UpdateComboBoxFilterItems();
                _isUpdateLoginInfo = false;
                _isAddOrUpdatePersonDialogResult = DialogResult.No;
            }
        }

        private bool _SoftDeleteUser()
        {
            DialogResult dialogResult =
               MessageBox.Show("Are you sure you want to delete this user?", "Delete User", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult != DialogResult.Yes)
                return false;

            if (!_HasCurrentRowAndPermission())
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
            bool isDeleted = _SoftDeleteUser();

            if(isDeleted)
            {
                _LoadActiveUsersInfoToDataGridView();
                _UpdateComboBoxFilterItems();
            }
        }

        private void toolStripMenuItem_SoftDeleteInActiveUser_Click(object sender, EventArgs e)
        {
            bool isDeleted = _SoftDeleteUser(); 

            if (isDeleted)
            {
                _LoadInActiveUsersInfoToDataGridView();
                _UpdateComboBoxFilterItems();
            }
        }

        private void toolStripMenuItem_UpdateLoginInfo_Click(object sender, EventArgs e)
        {
            if (!_HasCurrentRowAndPermission())
                return;

            int userID = _GetID("userID");

            frmUpdateLoginInfo frm = new frmUpdateLoginInfo(userID);
            frm.ShowDialog();

            if (_isUpdateLoginInfo)
            {
                _LoadActiveUsersInfoToDataGridView();
                _UpdateComboBoxFilterItems();
                _isUpdateLoginInfo = false;
            }
        }

        // >>

        private void toolStripMenuItem_ShowInActiveUserDetails_Click(object sender, EventArgs e)
        {
            _OpenFormShowUserInfo(enPersonStatus.NotActive);
        }

        private bool _ActivateUser(int userID)
        {
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
            DialogResult dialogResult =
               MessageBox.Show("Are you sure you want to active this user?", "Active User", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult != DialogResult.Yes)
                return;

            int userID = _GetID("userID");

            bool isActivated = _ActivateUser(userID);

            if (isActivated)
                _LoadInActiveUsersInfoToDataGridView();

            _UpdateComboBoxFilterItems();
        }
        

        // >> 

        private bool _RestoreUser(int userID)
        {
            clsOperationResult result = clsUserBL.RestoreUser(userID);

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

        private void toolStripMenuItem_RestoreDeletedUser_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult =
               MessageBox.Show("Are you sure you want to restore this user?", "Restore User", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult != DialogResult.Yes)
                return;

            int userID = _GetID("userID");
            
            bool isRestored = _RestoreUser(userID);

            if (isRestored)
                _LoadDeletedUsersInfoToDataGridView();

            _UpdateComboBoxFilterItems();
        }

        private void toolStripMenuItem_ShowDeletedUserDetails_Click(object sender, EventArgs e)
        {
            _OpenFormShowUserInfo(enPersonStatus.NotActive);
        }

        // >> 

        private void _UpdateFilterItems()
        {
            if (dataGridView_ShowUsersInfos.DataSource == null)
                comBox_FilterItems.Enabled = false;
            else
                comBox_FilterItems.Enabled = true;
        }

        private void _UpdateContextMenues()
        {
            if (dataGridView_ShowUsersInfos.DataSource == null)
            {
                contextMenuStrip_ActiveUsers.Enabled = false;
                contextMenuStrip_InActiveUsers.Enabled = false;
                contextMenuStrip_DeletedUsers.Enabled = false;
            }
            else
            {
                contextMenuStrip_ActiveUsers.Enabled = true;
                contextMenuStrip_InActiveUsers.Enabled = true;
                contextMenuStrip_DeletedUsers.Enabled = true;
            }
        }
       
        private void dataGridView_ShowUsersInfos_MouseDown(object sender, MouseEventArgs e)
        {
            _UpdateContextMenues();
        }

        private void comBox_DisplayStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            comBox_FilterItems.SelectedValue = "None";

            string selectedValue = comBox_DisplayStatus.SelectedValue.ToString();

            switch(selectedValue)
            {
                case "ActiveUsers":
                    _LoadActiveUsersInfoToDataGridView();
                    dataGridView_ShowUsersInfos.ContextMenuStrip = contextMenuStrip_ActiveUsers;
                    break;

                case "InActiveUsers":
                    _LoadInActiveUsersInfoToDataGridView();
                    dataGridView_ShowUsersInfos.ContextMenuStrip = contextMenuStrip_InActiveUsers;
                    break;

                case "DeletedUsers":
                    _LoadDeletedUsersInfoToDataGridView();
                    dataGridView_ShowUsersInfos.ContextMenuStrip = contextMenuStrip_DeletedUsers;
                    break;
            }

            _UpdateFilterItems();
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

        private void _ApplyFilterWithActiveAndInActiveUsers(string searchValue)
        {
            if (string.IsNullOrWhiteSpace(searchValue))
            {
                _BindData(_usersInfosGridViewDto);
                return;
            }

            string filterSelected = comBox_FilterItems.SelectedValue.ToString();

            if (_filtersForActiveAndInActiveUsers.ContainsKey(filterSelected))
            {
                List<clsUserInfoGridViewDto> result = clsUserFilterService.ActiveAndInActiveUsersFilters(
                    _usersInfosGridViewDto, _filtersForActiveAndInActiveUsers, filterSelected, searchValue);
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
                    _ApplyFilterWithActiveAndInActiveUsers(searchValue);
                    break;

                case "InActiveUsers":
                    _ApplyFilterWithActiveAndInActiveUsers(searchValue);
                    break;

                case "DeletedUsers":
                    _ApplyFilterWithDeletedUsers(searchValue);
                    dataGridView_ShowUsersInfos.ContextMenuStrip = contextMenuStrip_DeletedUsers;
                    break;
            }
        }

        private void txt_SearchValue_TextChanged(object sender, EventArgs e)
        {
            _ApplyFilter();
        }

        private void dataGridView_ShowUsersInfos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            _UpdateUserIDAndPersonIDLabels();
        }
        
        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
