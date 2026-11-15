using System;
using DVLD_BL;
using System.IO;
using DVLD_Models;
using System.Drawing;
using System.Windows.Forms;
using Main_Screen.Forms.Persons;
using DVLD_Shared.Global_Classes;
using DVLD_Shared.Operations_Result;
using static DVLD_Shared.Global_Enums.clsEnumHelpers;
using static DVLD_Shared.Operations_Result.clsOperationResult;
using DVLD_Models.User;

namespace DVLD_System_Solution.Forms._003_Manage_People.Controls
{
    public partial class uconShowPersonInfo : UserControl
    {
        private int _personID = -1;
        public uconShowPersonInfo()
        {
            InitializeComponent();
        }

        private DialogResult _isAddOrUpdatePersonDialogResult = DialogResult.No;

        private void _GetIsAddOrUpdatePersonDialogResult(object sender, DialogResult dialogResult)
        {
            _isAddOrUpdatePersonDialogResult = dialogResult;
        }

        private void uconShowPersonInfo_Load(object sender, EventArgs e)
        {
            frmAddUpdatePersons.AddOrUpdatePersonDialogResultReceived += _GetIsAddOrUpdatePersonDialogResult;
        }

        // >>

        public void SetLinkLabelEditPerson(enPersonStatus personStatus)
        {
            linkLabel_EditPerson.Visible = (personStatus == enPersonStatus.Active);
        }

        // >> 

        private string _GetGenderName(char gender)
        {
            return gender == 'M' ? "Male" : "Female";
        }

        private string _GetCountryNameByCountryID(int countryID)
        {
            (clsOperationResult result, string countryName) = clsCountryBL.GetCountryNameByCountryID(countryID);

            switch (result.Status)
            {
                case enOperationStatus.Success:
                    return countryName;

                case enOperationStatus.Failed:
                    MessageBox.Show(result.Message, "Failed Operation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return string.Empty;

                case enOperationStatus.Exception:
                    MessageBox.Show(result.Message, "Database Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return string.Empty;

                default:
                    return string.Empty;
            }
        }

        private void _SetDefaultPersonImage(char gender)
        {
            picB_PersonImage.Image = gender == 'M' ?
                DVLD_System_Solution.Properties.Resources.Male_512 :
                DVLD_System_Solution.Properties.Resources.Female_512;
        }

        private void _SetPersonImage(string imageName)
        {
            string personImagePath = Path.Combine(clsImageHelper.GetOrCreatePersonsImagesFolderPath(), imageName);

            Image image = clsImageHelper.LoadImageSafe(personImagePath);

            if (image != null)
            {
                picB_PersonImage.Image = image;
            }
        }

        private void _DisplayPersonImage(string imageName, char gender)
        {
            if (string.IsNullOrWhiteSpace(imageName))
                _SetDefaultPersonImage(gender);
            else
                _SetPersonImage(imageName);
        }

        public delegate void SendPersonEventHandler(object sender, int personID);
        public static event SendPersonEventHandler SendPersonID;

        private void _FillUserControlByPersonInfo(clsPerson personInfo)
        {
            _personID = personInfo.PersonID;
            SendPersonID?.Invoke(this, _personID);
            linkLabel_EditPerson.Enabled = clsCurrentUser.HasPermission(enPermissions.UpdatePerson);
            lab_PersonID.Text = personInfo.PersonID.ToString();
            lab_Name.Text = personInfo.FirstName + " - " + personInfo.SecondName + " - " + personInfo.ThirdName + " - " + personInfo.LastName;
            lab_NationalNO.Text = personInfo.NationalNO;
            lab_Gendor.Text = _GetGenderName(personInfo.Gender);
            lab_DateOfBirth.Text = personInfo.DateOfBirth.ToShortDateString();
            lab_Email.Text = personInfo.Email;
            lab_Phone.Text = personInfo.Phone;
            lab_Country.Text = personInfo.NationalityCountryID.HasValue ? _GetCountryNameByCountryID(personInfo.NationalityCountryID.Value) : "N/A";
            lab_Address.Text = personInfo.Address;
            _DisplayPersonImage(personInfo.ImageName, personInfo.Gender);
        }

        private void _ResetUserControl()
        {
            _personID = -1;
            SendPersonID?.Invoke(this, _personID);
            linkLabel_EditPerson.Enabled = false;
            lab_PersonID.Text = "[???]";
            lab_Name.Text = "[???]";
            lab_NationalNO.Text = "[???]";
            lab_Gendor.Text = "[???]";
            lab_DateOfBirth.Text = "[???]";
            lab_Email.Text = "[???]";
            lab_Phone.Text = "[???]";
            lab_Country.Text = "[???]";
            lab_Address.Text = "[???]";
            _DisplayPersonImage(null, 'M');
        }

        
        // >>
        public void LoadActivePersonByID(int personID)
        {
            (clsOperationResult result, clsPerson person) = clsPersonBL.GetActivePersonByID(personID);

            switch (result.Status)
            {
                case enOperationStatus.Success:
                    if (person != null) _FillUserControlByPersonInfo(person);
                    
                    break;

                case enOperationStatus.Failed:
                    _ResetUserControl();
                    MessageBox.Show(result.Message, "Failed Operation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;

                case enOperationStatus.Exception:
                    _ResetUserControl();
                    MessageBox.Show(result.Message, "Database Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }

        public void LoadActivePersonByNationalNO(string NationalNo)
        {
            (clsOperationResult result, clsPerson person) = clsPersonBL.GetActivePersonByNationalNO(NationalNo);

            switch (result.Status)
            {
                case enOperationStatus.Success:
                    if (person != null)    _FillUserControlByPersonInfo(person);
                    
                    break;

                case enOperationStatus.Failed:
                    _ResetUserControl();
                    MessageBox.Show(result.Message, "Failed Operation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;

                case enOperationStatus.Exception:
                    _ResetUserControl();
                    MessageBox.Show(result.Message, "Database Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }


        // >>
        public void LoadPersonByID(int personID)
        {
            (clsOperationResult result, clsPerson person) = clsPersonBL.GetPersonByID(personID);

            switch (result.Status)
            {
                case enOperationStatus.Success:
                    if (person != null) _FillUserControlByPersonInfo(person);
                    
                    break;

                case enOperationStatus.Failed:
                    MessageBox.Show(result.Message, "Failed Operation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    linkLabel_EditPerson.Enabled = false;
                    break;

                case enOperationStatus.Exception:
                    MessageBox.Show(result.Message, "Database Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    linkLabel_EditPerson.Enabled = false;
                    break;
            }
        }

        private void linkLabel_EditPerson_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (_personID <= 0) 
                return;
            
            frmAddUpdatePersons frm = new frmAddUpdatePersons(_personID, enAddUpdateMode.UpdateInfo);
            frm.ShowDialog();

            if(_isAddOrUpdatePersonDialogResult == DialogResult.OK)
            {
                LoadPersonByID(_personID);
                _isAddOrUpdatePersonDialogResult = DialogResult.No;
            }
        }
    }
}
