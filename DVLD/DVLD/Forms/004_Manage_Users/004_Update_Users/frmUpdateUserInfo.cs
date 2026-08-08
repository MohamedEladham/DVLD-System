using System;
using System.Windows.Forms;

namespace DVLD_System_Solution.Forms._004_Manage_Users
{
    public partial class frmUpdateUserInfo : Form
    {
        private int _personID = -1;
        private int _userID = -1;

        public frmUpdateUserInfo(int personID, int userID)
        {
            InitializeComponent();

            _personID = personID;
            _userID   = userID;
        }

        private void _LoadPersonAndUserInfo()
        {
            uconShowPersonAndUserInfo1.LoadPersonAndUserInfo(_personID, _userID);
        }

        private void _GetIsUpdateLoginInfo(object sender, bool status)
        {
            _isUpdateLoginInfo = status;
        }

        private void frmUpdateUserInfo_Load(object sender, EventArgs e)
        {
            _LoadPersonAndUserInfo();
            frmUpdateLoginInfo.UpdateLoginInfo += _GetIsUpdateLoginInfo;
        }

        private bool _isUpdateLoginInfo = false;

        private void btn_UpdateLoginInfo_Click(object sender, EventArgs e)
        {
            frmUpdateLoginInfo frm = new frmUpdateLoginInfo(_userID);
            frm.ShowDialog();

            if (_isUpdateLoginInfo)
            {
                _LoadPersonAndUserInfo();
                _isUpdateLoginInfo = false;
            }
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
