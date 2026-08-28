using System;
using DVLD_Models.User;
using System.Windows.Forms;
using DVLD_Shared.Global_Classes;
using Main_Screen.Froms.Persons_Screen;
using DVLD_System_Solution.Forms._004_Manage_Users;

namespace Main_Screen
{
    public partial class frmMainScreen : Form
    {
        public frmMainScreen()
        {
            InitializeComponent();
        }

        private void toolStripMenuItem_Persons_Click(object sender, EventArgs e)
        {
            frmManagePersons frm = new frmManagePersons();
            frm.ShowDialog();
        }

        private void toolStripMenuItem_ManageUsers_Click(object sender, EventArgs e)
        {
            frmManageUsers frm = new frmManageUsers();
            frm.ShowDialog();
        }

        private void frmMainScreen_Load(object sender, EventArgs e)
        {
            toolStripMenuItem_ManageUsers.Enabled = clsCurrentUser.HasPermission(enPermissions.ManageUsers);
            toolStripMenuItem_ManagePersons.Enabled = clsCurrentUser.HasPermission(enPermissions.ManagePersons);


            string permissions = "";

            foreach (var s in clsCurrentUser.Permissions)
                permissions += s + " ";

            lab_Permissions.Text = permissions;
        }
    }
}
