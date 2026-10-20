using System;
using System.Windows.Forms;
using static DVLD_Shared.Global_Enums.clsEnumHelpers;

namespace DVLD_System_Solution.Forms._003_Manage_People
{
    public partial class frmShowPersonInfo : Form
    {
        private int _personID = -1;

        enPersonStatus _personStatus;
     
        public frmShowPersonInfo(int personID, enPersonStatus personStatus = enPersonStatus.Active)
        {
            InitializeComponent();
            _personID = personID;
            _personStatus = personStatus;
        }
        
        private void frmShowPersonInfo_Load(object sender, EventArgs e)
        {
            uconShowPersonInfo1.SetLinkLabelEditPerson(_personStatus);
            uconShowPersonInfo1.LoadPersonByID(_personID);
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
