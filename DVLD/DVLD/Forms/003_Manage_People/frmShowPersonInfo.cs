using System;
using System.Windows.Forms;

namespace DVLD_System_Solution.Forms._003_Manage_People
{
    public partial class frmShowPersonInfo : Form
    {
        private int _personID = -1;
        
        public frmShowPersonInfo(int personID)
        {
            InitializeComponent();
            _personID = personID;
        }
        
        private void frmShowPersonInfo_Load(object sender, EventArgs e)
        {
            uconShowPersonInfo1.LoadPersonByID(_personID);
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
