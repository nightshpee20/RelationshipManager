using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace rmanager
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new mainForm());
            Application.Run(new userProfileForm2(1));
            //Application.Run(new acquaintancesForm(1));
            //Application.Run(new addAcquaintanceForm(1));
            //Application.Run(new editForm("occupations", 1));
        }
    }
}
