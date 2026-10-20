using System;
using DVLD_BL.Validations;
using DVLD_Models.UI_Models;
using System.Collections.Generic;
using System.Windows.Forms;
using DVLD_Models.User;
using DVLD_Shared.Global_Classes;
using DVLD_Shared.Validation_Messages;

namespace DVLD_System_Solution.Forms._003_Manage_People.Controls
{
    public partial class uconPersonCardWithFilter : UserControl
    {
        public uconPersonCardWithFilter()
        {
            InitializeComponent();
        }

        private void txt_SearchValue_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(txt_SearchValue, string.Empty);
        }

        private void txt_SearchValue_MouseClick(object sender, MouseEventArgs e)
        {
            errorProvider1.SetError(txt_SearchValue, string.Empty);
        }

        private void txt_SearchValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (comBox_FilterItems.SelectedValue.ToString() == "PersonID")
                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar)) e.Handled = true; // امنع الإدخال
        }

        private void comBox_FilterItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt_SearchValue.Clear();
            txt_SearchValue.Select();
        }


        // >>
        private void _SetupComboBoxFilterItems()
        {
            List<clsComboBoxFilterItem> comboBoxFiltersItems = new List<clsComboBoxFilterItem>
            {
                new clsComboBoxFilterItem { Display = "Person ID"  , Value = "PersonID" },
                new clsComboBoxFilterItem { Display = "National No", Value = "NationalNO" }
            };

            comBox_FilterItems.DataSource = comboBoxFiltersItems;
            comBox_FilterItems.DisplayMember = "Display";
            comBox_FilterItems.ValueMember = "Value";
            txt_SearchValue.Select();
        }

        private void uconPersonCardWithFilter_Load(object sender, EventArgs e)
        {
            _SetupComboBoxFilterItems();
        }


        // >>
        private void btn_GetPersonBy_Click(object sender, EventArgs e)
        {
            if (!clsCurrentUser.HasPermission(enPermissions.ViewPersons))
            {
                MessageBox.Show(clsUserValidationMessages.PermissionDeniedMessage, "Permission Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string sreachValue = txt_SearchValue.Text.Trim();

            if(comBox_FilterItems.SelectedValue.ToString() == "PersonID")
            {
                clsValidationResult result = clsPersonValidations.ValidatePersonID(sreachValue);

                if (result.IsValid)
                    uconShowPersonInfo1.LoadActivePersonByID(result.ID);
                else
                    errorProvider1.SetError(txt_SearchValue, result.Message);
            }

            if (comBox_FilterItems.SelectedValue.ToString() == "NationalNO")
            {
                clsValidationResult result = clsPersonValidations.ValidateNationalNumber(sreachValue);

                if (result.IsValid)
                    uconShowPersonInfo1.LoadActivePersonByNationalNO(sreachValue);
                else
                    errorProvider1.SetError(txt_SearchValue, result.Message);
            }

            txt_SearchValue.Select();
        }
    }
}
