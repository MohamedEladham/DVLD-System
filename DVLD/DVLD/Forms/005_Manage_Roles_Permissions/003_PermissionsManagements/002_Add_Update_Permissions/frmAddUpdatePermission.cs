using DVLD_BL;
using DVLD_Models.Permissions;
using DVLD_Models.Role;
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
using static DVLD_Shared.Global_Enums.clsEnumHelpers;
using static DVLD_Shared.Operations_Result.clsOperationResult;

namespace DVLD_System_Solution.Forms._005_Manage_Roles_Permissions._003_PermissionsManagements._002_Add_Update_Permissions
{
    public partial class frmAddUpdatePermission : Form
    {
        private int _permissionID = -1;
        enAddUpdateMode _addUpdateMode = enAddUpdateMode.AddNewInfo;

        public frmAddUpdatePermission(enAddUpdateMode addUpdateMode, int permissionID = -1)
        {
            InitializeComponent();
            _addUpdateMode = addUpdateMode;
            _permissionID = permissionID;
        }

        private void TextBoxies_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError((Control)sender, string.Empty);
        }

        private void TextBoxies_MouseClick(object sender, MouseEventArgs e)
        {
            errorProvider1.SetError((Control)sender, string.Empty);
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

        private void _UpdateModeStatusLabel()
        {
            switch (_addUpdateMode)
            {
                case enAddUpdateMode.AddNewInfo:
                    lab_ModeStatue1.Text = "Add Permissions";
                    break;

                case enAddUpdateMode.UpdateInfo:
                    //lab_ModeStatue1.Location = new Point(165, 36);
                    lab_ModeStatue1.Text = "Update Permissions";
                    break;
            }
        }


        // >>
        private clsPermission _GetPermissionByID(int permissionID)
        {
            (clsOperationResult result, clsPermission permission) = clsPermissionBL.GetPermissionByPermissionID(permissionID);

            switch (result.Status)
            {
                case enOperationStatus.Success:
                    return permission;

                case enOperationStatus.Failed:
                    MessageBox.Show(result.Message, "Failed Operation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return null;

                case enOperationStatus.Exception:
                    MessageBox.Show(result.Message, "Database Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;

                default:
                    return null;
            }
        }

        private void _FillFormByPermissionInfo(clsPermission permission)
        {
            lab_PermissionID.Text = permission.PermissionID.ToString();
            txt_PermissionName.Text = permission.PermissionName;
            txt_PermissionCategory.Text = permission.PermissionCategory;
        }

        public void _LoadPermissionInfoByPermissionID(int permissionID)
        {
            clsPermission permission = _GetPermissionByID(permissionID);

            if (permission != null)
                _FillFormByPermissionInfo(permission);
        }

        private void frmAddUpdatePermission_Load(object sender, EventArgs e)
        {
            _UpdateModeStatusLabel();

            if(_addUpdateMode == enAddUpdateMode.UpdateInfo)
                _LoadPermissionInfoByPermissionID(_permissionID); 
        }



        // >>
        public delegate void AddUpdatePermissionEventHandler(object sender, bool isAdded);
        public static event AddUpdatePermissionEventHandler AddUpdatePermission;

        private clsPermission _BuildPermission()
        {
            return new clsPermission
            {
                PermissionID = _permissionID,
                PermissionName = txt_PermissionName.Text.Trim(),
                PermissionCategory = txt_PermissionCategory.Text.Trim(),
            };
        }

        private Control _GetControlByPropertyName(string propertyName)
        {
            if (propertyName == nameof(clsPermission.PermissionName))
                return txt_PermissionName;

            if (propertyName == nameof(clsPermission.PermissionCategory))
                return txt_PermissionCategory;

            return null;
        }

        private void _SetErrorProvider(string propertyName, string message)
        {
            Control control = _GetControlByPropertyName(propertyName);
            errorProvider1.SetError(control, message);
            control.Select();
        }

        private bool _AddNewPermission(clsPermission permission)
        {
            if (!_HasPermission(enPermissions.AddPermissions))
                return false;

            clsOperationResult result = clsPermissionBL.AddNewPermission(permission);

            switch (result.Status)
            {
                case enOperationStatus.Success:
                    _permissionID = result.CreatedID;
                    AddUpdatePermission?.Invoke(this, true);
                    MessageBox.Show(result.Message, "Operation Successded", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void _HandleSuccessfulSave()
        {
            lab_PermissionID.Text = Convert.ToString(_permissionID);

            if (!clsCurrentUser.HasPermission(enPermissions.UpdatePermissions))
                return;

            _addUpdateMode = enAddUpdateMode.UpdateInfo;
            _UpdateModeStatusLabel();
        }

        private bool _UpdatePermissions(clsPermission permission)
        {
            if (!_HasPermission(enPermissions.UpdatePermissions))
                return false;

            clsOperationResult result = clsPermissionBL.UpdatePermission(permission);

            switch (result.Status)
            {
                case enOperationStatus.Success:
                    AddUpdatePermission?.Invoke(this, true);
                    MessageBox.Show(result.Message, "Operation Successded", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private bool _Save()
        {
            switch (_addUpdateMode)
            {
                case enAddUpdateMode.AddNewInfo:
                    bool isAdded = _AddNewPermission(_BuildPermission());
                    if (isAdded) _HandleSuccessfulSave();
                    return isAdded;

                case enAddUpdateMode.UpdateInfo:
                    return _UpdatePermissions(_BuildPermission());

                default:
                    return false; 
            }
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            _Save();
        }



        // >>
        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
