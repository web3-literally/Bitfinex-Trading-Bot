using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CDSBot
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
            Helper.Log("CDS bot is starting...");
            MainController mainController = new MainController();
            MainUI mainUI = new MainUI();
            Application.Run(mainUI);
        }
    }
}
