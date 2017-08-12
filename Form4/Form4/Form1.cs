using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace Form4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void myControl1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Closes the Application or else Splash Screen will be running even though invisible
            Application.Exit(); 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Thread t = new Thread(Capture);
            t.Start();
        }
        void Capture()
        {
            for (; ; )
            {
                //Screen class to get Screen properties, Primary screen is the screen with taskbar ,Working area is everything
                //which is on the screen
                Bitmap bitmap = new Bitmap(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);
                Graphics g = Graphics.FromImage(bitmap);
                g.CopyFromScreen(Point.Empty, Point.Empty, Screen.PrimaryScreen.WorkingArea.Size);

                pictureBox1.Image = bitmap;
            }
        }
    }
}
