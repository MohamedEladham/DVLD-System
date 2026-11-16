using DVLD_BL;
using DVLD_Models;
using DVLD_Models.Application;
using DVLD_Models.LicenseClass;
using DVLD_Models.Person;
using DVLD_Shared.Events;
using DVLD_Shared.Operations_Result;
using DVLD_Shared.Validation_Messages;
using DVLD_System_Solution.Forms._003_Applications_Managements._001_User_Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DVLD_Shared.Global_Enums.clsEnumHelpers;
using static DVLD_Shared.Operations_Result.clsOperationResult;

namespace DVLD_System_Solution.Forms._003_Applications_Managements._002_FirstTimeDrivingLicenesApplication_Screen
{
    public partial class frmFirstTimeDrivingLicenesApplication : Form
    {
        private int _personID = -1;
        private int _licenseClassID = -1;
        private short _minimunAgeForLicenseClass = -1; 

        public frmFirstTimeDrivingLicenesApplication(int personID)
        {
            InitializeComponent();
            _personID = personID;
        }


        // >>
        private void txt_ApplicationPaidFees_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow control keys (Backspace, Delete, etc.)
            if (char.IsControl(e.KeyChar))
                return;

            // Allow digits
            if (char.IsDigit(e.KeyChar))
                return;

            // Allow only one decimal point
            if (e.KeyChar == '.' && !((TextBox)sender).Text.Contains("."))
                return;

            e.Handled = true;
        }

        private void txt_ApplicationPaidFees_MouseClick(object sender, MouseEventArgs e)
        {
            errorProvider1.SetError(txt_ApplicationPaidFees, string.Empty);
        }

        private void txt_ApplicationPaidFees_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(txt_ApplicationPaidFees, string.Empty);
        }

        private void comBox_LicenseClasses_MouseClick(object sender, MouseEventArgs e)
        {
            errorProvider1.SetError(comBox_LicenseClasses, string.Empty);
        }

        
        // >>
        private List<clsLicenseClass> GetAllActiveLicenseClassesBasicInfo()
        {
            (clsOperationResult result, List<clsLicenseClass> licenseClasses) = clsLicenseClassBL.GetAllActiveLicenseClassesBasicInfo();

            switch (result.Status)
            {
                case enOperationStatus.Success:
                    return licenseClasses;

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

        private List<clsLicenseClass> _licenseClasses = null;
       
        private void _LoadLicenseClassesToComboBox()
        {
            _licenseClasses = GetAllActiveLicenseClassesBasicInfo();
            comBox_LicenseClasses.DataSource = _licenseClasses;
            comBox_LicenseClasses.DisplayMember = "ClassName";
            comBox_LicenseClasses.ValueMember = "LicenseClassID";
            comBox_LicenseClasses.SelectedIndex = -1;
        }

        private void frmFirstTimeDrivingLicenesApplication_Load(object sender, EventArgs e)
        {
            uconApplicationDetails1.LoadPersonBasicInfoAndServiceBasicInfo(_personID, (int)enServices.FirstTimeLicenseIssuance);
            _LoadLicenseClassesToComboBox();
        }

        private void comBox_LicenseClasses_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((comBox_LicenseClasses.SelectedValue is int))
                _licenseClassID = Convert.ToInt32(comBox_LicenseClasses.SelectedValue);

            if (comBox_LicenseClasses.SelectedItem is clsLicenseClass licenseClass)
                lab_MinimumAgeForLicenseClass.Text = Convert.ToString(licenseClass.MinimumAllowedAge);
            else
                lab_MinimumAgeForLicenseClass.Text = "???";

        }


        // >>
        private bool _ValidateApplicationPaidFees()
        {
            if (string.IsNullOrWhiteSpace(txt_ApplicationPaidFees.Text))
            {
                errorProvider1.SetError(txt_ApplicationPaidFees, clsApplicationValidationMessages.ApplicationPaidFeesRequiredMessage);
                return false;
            }

            if (!decimal.TryParse(txt_ApplicationPaidFees.Text, out decimal paidFees))
            {
                errorProvider1.SetError(txt_ApplicationPaidFees, clsApplicationValidationMessages.InvalidApplicationPaidFeesMessage);
                return false;
            }

            return true;
        }

        private Control _GetControlByPropertyName(string propertyName)
        {
            if (propertyName == nameof(clsLicenseClass.LicenseClassID))
                return comBox_LicenseClasses;

            if (propertyName == nameof(clsApplication.ApplicationPaidFees))
                return txt_ApplicationPaidFees;

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

        private void _SetLicenseClassIDAndMinimumAgeForLicenseClass()
        {
            if (comBox_LicenseClasses.SelectedIndex > -1)
            {
                if (comBox_LicenseClasses.SelectedItem is clsLicenseClass selectedLicenseClass)
                {
                    _licenseClassID = selectedLicenseClass.LicenseClassID;
                    _minimunAgeForLicenseClass = selectedLicenseClass.MinimumAllowedAge;
                    return;
                }
            }

            _licenseClassID = -1;
            _minimunAgeForLicenseClass = -1;
        }

        private bool _SaveApplication()
        {
            clsOperationResult result =
                clsFirstTimeDrivingLicenseApplicationBL.
                AddFirstTimeDrivingLicenseApplication(
                    _personID, (int)enServices.FirstTimeLicenseIssuance,
                    _licenseClassID, txt_ApplicationPaidFees.Text.Trim());

            switch (result.Status)
            {
                case enOperationStatus.Success:
                    if (result.CreatedID > 0) clsApplicationEvents.RaiseApplicationCreated(result.CreatedID);
                    MessageBox.Show(result.Message, "Operation Succeeded", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btn_Save_Click(object sender, EventArgs e)
        {
            _SaveApplication();
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
