using System;
using DVLD_BL;
using System.IO;
using DVLD_Models;
using System.Drawing;
using DVLD_BL.Validations;
using System.Windows.Forms;
using System.Collections.Generic;
using DVLD_Shared.Global_Classes;
using DVLD_Shared.Operations_Result;
using static DVLD_Shared.Operations_Result.clsOperationResult;
using static DVLD_Shared.Global_Enums.clsEnumHelpers;
using DVLD_Models.User;
using DVLD_Models.Role;

namespace Main_Screen.Forms.Persons
{
    public partial class frmAddUpdatePersons : Form
    {
        private int _PersonID = -1;
        enAddUpdateMode _addUpdateMode;
        
        private string _UniqueImageName = "";
        
        private string _SelectedImagePath = "";

        enum enImageState { None = 1, Add = 2, Replace = 3, Remove = 4 };
        enImageState _ImageState = enImageState.None;

        // Costructor
        public frmAddUpdatePersons(int personID = -1, enAddUpdateMode addUpdateMode = enAddUpdateMode.AddNewInfo)
        {
            InitializeComponent();

             _PersonID = personID;
            _addUpdateMode = addUpdateMode;
        }

        // >> 
        private void _UpdateModeStatusLabel()
        {
            switch (_addUpdateMode)
            {
                case enAddUpdateMode.AddNewInfo:
                    lab_ModeStatue.Text = "Add New Person";
                    break;

                case enAddUpdateMode.UpdateInfo:
                    lab_ModeStatue.Location = new Point(220, 36);
                    lab_ModeStatue.Text = "Update Person Info";
                    break;
            }
        }

        private void _SetAllowedBirthDateRange(int maxAge, int minAge)
        {
            dateTimePicker1.MaxDate = clsValidationHelper.GetLatestBirthDateForAge(maxAge);
            dateTimePicker1.MinDate = clsValidationHelper.GetLatestBirthDateForAge(minAge);
        }


        // Get All Countries
        private void _BindCountriesToComboBox(List<clsCountry> countries)
        {
            comB_Countries.DataSource = countries;
            comB_Countries.DisplayMember = "CountryName";
            comB_Countries.ValueMember = "CountryID";
            comB_Countries.Text = "Egypt";
        }

