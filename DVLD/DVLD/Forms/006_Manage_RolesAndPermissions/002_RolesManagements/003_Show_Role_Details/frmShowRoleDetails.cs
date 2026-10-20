using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_System_Solution.Forms._005_Manage_Roles_Permissions._001_RolesManagements
{
    public partial class frmShowRoleDetails : Form
    {
        private int _roleID = -1;

        public frmShowRoleDetails(int roleID)
        {
            InitializeComponent();
            _roleID = roleID; 
        }

        private void frmShowRoleDetails_Load(object sender, EventArgs e)
        {
            uconShowRoleDetails1.LoadRoleInfoByRoleID(_roleID);
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
