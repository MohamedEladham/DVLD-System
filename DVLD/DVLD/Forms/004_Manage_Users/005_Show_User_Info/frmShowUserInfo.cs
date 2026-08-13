using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_System_Solution.Forms._004_Manage_Users._005_Show_User_Info
{
    public partial class frmShowUserInfo : Form
    {
        private int _userID = -1;
        private int _personID = -1;

        public frmShowUserInfo(int personID, int userID)
        {
            InitializeComponent();

            _userID = userID;
            _personID = personID;
        }

        private void frmShowUserInfo_Load(object sender, EventArgs e)
        {
            uconShowPersonAndUserInfo1.LoadPersonAndUserInfo(_personID, _userID);
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