        private void _GetAllCountries()
        {
            (clsOperationResult result, List<clsCountry> countries) = clsCountryBL.GetAllCountries();

            switch (result.Status)
            {
                case enOperationStatus.Success:
                    _BindCountriesToComboBox(countries);
                    break;

                case enOperationStatus.Failed:
                    MessageBox.Show(result.Message, "Filed To Retrive Data", MessageBoxButtons.OK, MessageBoxIcon.None);
                    break;

                case enOperationStatus.Exception:
                    MessageBox.Show(result.Message, "Database Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }


        // Link Text Boxes Events
        private void _ClearErrorProviderOn_MouseClick(object sender, MouseEventArgs e)
        {
            var control = sender as Control;
            if (control == null) return;

            errorProvider1.SetError(control, string.Empty);
        }

        private void _ClearErrorProviderOn_TextChanged(object sender, EventArgs e)
        {
            var control = sender as Control;
            if (control == null) return;

            errorProvider1.SetError(control, string.Empty);
        }

        private void _ClearWhiteSpaceTextBox(Control control)
        {
            if (control == null) return;

            control.Text = control.Text?.Trim();
        }

        private void _ClearWhiteSpaceOn_MouseDown(object sender, EventArgs e)
        {
            var control = sender as Control;
            if (control == null) return;

            _ClearWhiteSpaceTextBox(control);
        }

        private void _AttachTextBoxEvents(Control parent)
        {
            foreach (Control control in parent.Controls)
            {
                if (control.HasChildren)
                    _AttachTextBoxEvents(control);

                if (control is TextBox)
                {
                    control.MouseClick += _ClearErrorProviderOn_MouseClick;
                    control.TextChanged += _ClearErrorProviderOn_TextChanged;
                    control.Leave += _ClearWhiteSpaceOn_MouseDown;
                }
            }
        }


        // Set Default Person Image
        private void _SetDefaultPersonImage()
        {
            string imagePath = clsImageHelper.GetOrCreateDefaultPersonImageFolderPath();

            if (rdoB_Male.Checked)
                imagePath = Path.Combine(imagePath, "Male.png");
            else if (rdoB_Female.Checked)
                imagePath = Path.Combine(imagePath, "Female.png");

            Image image = clsImageHelper.LoadImageSafe(imagePath);

            if (image != null)
            {
                picB_PersonImage.Image = image;
                linkL_RemoveImage.Visible = false;
            }
        }

        private void _SetPersonImage()
        {
            if (string.IsNullOrWhiteSpace(_UniqueImageName)) return;

            string personImagePath = Path.Combine(clsImageHelper.GetOrCreatePersonsImagesFolderPath(), _UniqueImageName);

            Image image = clsImageHelper.LoadImageSafe(personImagePath);

            if(image != null)
            {
                picB_PersonImage.Image = image;
                linkL_RemoveImage.Visible = true;
            }
        }

        private void _Gender_CheckedChanged(object sender, EventArgs e)
        {
            if (_ImageState == enImageState.None && string.IsNullOrWhiteSpace(_UniqueImageName))
                _SetDefaultPersonImage();
        }

        
        // >>>>
        private void _GetCheckedGender(char gender)
        {
            if (gender == 'M')
                rdoB_Male.Checked = true;

            if (gender == 'F')
                rdoB_Female.Checked = true;
        }

        private void _FillFromByPersonInfo(clsPerson person)
        {
            lab_PersonIDToText.Text = person.PersonID.ToString();
            txt_FirstName.Text = person.FirstName;
            txt_SecondName.Text = person.SecondName;
            txt_ThirdName.Text = person.ThirdName;
            txt_LastName.Text = person.LastName;
            txt_NationalNo.Text = person.NationalNO;
            txt_Email.Text = person.Email;
            txt_Phone.Text = person.Phone;
            txt_Address.Text = person.Address;

            _GetCheckedGender(person.Gender);
            dateTimePicker1.Value = person.DateOfBirth;

            int? nationaltyCountryID = person.NationalityCountryID.Value;

            if (!nationaltyCountryID.HasValue)
                nationaltyCountryID = 250;

            comB_Countries.SelectedValue = nationaltyCountryID;

            txt_NationalNo.Enabled = false;

            _UniqueImageName = person.ImageName;

            if (string.IsNullOrWhiteSpace(_UniqueImageName))
                _SetDefaultPersonImage();
            else
                _SetPersonImage();
        }

        private void _GetPersonByID(int personID)
        {
            (clsOperationResult result, clsPerson person) = clsPersonBL.GetPersonByID(personID);

            switch(result.Status)
            {
                case enOperationStatus.Success:
                    if(person != null) _FillFromByPersonInfo(person);
                    break;

                case enOperationStatus.Failed:
                    MessageBox.Show(result.Message, "Failed Operation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;

                case enOperationStatus.Exception:
                    MessageBox.Show(result.Message, "Database Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }

        private void _PrepareFormForCurrentMode()
        {
            switch (_addUpdateMode)
            {
                case enAddUpdateMode.AddNewInfo:
                    {
                        _SetDefaultPersonImage();
                        _UniqueImageName = "";
                        break;
                    }

                case enAddUpdateMode.UpdateInfo:
                    {
                        _GetPersonByID(_PersonID);
                        break;
                    }
            }

            _SelectedImagePath = "";
            _ImageState = enImageState.None;
        }

        // Load Form
        private void frmAddUpdatePersonsInfo_Load(object sender, EventArgs e)
        {
            _UpdateModeStatusLabel();
            _SetAllowedBirthDateRange(18, 50);
            _GetAllCountries();
            _AttachTextBoxEvents(this);
            _PrepareFormForCurrentMode();
        }


        // Link Label Load Image To Picture Box
        private bool _LoadImageToPictureBox(string imagePath)
        {
            if (string.IsNullOrWhiteSpace(imagePath)) return false;

            Image image = clsImageHelper.LoadImageSafe(imagePath);

            if (image != null)
            {
                picB_PersonImage.Image = image;
                linkL_RemoveImage.Visible = true;
                return true;
            }

            return false;
        }

        private void _SelectAndLoadPersonImage()
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Title = "Select an Image";
                dialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
                dialog.Multiselect = false;

                if (dialog.ShowDialog() != DialogResult.OK) return;

                try
                {
                    _SelectedImagePath = dialog.FileName;

                    bool loadImage = _LoadImageToPictureBox(_SelectedImagePath);

                    if(loadImage)
                    {
                        if(_addUpdateMode == enAddUpdateMode.AddNewInfo)
                        {
                            _ImageState = enImageState.Add;
                            return;
                        }

                        if(_addUpdateMode == enAddUpdateMode.UpdateInfo)
                        {
                            if (string.IsNullOrWhiteSpace(_UniqueImageName))
                            {
                                _ImageState = enImageState.Add;
                            }
                            else
                            {
                                _ImageState = enImageState.Replace;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading image: {ex.Message}");
                }
            }
        }

        private void linkL_SetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _SelectAndLoadPersonImage();
        }

        
        // Remove Image From Picture Box
        private void _RemoveImageFromPicBox()
        {
            DialogResult dialogResult = MessageBox.Show(">> Are you sure you want to remove this image?", "Remove Image",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult != DialogResult.Yes) return;

            if (picB_PersonImage.Image != null)
            {
                picB_PersonImage.Image.Dispose();
                picB_PersonImage.Image = null;
            }

            _SetDefaultPersonImage();

            if (_addUpdateMode == enAddUpdateMode.AddNewInfo)
            {
                _ImageState = enImageState.None;

                _UniqueImageName = "";
                
                _SelectedImagePath = "";
                
                return;
            }

            if (_addUpdateMode == enAddUpdateMode.UpdateInfo)
            {
                if (string.IsNullOrWhiteSpace(_UniqueImageName))
                {
                    _ImageState = enImageState.None;

                    _SelectedImagePath = "";
                }
                else
                {
                    _ImageState = enImageState.Remove;
                }
            }
        }

        private void linkL_Remove_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _RemoveImageFromPicBox();
        }
        
        
        // Save Data To Database
        public delegate void AddOrUpdatePersonDialogResultEventHandler(object sender, DialogResult dialogResult);
        public static event AddOrUpdatePersonDialogResultEventHandler AddOrUpdatePersonDialogResultReceived;

        
        // Bulid Person Info
        private char _GetGender()
        {
            return rdoB_Male.Checked ? 'M' : 'F';
        }

        private string _imagesFolderToSavePersonsImages = clsImageHelper.GetOrCreatePersonsImagesFolderPath();

        private string _OldImageName = "";

        private bool _RemoveOrReplaceOldImage = false;

        enum enPersonImageSaveResult { Valid = 1, Failed = 2};
        enPersonImageSaveResult _PersonImageSaveResult = enPersonImageSaveResult.Valid;

        private string _SavePersonImageAndGetUniqueName()
        {
            switch (_ImageState)
            {
                case enImageState.None:
                    return _UniqueImageName;

                case enImageState.Add:
                    {
                        string uniqueImageName = $"{Guid.NewGuid()}{Path.GetExtension(_SelectedImagePath)}";

                        string destinationPath = Path.Combine(_imagesFolderToSavePersonsImages, uniqueImageName);

                        clsOperationResult result = clsImageHelper.CopyImage(_SelectedImagePath, destinationPath);

                        if (result.Status != enOperationStatus.Success)
                        {
                            _PersonImageSaveResult = enPersonImageSaveResult.Failed;

                            MessageBox.Show(result.Message, "Image Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            return _UniqueImageName;
                        }

                        _PersonImageSaveResult = enPersonImageSaveResult.Valid;

                        _UniqueImageName = uniqueImageName;

                        return uniqueImageName;
                    }

                case enImageState.Replace:
                    {
                        string uniqueImageName = $"{Guid.NewGuid()}{Path.GetExtension(_SelectedImagePath)}";

                        string destinationPath = Path.Combine(_imagesFolderToSavePersonsImages, uniqueImageName);

                        clsOperationResult result = clsImageHelper.CopyImage(_SelectedImagePath, destinationPath);

                        if (result.Status != enOperationStatus.Success)
                        {
                            _PersonImageSaveResult = enPersonImageSaveResult.Failed;

                            MessageBox.Show(result.Message, "Image Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            return _UniqueImageName;
                        }

                        _PersonImageSaveResult = enPersonImageSaveResult.Valid;

                        _RemoveOrReplaceOldImage = true;

                        _OldImageName = _UniqueImageName;

                        // Save uniqueImageName in DB.
                        _UniqueImageName = uniqueImageName;

                        // After DB succeeds:

                        // Delete old image if exists.
                        
                        return uniqueImageName;
                    }

                case enImageState.Remove:
                    {
                        _RemoveOrReplaceOldImage = true;

                        _OldImageName = _UniqueImageName;

                        _UniqueImageName = "";

                        return _UniqueImageName;
                    }
            }
            
            return "";
        }

        private clsPerson _BuildPersonInfo()
        {
            return new clsPerson{
                PersonID = _PersonID,
                FirstName = txt_FirstName.Text.Trim(),
                SecondName = txt_SecondName.Text.Trim(),
                ThirdName = txt_ThirdName.Text.Trim(),
                LastName = txt_LastName.Text.Trim(),
                NationalNO = txt_NationalNo.Text.Trim().ToUpper(),
                Gender = _GetGender(),
                DateOfBirth = dateTimePicker1.Value.Date,
                Email = txt_Email.Text.Trim(),
                Phone = txt_Phone.Text.Trim(),
                Address = txt_Address.Text.Trim(),
                NationalityCountryID = (int)comB_Countries.SelectedValue,
                ImageName = _SavePersonImageAndGetUniqueName()};
        }

        private Control _GetControlByPropertyName(string propertyName)
        {
            if (propertyName == nameof(clsPerson.FirstName))
                return txt_FirstName;

            if (propertyName == nameof(clsPerson.SecondName))
                return txt_SecondName;

            if (propertyName == nameof(clsPerson.ThirdName))
                return txt_ThirdName;

            if (propertyName == nameof(clsPerson.LastName))
                return txt_LastName;

            if (propertyName == nameof(clsPerson.NationalNO))
                return txt_NationalNo;

            if (propertyName == nameof(clsPerson.Email))
                return txt_Email;

            if (propertyName == nameof(clsPerson.DateOfBirth))
                return dateTimePicker1;

            if (propertyName == nameof(clsPerson.Phone))
                return txt_Phone;

            if (propertyName == nameof(clsPerson.Address))
                return txt_Address;

            return null;
        }

        private void _SetErrorProvider(string propertyName, string message)
        {
            Control control = _GetControlByPropertyName(propertyName);
            errorProvider1.SetError(control, message);
            control.Select();
        }

        private bool _AddNewPersonAndGetNewID(clsPerson person)
        {
            clsOperationResult result = clsPersonBL.AddNewPerson(person);

            switch(result.Status)
            {
                case enOperationStatus.Success:
                    _PersonID = result.CreatedID;
                    AddOrUpdatePersonDialogResultReceived?.Invoke(this, DialogResult.OK);
                    MessageBox.Show(result.Message, "Operation Succeeded", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;

                case enOperationStatus.Failed:
                    if(string.IsNullOrEmpty(result.PropertyName))
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
        
        private void _HandleSuccessfulSave()
        {
            lab_PersonIDToText.Text = _PersonID.ToString();
            
            lab_PersonIDToText.ForeColor = Color.LimeGreen;

            if (!clsCurrentUser.HasPermission(enPermissions.UpdatePerson))
                return;

            _addUpdateMode = enAddUpdateMode.UpdateInfo;
            
            _UpdateModeStatusLabel();
         
            txt_NationalNo.Enabled = false;
        }

        private bool _UpdatePersonInfo(clsPerson person)
        {
            clsOperationResult result = clsPersonBL.UpdatePersonInfo(person);

            switch (result.Status)
            {
                case enOperationStatus.Success:
                    AddOrUpdatePersonDialogResultReceived?.Invoke(this, DialogResult.OK);
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


        // Save Person Info
        private void _DeleteCopiedImageIfNeeded()
        {
            string oldImagePath = Path.Combine(_imagesFolderToSavePersonsImages, _UniqueImageName);

            clsOperationResult result = clsImageHelper.DeleteImage(oldImagePath);

            if (result.Status == enOperationStatus.Failed || result.Status == enOperationStatus.Exception)
                MessageBox.Show(result.Message, "Image Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void _Save()
        {
            if (_PersonImageSaveResult == enPersonImageSaveResult.Failed)
                return;

            switch (_addUpdateMode)
            {
                case enAddUpdateMode.AddNewInfo:
                    {
                        bool isAdded = _AddNewPersonAndGetNewID(_BuildPersonInfo());
                        
                        if (isAdded)
                            _HandleSuccessfulSave();
                        else
                        {
                            if(_ImageState == enImageState.Add && _PersonImageSaveResult == enPersonImageSaveResult.Valid && 
                                !string.IsNullOrWhiteSpace(_UniqueImageName))
                                _DeleteCopiedImageIfNeeded();
                        }
                    
                        break;
                    }

                case enAddUpdateMode.UpdateInfo:
                    {
                        bool isUpdated = _UpdatePersonInfo(_BuildPersonInfo());
                        
                        if (isUpdated)
                        {
                            if ((_ImageState == enImageState.Replace || _ImageState == enImageState.Remove) &&
                                _RemoveOrReplaceOldImage && !string.IsNullOrWhiteSpace(_OldImageName))
                            {
                                string oldImagePath = Path.Combine(_imagesFolderToSavePersonsImages, _OldImageName);

                                clsOperationResult result = clsImageHelper.DeleteImage(oldImagePath);

                                if (result.Status == enOperationStatus.Failed || result.Status == enOperationStatus.Exception)
                                    MessageBox.Show(result.Message, "Image Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                                _RemoveOrReplaceOldImage = false;
                                _OldImageName = "";
                            }
                        }
                        else
                        {
                            if ((_ImageState == enImageState.Add || _ImageState == enImageState.Replace) && _PersonImageSaveResult == enPersonImageSaveResult.Valid &&
                                !string.IsNullOrWhiteSpace(_UniqueImageName))
                                _DeleteCopiedImageIfNeeded();
                        }

                        break;
                    }
            }
           
            _ImageState = enImageState.None;
            _SelectedImagePath = "";
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            _Save();
        }

        // >>

        private void txt_Phone_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow control keys (Backspace, Delete, etc.)
            if (char.IsControl(e.KeyChar))
                return;

            // Allow digits
            if (char.IsDigit(e.KeyChar))
                return;

            // Allow '+' only at the beginning and only once
            if (e.KeyChar == '+' && txt_Phone.SelectionStart == 0 && !txt_Phone.Text.Contains("+"))
                return;

            e.Handled = true;
        }

        private void txt_Phone_TextChanged(object sender, EventArgs e)
        {
            if (txt_Phone.Text.StartsWith("+"))
                txt_Phone.MaxLength = 13; // +201XXXXXXXXX
            else
                txt_Phone.MaxLength = 11; // 01XXXXXXXXX
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(dateTimePicker1, string.Empty);
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
