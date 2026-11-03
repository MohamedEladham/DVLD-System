using System;
using DVLD_BL;
using DVLD_Models;
using DVLD_BL.Services;
using DVLD_Models.Person;
using System.Windows.Forms;
using DVLD_Models.UI_Models;
using Main_Screen.Forms.Persons;
using System.Collections.Generic;
using DVLD_Shared.Operations_Result;
using DVLD_System_Solution.Forms._003_Manage_People;
using static DVLD_Shared.Operations_Result.clsOperationResult;
using static DVLD_Shared.Global_Enums.clsEnumHelpers;
using DVLD_Models.User;
using DVLD_Shared.Validation_Messages;
using DVLD_Shared.Global_Classes;
using DVLD_Models.Roles;
using DVLD_Shared;

namespace Main_Screen.Froms.Persons_Screen
{
    public partial class frmManagePersons : Form
    {
        public frmManagePersons()
        {
            InitializeComponent();
        }

        private void _UpdateComboBoxFilterItems()
        {
            if (dataGridView_ShowPersonsInfos.DataSource == null)
            {
                comBox_FilterItems.SelectedValue = "None";
                comBox_FilterItems.Enabled = false;
            }
            else
                comBox_FilterItems.Enabled = true;
        }

        private void _UpdatePersonIDAndNationalNoLabels()
        {
            if (dataGridView_ShowPersonsInfos.CurrentRow != null)
            {
                lab_PersonIDToText.Text = dataGridView_ShowPersonsInfos.CurrentRow.Cells["PersonID"].Value.ToString();
                lab_NationalNoToText.Text = dataGridView_ShowPersonsInfos.CurrentRow.Cells["NationalNO"].Value.ToString();
            }
            else
            {
                lab_PersonIDToText.Text = "???";
                lab_NationalNoToText.Text = "???";
            }
        }

        private void txt_SearchValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            string filterSelected = comBox_FilterItems.SelectedValue.ToString();

            if (filterSelected == "PersonID")
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


        // >>  UI Configuration
        private void _BindData(List<clsActivePersonsInfoGridViewDto> activePersons)
        {
            dataGridView_ShowPersonsInfos.DataSource = activePersons;
            _UpdateComboBoxFilterItems();
            _UpdatePersonIDAndNationalNoLabels();
            lab_RecordsCount.Text = activePersons == null ? "0" : activePersons.Count.ToString();
        }

        private void _BindData(List<clsDeletedPersonInfoGridViewDto> deletedPersons)
        {
            dataGridView_ShowPersonsInfos.DataSource = deletedPersons;
            _UpdateComboBoxFilterItems();
            _UpdatePersonIDAndNationalNoLabels();
            lab_RecordsCount.Text = deletedPersons == null ? "0" : deletedPersons.Count.ToString();
        }

        // >>
        private int _GetCurrentPersonID()
        {
            if (dataGridView_ShowPersonsInfos.CurrentRow != null)
            {
                var personIDSelected = dataGridView_ShowPersonsInfos.CurrentRow.Cells["PersonID"].Value;

                if (personIDSelected != null && personIDSelected != DBNull.Value)
                {
                    if (int.TryParse(personIDSelected.ToString(), out int personID))
                        return personID;
                }
            }

            return -1;
        }

        private void _UpdateContextMenues()
        {
            if (dataGridView_ShowPersonsInfos.DataSource != null)
            {
                toolStripMenuItem_ShowActivePersonDelails.Enabled = clsCurrentUser.HasPermission(enPermissions.ViewPersons);

                btn_AddNewPerson.Enabled = clsCurrentUser.HasPermission(enPermissions.AddPerson);

                toolStripMenuItem_AddNewPerson.Enabled = clsCurrentUser.HasPermission(enPermissions.AddPerson);

                toolStripMenuItem_EditPersonInfo.Enabled = clsCurrentUser.HasPermission(enPermissions.UpdatePerson);

                toolStripMenuItem_SoftDeletePerson.Enabled = clsCurrentUser.HasPermission(enPermissions.DeletePerson);

                toolStripMenuItem_ShowDeletedPersonDetails.Enabled = clsCurrentUser.HasPermission(enPermissions.ViewPersons);

                toolStripMenuItem_RestoreDeletedPerson.Enabled = clsCurrentUser.HasPermission(enPermissions.RestorePerson);
            }
            else
            {
                toolStripMenuItem_ShowActivePersonDelails.Enabled = false;

                btn_AddNewPerson.Enabled = clsCurrentUser.HasPermission(enPermissions.AddPerson);

                toolStripMenuItem_AddNewPerson.Enabled = clsCurrentUser.HasPermission(enPermissions.AddPerson);

                toolStripMenuItem_EditPersonInfo.Enabled = false;

                toolStripMenuItem_SoftDeletePerson.Enabled = false;

                toolStripMenuItem_ShowDeletedPersonDetails.Enabled = false;

                toolStripMenuItem_RestoreDeletedPerson.Enabled = false;
            }

            toolStripMenuItem_SendEmail.Enabled = false;
            toolStripMenuItem_PhoneCall.Enabled = false;
        }

