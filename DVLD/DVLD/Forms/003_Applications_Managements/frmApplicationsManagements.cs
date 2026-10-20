using DVLD_BL;
using DVLD_BL.Services;
using DVLD_Models;
using DVLD_Models.Application;
using DVLD_Models.Person;
using DVLD_Models.UI_Models;
using DVLD_Models.User;
using DVLD_Shared.Global_Classes;
using DVLD_Shared.Operations_Result;
using DVLD_Shared.Validation_Messages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DVLD_Shared.Operations_Result.clsOperationResult;

namespace DVLD_System_Solution.Forms._003_Manage_Applications
{
    public partial class frmApplicationsManagements : Form
    { 
        enApplicationStatuses _applicationStatuses = enApplicationStatuses.New; 


        public frmApplicationsManagements()
        {
            InitializeComponent();
        }

        private void _UpdateComboBoxFilterItems()
        {
            if (_applicationsGridViewDto == null || _applicationsGridViewDto.Count == 0)
            {
                comBox_FilterItems.SelectedValue = "None";
                comBox_FilterItems.Enabled = false;
            }
            else
                comBox_FilterItems.Enabled = true;
        }

        private void _UpdateApplicationIDLabel()
        {
            if (dataGridView_ShowApplicationsInfos.CurrentRow != null)
                lab_ApplicationIDToText.Text = dataGridView_ShowApplicationsInfos.CurrentRow.Cells["ID"].Value.ToString();
            else
                lab_ApplicationIDToText.Text = "???";
        }

        // >>

        private void _SetupComboBoxApplicationsStatusItems()
        {
            List<clsComboBoxFilterItem> comBApplicationsStatusFilterItems = new List<clsComboBoxFilterItem>
            {
                new clsComboBoxFilterItem { Display = "New"       , Value = "New" },
                new clsComboBoxFilterItem { Display = "Cancelled" , Value = "Cancelled" },
                new clsComboBoxFilterItem { Display = "Completed" , Value = "Completed" },
                new clsComboBoxFilterItem { Display = "All"       , Value = "All" }
            };

            comBox_DisplayStatus.DataSource = comBApplicationsStatusFilterItems;
            comBox_DisplayStatus.DisplayMember = "Display";
            comBox_DisplayStatus.ValueMember = "Value";
            comBox_DisplayStatus.Text = "New";
        }

        private void _SetupComboBoxFilterItems()
        {
            List<clsComboBoxFilterItem> comboBoxFiltersItems = new List<clsComboBoxFilterItem>
            {
                new clsComboBoxFilterItem { Display = "None"       , Value = "None" },
                new clsComboBoxFilterItem { Display = "Application ID"  , Value = "ApplicationID" },
                new clsComboBoxFilterItem { Display = "Person Name" , Value = "PersonName" },
                new clsComboBoxFilterItem { Display = "National No", Value = "NationalNO" },
                new clsComboBoxFilterItem { Display = "Service Name", Value = "ServiceName" },
                new clsComboBoxFilterItem { Display = "Application Status" , Value = "ApplicationStatus" },
                new clsComboBoxFilterItem { Display = "Application Date"  , Value = "ApplicationDate" }
            };

            comBox_FilterItems.DataSource = comboBoxFiltersItems;
            comBox_FilterItems.DisplayMember = "Display";
            comBox_FilterItems.ValueMember = "Value";
            comBox_FilterItems.Text = "None";
        }


        private Dictionary<string, Func<clsApplicationGridViewDto, string, bool>> _applicationFilterItems;
        private void _SetupFilters()
        {
            _SetupComboBoxFilterItems();
            _applicationFilterItems = clsApplicationsFilterService.GetApplicationFilters();
        }


        // >>
        private List<clsApplicationGridViewDto> _applicationsGridViewDto = null;
        
        private void _BindData(List<clsApplicationGridViewDto> applicationsList)
        {
            dataGridView_ShowApplicationsInfos.DataSource = applicationsList;

            if (applicationsList != null && applicationsList.Count > 0)
            {
                dataGridView_ShowApplicationsInfos.Columns["ID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                dataGridView_ShowApplicationsInfos.Columns["ID"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                dataGridView_ShowApplicationsInfos.Columns["PersonName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView_ShowApplicationsInfos.Columns["PersonName"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
               
                dataGridView_ShowApplicationsInfos.Columns["PaidFees"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }

            _UpdateComboBoxFilterItems();
            _UpdateApplicationIDLabel();
            lab_RecordsCount.Text = applicationsList == null ? "0" : applicationsList.Count.ToString();
        }

        
        private void _LoadApplicationsToDataGridView(enApplicationStatuses applicationStatuses)
        {
            (clsOperationResult result, List<clsApplicationGridViewDto> applicationsList) =
            clsApplicationBL.GetApplicationsForGridView(applicationStatuses);

            switch (result.Status)
            {
                case enOperationStatus.Success:
                    _applicationsGridViewDto = applicationsList;
                    _BindData(_applicationsGridViewDto);
                    break;

                case enOperationStatus.Failed:
                    MessageBox.Show(
                        result.Message,
                        "Failed To Retrieve Data",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    _applicationsGridViewDto = null;
                    _BindData(null);
                    break;

                case enOperationStatus.Exception:
                    MessageBox.Show(
                        result.Message,
                        "Database Exception",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    _applicationsGridViewDto = null;
                    _BindData(null);
                    break;
            }
        }

        private void _LoadData()
        {
            _SetupComboBoxApplicationsStatusItems();
            _SetupFilters();
            _LoadApplicationsToDataGridView(enApplicationStatuses.New);
        }

        private void frmManageApplications_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void comBox_DisplayStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            comBox_FilterItems.SelectedValue = "None";

            if (comBox_DisplayStatus.SelectedValue == null)
                return;

            string selectedValue = comBox_DisplayStatus.SelectedValue.ToString();

            switch (selectedValue)
            {
                case "New":
                    _LoadApplicationsToDataGridView(enApplicationStatuses.New);
                    break;

                case "Cancelled":
                    _LoadApplicationsToDataGridView(enApplicationStatuses.Cancelled);
                    break;

                case "Completed":
                    _LoadApplicationsToDataGridView(enApplicationStatuses.Completed);
                    break;

                case "All":
                    _LoadApplicationsToDataGridView(enApplicationStatuses.All);
                    break;
            }
        }

        // >>
        private void _ApplyApplicationFilter(string searchValue)
        {
            if (string.IsNullOrWhiteSpace(searchValue))
            {
                _BindData(_applicationsGridViewDto);
                return;
            }

            string filterSelected = comBox_FilterItems.SelectedValue.ToString();

            if (_applicationFilterItems.ContainsKey(filterSelected))
            {
                List<clsApplicationGridViewDto> result = clsApplicationsFilterService.ApplicationsFilters(
                    _applicationsGridViewDto, _applicationFilterItems, filterSelected, searchValue);
                _BindData(result);
            }
        }

        private void _ApplyFilter()
        {
            string searchValue = txt_SearchValue.Text.Trim();
            _ApplyApplicationFilter(searchValue);
            _UpdateApplicationIDLabel();
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

        private void dataGridView_ShowApplicationsInfos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            _UpdateApplicationIDLabel();
        }
    }
}
