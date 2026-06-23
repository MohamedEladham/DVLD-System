using System;
using DVLD_BL;
using DVLD_Models;
using System.Windows.Forms;
using DVLD_Models.UI_Models;
using System.Collections.Generic;

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

        private Dictionary<string, Func<clsPersonInfoGridViewDto, string, bool>> _filters;
        private void _SetupPersonFilter()
        {
            _filters = clsPersonFilterService.GetPersonFilters();
        }
     
        // >> 

        List<clsPersonInfoGridViewDto> _personsGridViewDto = null;
        private void _LoadPersonInfoToDataGridView()
        {
            _personsGridViewDto = clsPersonBL.GetPersonsForGridView();

            if(_personsGridViewDto != null && _personsGridViewDto.Count > 0)
                _BindData(_personsGridViewDto);
        }

        private void _LoadData()
        {
            _SetupComboBoxFilterItems();
            _SetupPersonFilter();
            _LoadPersonInfoToDataGridView();
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
                List<clsPersonInfoGridViewDto> result = clsPersonFilterService.FilterPersonToGridView(_personsGridViewDto, _filters, filterSelected, searchValue);
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
    }
}
