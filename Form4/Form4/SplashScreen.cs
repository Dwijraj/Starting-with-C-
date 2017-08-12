using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Form4
{
    public partial class SplashScreen : Form
    {
        public SplashScreen()
        {
            InitializeComponent();
        }
        /// <summary>
        /// This is how you give description of a function
        /// </summary>
        Timer t;
        private void SplashScreen_Shown(object sender, EventArgs e)
        {
            t = new Timer();
            t.Interval = 2000;
            t.Tick += new EventHandler(t_Tick);
        }

        void t_Tick(object sender, EventArgs e)
        {
            t.Stop();
            Form1 ft = new Form1();
            ft.Show();
            this.Hide();
        }
    }
}
