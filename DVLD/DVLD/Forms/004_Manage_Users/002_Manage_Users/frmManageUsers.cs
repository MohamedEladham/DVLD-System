using System;
using DVLD_BL;
using DVLD_Shared;
using DVLD_BL.Services;
using DVLD_Models.User;
using System.Windows.Forms;
using DVLD_Models.UI_Models;
using System.Collections.Generic;
using Main_Screen.Forms.Persons;

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
                lab_UserIDToText.Text = dataGridView_ShowUsersInfos.CurrentRow.Cells["UserID"].Value.ToString();
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
                dataGridView_ShowUsersInfos.Columns["UserID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView_ShowUsersInfos.Columns["PersonID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView_ShowUsersInfos.Columns["UserName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView_ShowUsersInfos.Columns["IsActive"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }

           
            lab_RecordsCount.Text = data == null ? "0" : data.Count.ToString();
        }

        private void _SetupComboBoxUsersStatusItems()
        {
            List<clsComboBoxFilterItem> comboBoxFiltersItems = new List<clsComboBoxFilterItem>
            {
                new clsComboBoxFilterItem { Display = "Active"       , Value = "Active" },
                new clsComboBoxFilterItem { Display = "Not Active"  , Value = "NotActive" },
            };

            comBox_UserStatus.DataSource = comboBoxFiltersItems;
            comBox_UserStatus.DisplayMember = "Display";
            comBox_UserStatus.ValueMember = "Value";
            comBox_UserStatus.SelectedValue = "Active";
        }

        private void _SetupComboBoxFilterItems()
        {
            List<clsComboBoxFilterItem> comboBoxFiltersItems = new List<clsComboBoxFilterItem>
            {
                new clsComboBoxFilterItem { Display = "None"       , Value = "None" },
                new clsComboBoxFilterItem { Display = "User ID"  , Value = "UserID" },
                new clsComboBoxFilterItem { Display = "Person ID"  , Value = "PersonID" },
                new clsComboBoxFilterItem { Display = "User Name" , Value = "UserName" },
                new clsComboBoxFilterItem { Display = "Name" , Value = "Name" }
            };

            comBox_FilterItems.DataSource = comboBoxFiltersItems;
            comBox_FilterItems.DisplayMember = "Display";
            comBox_FilterItems.ValueMember = "Value";
            comBox_FilterItems.Text = "None";
        }


        private Dictionary<string, Func<clsUserInfoGridViewDto, string, bool>> _filtersForActiveUsers;
        private void _SetupUserFilters()
        {
            _filtersForActiveUsers = clsUserFilterService.GetUserFilters();
        }


        List<clsUserInfoGridViewDto> _usersGridViewDto = null;
        private void _LoadUsersInfoToDataGridView()
        {
            try
            {
                _usersGridViewDto = clsUserBL.GetUsersForGridView();

                _BindData(_usersGridViewDto);
                _UpdateUserIDAndPersonIDLabels();

            }
            catch
            {
                MessageBox.Show(clsGeneralValidationMessages.DatabaseOperationExceptionMessage, "Has Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

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
            _LoadUsersInfoToDataGridView();
            frmCreateLoginInfo.CreatedLoginInfo += _GetCreatedLoginInfo;
            frmUpdateLoginInfo.UpdateLoginInfo += _GetIsUpdateLoginInfo;
            frmAddUpdatePersons.AddOrUpdatePersonDialogResultReceived += _GetIsAddOrUpdatePersonDialogResult;
        }

        private void frmManageUsers_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        // >>

        private void _OpenFormAddNewUser()
        {
            frmAddNewUser frm = new frmAddNewUser(); 
            frm.ShowDialog();

            if (_createdLoginIngo || _isAddOrUpdatePersonDialogResult == DialogResult.OK)
            {
                _LoadUsersInfoToDataGridView();
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

        private void toolStripMenuItem_UpdateUserInfo_Click(object sender, EventArgs e)
        {
            int personID = _GetID("PersonID");
            int UserID = _GetID("UserID");

            frmUpdateUserInfo frm = new frmUpdateUserInfo(personID, UserID);
            frm.ShowDialog();

            if (_isUpdateLoginInfo || _isAddOrUpdatePersonDialogResult == DialogResult.OK)
            {
                _LoadUsersInfoToDataGridView();
                _isUpdateLoginInfo = false;
                _isAddOrUpdatePersonDialogResult = DialogResult.No;
            }
        }

        
        // >>


        private void comBox_FilterItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comBox_FilterItems.Text == "None")
                txt_SearchValue.Visible = false;
            else
                txt_SearchValue.Visible = true;
            txt_SearchValue.Clear();
            txt_SearchValue.Select();
        }

        private void _ApplyFilterWithActiveUsers(string searchValue)
        {
            if (string.IsNullOrWhiteSpace(searchValue))
            {
                _BindData(_usersGridViewDto);
                return;
            }

            string filterSelected = comBox_FilterItems.SelectedValue.ToString();

            if (_filtersForActiveUsers.ContainsKey(filterSelected))
            {
                List<clsUserInfoGridViewDto> result = clsUserFilterService.UsersFilters(
                    _usersGridViewDto, _filtersForActiveUsers, filterSelected, searchValue);
                _BindData(result);
            }
        }

        private void _ApplyFilter()
        {
            string searchValue = txt_SearchValue.Text.Trim();

            _ApplyFilterWithActiveUsers(searchValue);
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