        private void dataGridView_ShowPersonsInfos_MouseDown(object sender, MouseEventArgs e)
        {
            _UpdateContextMenues();
        }

        private void dataGridView_ShowPersonsInfos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            _UpdatePersonIDAndNationalNoLabels();
        }

        // >>

      


        // >>
        private void _SetupComboBoxDisplayStatus()
        {
            List<clsComboBoxFilterItem> comBPersonsStatusFilterItems = new List<clsComboBoxFilterItem>
            {
                new clsComboBoxFilterItem { Display = "Active Persons"       , Value = "ActivePersons" },
                new clsComboBoxFilterItem { Display = "Deleted Persons"  , Value = "DeletedPersons" },
            };

            comBox_DisplayStatus.DataSource = comBPersonsStatusFilterItems;
            comBox_DisplayStatus.DisplayMember = "Display";
            comBox_DisplayStatus.ValueMember = "Value";
        }

        private void _SetupComboBoxFilterItems()
        {
            List<clsComboBoxFilterItem> comboBoxFiltersItems = new List<clsComboBoxFilterItem>
            {
                new clsComboBoxFilterItem { Display = "None"       , Value = "None" },
                new clsComboBoxFilterItem { Display = "Person ID"  , Value = "PersonID" },
                new clsComboBoxFilterItem { Display = "National No", Value = "NationalNO" },
                new clsComboBoxFilterItem { Display = "First Name" , Value = "FirstName" },
                new clsComboBoxFilterItem { Display = "Second Name", Value = "SecondName" },
                new clsComboBoxFilterItem { Display = "Third Name" , Value = "ThirdName" },
                new clsComboBoxFilterItem { Display = "Last Name"  , Value = "LastName" },
                new clsComboBoxFilterItem { Display = "Gender"     , Value = "Gender" },
                new clsComboBoxFilterItem { Display = "Email"      , Value = "Email" },
                new clsComboBoxFilterItem { Display = "Phone"      , Value = "Phone" }
            };

            comBox_FilterItems.DataSource = comboBoxFiltersItems;
            comBox_FilterItems.DisplayMember = "Display";
            comBox_FilterItems.ValueMember = "Value";
        }


        private Dictionary<string, Func<clsActivePersonsInfoGridViewDto, string, bool>> _filtersForActivePersons;
        private Dictionary<string, Func<clsDeletedPersonInfoGridViewDto, string, bool>> _filtersForDeletedPersons;
        private void _SetComboBoxes() 
        {
            _SetupComboBoxDisplayStatus();
            _SetupComboBoxFilterItems();
            _filtersForActivePersons = clsPersonFilterService.GetPersonFilters();
            _filtersForDeletedPersons = clsPersonFilterService.GetDeletedPersonFilters();
        }

        // >> 

        Dictionary<int, clsCountry> _countriesCache = null;

