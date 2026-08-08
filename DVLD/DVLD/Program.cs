using DVLD_System_Solution.Forms;
using DVLD_System_Solution.Forms._004_Manage_Users;
using Main_Screen;
using Main_Screen.Forms._004_Users.Controls;
using Main_Screen.Forms.Persons;
using Main_Screen.Froms.Persons_Screen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DVLD_Shared.Global_Enums.clsEnumHelpers;

namespace DVLD_System_Solution
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMainScreen());
        }
    }
}
