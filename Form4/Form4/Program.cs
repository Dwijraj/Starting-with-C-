using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Form4
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
            //TO implement Splash Screen
            Application.Run(new Form1());
        }
    }
}