        private Dictionary<int, clsCountry> _GetAllCountriesToDictionary()
        {
            (clsOperationResult result, Dictionary<int, clsCountry> countriesCache) = clsCountryBL.GetAllCountriesToDictionary();

            switch (result.Status)
            {
                case enOperationStatus.Success:
                    return countriesCache;

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

        private void _LoadAllCountriesToDictionary()
        {
            _countriesCache = _GetAllCountriesToDictionary();
        }

        // >> 

        List<clsActivePersonsInfoGridViewDto> _activePersonsGridViewDto = null;

        private List<clsActivePersonsInfoGridViewDto> _GetActivePersons()
        {
            (clsOperationResult result, List<clsActivePersonsInfoGridViewDto> activePersons) = clsPersonBL.GetAllActivePersonsForGridView(_countriesCache);

            switch (result.Status)
            {
                case enOperationStatus.Success:
                    return activePersons;

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

        private void _LoadActivePersonInfoToDataGridView()
        {
            _activePersonsGridViewDto = _GetActivePersons();
            _BindData(_activePersonsGridViewDto);
        }

        // >>
       
        private DialogResult _isAddOrUpdatePersonDialogResult = DialogResult.No;
        
        private void _GetIsAddOrUpdatePersonDialogResult(object sender, DialogResult dialogResult)
        {
            _isAddOrUpdatePersonDialogResult = dialogResult;
        }

        private void _LoadData()
        {
            _SetComboBoxes();
            _LoadAllCountriesToDictionary();
            _LoadActivePersonInfoToDataGridView();
            btn_AddNewPerson.Enabled = clsCurrentUser.HasPermission(enPermissions.AddPerson);
            frmAddUpdatePersons.AddOrUpdatePersonDialogResultReceived += _GetIsAddOrUpdatePersonDialogResult;
        }

        private void frmManagePersons_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        // >>

        List<clsDeletedPersonInfoGridViewDto> _deletedPersonsGridViewDto = null;

        private List<clsDeletedPersonInfoGridViewDto> _GetDeletedPersons()
        {
            (clsOperationResult result, List<clsDeletedPersonInfoGridViewDto> deletedPersons) = clsPersonBL.GetAllDeletedPersonsForGridView(_countriesCache);

            switch (result.Status)
            {
                case enOperationStatus.Success:
                    return deletedPersons;

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

        private void _LoadDeletedPersonInfoToDataGridView()
        {
            _deletedPersonsGridViewDto = _GetDeletedPersons();
            _BindData(_deletedPersonsGridViewDto);
        }

        private void comBox_DisplayStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!(comBox_DisplayStatus.SelectedValue is string))
                return;

            comBox_FilterItems.SelectedValue = "None";

            string selectedValue = comBox_DisplayStatus.SelectedValue.ToString();

            switch (selectedValue)
            {
                case "ActivePersons":
                    _LoadActivePersonInfoToDataGridView();
                    dataGridView_ShowPersonsInfos.ContextMenuStrip = contextMenuStrip_ActivePersons;
                    btn_AddNewPerson.Visible = true;
                    break;

                case "DeletedPersons":
                    _LoadDeletedPersonInfoToDataGridView();
                    dataGridView_ShowPersonsInfos.ContextMenuStrip = contextMenuStrip_DeletedPersons;
                    btn_AddNewPerson.Visible = false;
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
        private void ApplayFilterWithActivePersons(string searchValue)
        {
            if (string.IsNullOrWhiteSpace(searchValue))
            {
                _BindData(_activePersonsGridViewDto);
                return;
            }

            string filterSelected = comBox_FilterItems.SelectedValue.ToString();

            if (_filtersForActivePersons.ContainsKey(filterSelected))
            {
                List<clsActivePersonsInfoGridViewDto> result = clsPersonFilterService.FilterPersons(
                    _activePersonsGridViewDto, _filtersForActivePersons, filterSelected, searchValue);
                _BindData(result);
            }
        }

        private void ApplayFilterWithDeletedActivePersons(string searchValue)
        {
            if (string.IsNullOrWhiteSpace(searchValue))
            {
                _BindData(_deletedPersonsGridViewDto);
                return;
            }

            string filterSelected = comBox_FilterItems.SelectedValue.ToString();

            if (_filtersForDeletedPersons.ContainsKey(filterSelected))
            {
                List<clsDeletedPersonInfoGridViewDto> result = clsPersonFilterService.FilterDeletedPersons(
                    _deletedPersonsGridViewDto, _filtersForDeletedPersons, filterSelected, searchValue);
                _BindData(result);
            }
        }

        private void _ApplyFilter()
        {
            string searchValue = txt_SearchValue.Text.Trim();

            if (comBox_DisplayStatus.SelectedValue.ToString() == "ActivePersons")
                ApplayFilterWithActivePersons(searchValue);

            if (comBox_DisplayStatus.SelectedValue.ToString() == "DeletedPersons")
                ApplayFilterWithDeletedActivePersons(searchValue);

            _UpdatePersonIDAndNationalNoLabels();
        }

        private void txt_SearchValue_TextChanged(object sender, EventArgs e)
        {
            _ApplyFilter();
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
            if (dataGridView_ShowPersonsInfos.CurrentRow == null)
            {
                MessageBox.Show(clsGeneralValidationMessages.NoDataInDataGridMessage, "No Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!_HasPermission(permissions))
                return false;

            return true;
        }


        // >>
        private void _OpenFormShowActivePersonDetails()
        {
            if (!_HasCurrentRowAndPermission(enPermissions.ViewPersons))
                return;

            int personID = _GetCurrentPersonID();
            frmShowPersonInfo frm = new frmShowPersonInfo(personID, enPersonStatus.Active);
            frm.ShowDialog();

            if (_isAddOrUpdatePersonDialogResult == DialogResult.OK)
            {
                _LoadActivePersonInfoToDataGridView();
                _isAddOrUpdatePersonDialogResult = DialogResult.No;
            }
        }

        private void toolStripMenuItem_ShowActivePersonDetails_Click(object sender, EventArgs e)
        {
            _OpenFormShowActivePersonDetails();
        }


        // >>
        private void _OpenAddUpdatePersonForm(int personID = -1, enAddUpdateMode addUpdateMode = enAddUpdateMode.AddNewInfo)
        {
            frmAddUpdatePersons frm = new frmAddUpdatePersons(personID, addUpdateMode);
            frm.ShowDialog();

            if (_isAddOrUpdatePersonDialogResult == DialogResult.OK)
            {
                _LoadActivePersonInfoToDataGridView();
                _isAddOrUpdatePersonDialogResult = DialogResult.No;
            }
        }
        
        private void btn_AddNewPerson_Click(object sender, EventArgs e)
        {
            if (!_HasPermission(enPermissions.AddPerson))
                return;

            int personID = -1;
            _OpenAddUpdatePersonForm(personID, enAddUpdateMode.AddNewInfo);
        }

        private void toolStripMenuItem_AddNewPerson_Click(object sender, EventArgs e)
        {
            if (!_HasPermission(enPermissions.AddPerson))
                return;

            int personID = -1;
            _OpenAddUpdatePersonForm(personID, enAddUpdateMode.AddNewInfo);
        }


        // >>
        private void toolStripMenuItem_EditPersonInfo_Click(object sender, EventArgs e)
        {
            if (!_HasCurrentRowAndPermission(enPermissions.UpdatePerson))
                return;

            int personID = _GetCurrentPersonID();
            _OpenAddUpdatePersonForm(personID, enAddUpdateMode.UpdateInfo);
        }
        
        
        // >>
        private bool _SoftDeletePerson(int personID)
        {
            clsOperationResult result = clsPersonBL.SoftDeletePerson(personID);

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

        private void toolStripMenuItem_SoftDeletePerson_Click(object sender, EventArgs e)
        {
            if (!_HasCurrentRowAndPermission(enPermissions.DeletePerson))
                return;

            DialogResult dialogResult = 
                MessageBox.Show("Are you sure you want to delete this persons?", "Delete Person", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult != DialogResult.Yes)
                return;

            int personID = _GetCurrentPersonID();
            bool isDeleted = _SoftDeletePerson(personID);

            if(isDeleted)
                _LoadActivePersonInfoToDataGridView();
        }

        
        // >>
        private void _OpenFormShowDeletedPersonDetails()
        {
            if (!_HasCurrentRowAndPermission(enPermissions.ViewPersons))
                return;

            int personID = _GetCurrentPersonID();

            frmShowPersonInfo frm = new frmShowPersonInfo(personID, enPersonStatus.NotActive);
            frm.ShowDialog();
        }

        private void toolStripMenuItem_ShowDeletedPersonDetails_Click(object sender, EventArgs e)
        {
            _OpenFormShowDeletedPersonDetails();
        }


        // >>
        private void dataGridView_ShowPersonsInfos_DoubleClick(object sender, EventArgs e)
        {
            if (comBox_DisplayStatus.SelectedValue.ToString() == "ActivePersons")
                _OpenFormShowActivePersonDetails();
            else
                _OpenFormShowDeletedPersonDetails();
        }


        // >>
        private bool RestoreDeletedPerson(int personID)
        {
            clsOperationResult result = clsPersonBL.RestoreDeletedPerson(personID);

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

        private void toolStripMenuItem_RestoreDeletedPerson_Click(object sender, EventArgs e)
        {
            if (!_HasCurrentRowAndPermission(enPermissions.RestorePerson))
                return;

            DialogResult dialogResult =
               MessageBox.Show("Are you sure you want to Restore this persons?", "Restore Person", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult != DialogResult.Yes)
                return;

            int personID = _GetCurrentPersonID();

            bool isRestored = RestoreDeletedPerson(personID);

            if (isRestored)
                _LoadDeletedPersonInfoToDataGridView();
        }


        // >>
        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
