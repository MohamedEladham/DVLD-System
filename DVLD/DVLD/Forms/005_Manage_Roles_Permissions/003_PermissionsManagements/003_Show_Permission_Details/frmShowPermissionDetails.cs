using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_System_Solution.Forms._005_Manage_Roles_Permissions._003_PermissionsManagements
{
    public partial class frmShowPermissionDetails : Form
    {
        private int _permissionID = -1;

        public frmShowPermissionDetails(int permissionID)
        {
            InitializeComponent();
            _permissionID = permissionID;
        }

        private void frmShowPermissionDetails_Load(object sender, EventArgs e)
        {
            uconShowPermissionDetails1.LoadPermissionInfoByPermissionID(_permissionID);
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
