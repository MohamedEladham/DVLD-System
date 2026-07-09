using System;
using DVLD_BL;
using DVLD_Models;
using DVLD_Shared;
using DVLD_BL.Services;
using System.Windows.Forms;
using DVLD_Models.UI_Models;
using Main_Screen.Forms.Persons;
using System.Collections.Generic;
using DVLD_System_Solution.Forms._003_Manage_People;
using DVLD_Shared.Operations_Result;
using static DVLD_Shared.Operations_Result.clsOperationResult;

namespace Main_Screen.Froms.Persons_Screen
{
    public partial class frmManagePersons : Form
    {
        public frmManagePersons()
        {
            InitializeComponent();
        }

        // >>  UI Configuration
        private void _BindData(List<clsPersonInfoGridViewDto> data)
        {
            if (data != null)
            {
                dataGridView_ShowPersonsInfos.DataSource = data;
                dataGridView_ShowPersonsInfos.Columns["PersonID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView_ShowPersonsInfos.Columns["NationalNO"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView_ShowPersonsInfos.Columns["FirstName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView_ShowPersonsInfos.Columns["SecondName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView_ShowPersonsInfos.Columns["ThirdName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView_ShowPersonsInfos.Columns["LastName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView_ShowPersonsInfos.Columns["Gender"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView_ShowPersonsInfos.Columns["Age"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView_ShowPersonsInfos.Columns["CountryName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                //dataGridView_ShowPersonsInfos.Columns["Email"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView_ShowPersonsInfos.Columns["Phone"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView_ShowPersonsInfos.Columns["Address"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView_ShowPersonsInfos.Columns["IsDeleted"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                lab_RecordsCount.Text = data.Count.ToString();
            }
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
                new clsComboBoxFilterItem { Display = "Phone"      , Value = "Phone" },
            };

            comBox_FilterItems.DataSource = comboBoxFiltersItems;
            comBox_FilterItems.DisplayMember = "Display";
            comBox_FilterItems.ValueMember = "Value";
            comBox_FilterItems.Text = "None";
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

        private void _UpdatePersonIDAndNationalNoLabels()
        {
            lab_PersonIDToText.Text = dataGridView_ShowPersonsInfos.CurrentRow.Cells["PersonID"].Value.ToString();
            lab_NationalNoToText.Text = dataGridView_ShowPersonsInfos.CurrentRow.Cells["NationalNO"].Value.ToString();
        }

        private void dataGridView_ShowPersonsInfos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            _UpdatePersonIDAndNationalNoLabels();
        }

        private Dictionary<string, Func<clsPersonInfoGridViewDto, string, bool>> _filters;
        private void _SetupPersonFilter()
        {
            _filters = clsPersonFilterService.GetPersonFilters();
        }
     
        // >> 

        List<clsPersonInfoGridViewDto> _personsGridViewDto = null;
        private void _LoadPersonInfoToDataGridView()
        {
            try
            {
                List<clsPerson> personInfos = clsPersonBL.GetAllPersonsInfo();

                if(personInfos != null && personInfos.Count > 0)
                {
                    Dictionary<int, clsCountry> countriesCache = clsCountryBL.LoadCountriesToDictionary();

                    _personsGridViewDto = clsPersonBL.GetPersonsForGridView(personInfos, countriesCache);

                    _BindData(_personsGridViewDto);
                    _UpdatePersonIDAndNationalNoLabels();
                }
            }
            catch
            {
                MessageBox.Show(clsGeneralValidationMessages.DatabaseOperationExceptionMessage, "Has Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private DialogResult _isAddOrUpdatePersonDialogResult = DialogResult.No;
        
        private void _GetIsAddOrUpdatePersonDialogResult(object sender, DialogResult dialogResult)
        {
            _isAddOrUpdatePersonDialogResult = dialogResult;
        }

        private void _LoadData()
        {
            _SetupComboBoxFilterItems();
            _SetupPersonFilter();
            _LoadPersonInfoToDataGridView();
            frmAddUpdatePersons.AddOrUpdatePersonDialogResultReceived += _GetIsAddOrUpdatePersonDialogResult;
        }

        private void frmManagePersons_Load(object sender, EventArgs e)
        {
            _LoadData();
        }
        
        private void _ApplyFilter()
        {
            string searchValue = txt_SearchValue.Text.Trim();

            if (string.IsNullOrWhiteSpace(searchValue))
            {
                _BindData(_personsGridViewDto);
                return;
            }

            string filterSelected = comBox_FilterItems.SelectedValue.ToString();

            if (_filters.ContainsKey(filterSelected))
            {
                List<clsPersonInfoGridViewDto> result = clsPersonFilterService.FilterPersons(_personsGridViewDto, _filters, filterSelected, searchValue);
                _BindData(result);
            }
        }

        private void txt_SearchValue_TextChanged(object sender, EventArgs e)
        {
            _ApplyFilter();
        }

        private void comBox_FilterItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comBox_FilterItems.Text == "None") txt_SearchValue.Visible = false;
            else txt_SearchValue.Visible = true;
            txt_SearchValue.Clear();
            txt_SearchValue.Select();
        }

        // >>>>
        private void _OpenAddUpdatePersonForm(int modeValue, int personID = -1)
        {
            frmAddUpdatePersons frm = new frmAddUpdatePersons(modeValue, personID);
            frm.ShowDialog();

            if (_isAddOrUpdatePersonDialogResult == DialogResult.OK)
            {
                _LoadPersonInfoToDataGridView();
                _isAddOrUpdatePersonDialogResult = DialogResult.No;
            }
        }
        
        private void btn_OpenfrmAddUpdatePersonInfo_Click(object sender, EventArgs e)
        {
            const short modeValue = 1;
            _OpenAddUpdatePersonForm(modeValue);
        }

        private void toolStripMenuItem_AddNew_Click(object sender, EventArgs e)
        {
            const short modeValue = 1;
            _OpenAddUpdatePersonForm(modeValue);
        }

        private void toolStripMenuItem_Edit_Click(object sender, EventArgs e)
        {
            const short modeValue = 2;
            int personID = _GetCurrentPersonID();
            _OpenAddUpdatePersonForm(modeValue, personID);
        }

        private void toolStripMenuItem_ShowDetails_Click(object sender, EventArgs e)
        {
            int personID = _GetCurrentPersonID();
            frmShowPersonInfo frm = new frmShowPersonInfo(personID);
            frm.ShowDialog();

            if (_isAddOrUpdatePersonDialogResult == DialogResult.OK)
            {
                _LoadPersonInfoToDataGridView();
                _isAddOrUpdatePersonDialogResult = DialogResult.No;
            }
        }


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

        private void toolStripMenuItem_SoftDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = 
                MessageBox.Show("Are you sure you want to delete this person?", "Delete Person", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult != DialogResult.Yes)
                return;

            int personID = _GetCurrentPersonID();
            bool isDeleted = _SoftDeletePerson(personID);

            if(isDeleted)
                _LoadPersonInfoToDataGridView();
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
