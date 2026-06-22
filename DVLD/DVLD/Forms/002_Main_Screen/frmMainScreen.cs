using Main_Screen.Froms.Persons_Screen;
using System;
using System.Windows.Forms;

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
    }
}
