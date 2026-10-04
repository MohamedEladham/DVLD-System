using System;
using DVLD_Models.User;
using System.Windows.Forms;
using DVLD_Shared.Global_Classes;
using Main_Screen.Froms.Persons_Screen;
using DVLD_System_Solution.Forms._004_Manage_Users;
using DVLD_System_Solution.Forms._005_Manage_Roles._001_ShowRoles;
using DVLD_System_Solution.Forms._005_Manage_Roles._002_AddRoles;
using System.Linq;
using DVLD_Shared.Validation_Messages;
using DVLD_Shared;
using DVLD_System_Solution.Forms._005_Manage_Roles_Permissions._003_PermissionsManagements._001_Manage_Permissions;

namespace Main_Screen
{
    public partial class frmMainScreen : Form
    {
        public frmMainScreen()
        {
            InitializeComponent();
        }

        private bool _HasPermission(enPermissions permissions)
        {
            if (!clsCurrentUser.HasPermission(permissions))
            {
                MessageBox.Show(clsUserValidationMessages.PermissionDeniedMessage, "Permission Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }


        // >>
        private void frmMainScreen_Load(object sender, EventArgs e)
        {
            //toolStripMenuItem_Applicatios.Enabled = false;
            //toolStripMenuItem_ManagePersons.Enabled = false;
            //toolStripMenuItem_ManageUsers.Enabled = false;
            //toolStripMenuItem_Drivers.Enabled = false;
            //toolStripMenuItem_AccountSetting.Enabled = false;


            //toolStripMenuItem_ManageApplicatios.Enabled = clsCurrentUser.HasPermission(enPermissions.ManageApplications);
            //toolStripMenuItem_ManagePersons.Enabled = clsCurrentUser.HasPermission(enPermissions.ManagePersons);
            //toolStripMenuItem_ManageDrivers.Enabled = clsCurrentUser.HasPermission(enPermissions.ManageDrivers);
            //toolStripMenuItem_ManageUsers.Enabled = clsCurrentUser.HasPermission(enPermissions.ManageUsers);
            //toolStripMenuItem_RolesManagements.Enabled = clsCurrentUser.HasPermission(enPermissions.ManageRoles);
            //toolStripMenuItem_ManageAccountSetting.Enabled = clsCurrentUser.HasPermission(enPermissions.ManageAccountSitting);


            // >>
            lab_UserName.Text = clsCurrentUser.UserName;

            lab_PermissionsToText.Text = string.Join(", ", clsCurrentUser.UserPermissions.Select(p => p.PermissionName));
        }


        // >>
        private void toolStripMenuItem_Persons_Click(object sender, EventArgs e)
        {
            if (!_HasPermission(enPermissions.ManagePersons))
                return;

            frmManagePersons frm = new frmManagePersons();
            frm.ShowDialog();
        }

        private void toolStripMenuItem_ManageUsers_Click(object sender, EventArgs e)
        {
            if (!_HasPermission(enPermissions.ManageUsers))
                return;

            frmManageUsers frm = new frmManageUsers();
            frm.ShowDialog();
        }

        private void toolStripMenuItem_RolesManagements_Click(object sender, EventArgs e)
        {
            if (!_HasPermission(enPermissions.ManageRoles))
                return;

            frmRolesManagements frm = new frmRolesManagements();
            frm.ShowDialog();
        }

        private void toolStripMenuItem_PermissionsManagements_Click(object sender, EventArgs e)
        {
            if (!_HasPermission(enPermissions.ManagePermissions))
                return;

            frmPermissionsManagement frm = new frmPermissionsManagement();
            frm.ShowDialog();
        }
    }
}
