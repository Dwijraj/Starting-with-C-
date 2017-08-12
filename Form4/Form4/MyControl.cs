using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Form4
{
    public partial class MyControl : UserControl
    {
        string Text = "";           //Since on Using Label We get background of the label also so we will draw a string
        public MyControl()
        {
            InitializeComponent();
        }
        //This method is required to change the looks of our control
        protected override void OnPaint(PaintEventArgs e)
        {

            Draw(Color.Red);
        }
        public string ChangeLabelText
        {
            // Property to change Control description
            get { 
                return Text;
            }
            set { 
                Text = value; 
            }
        }

        private void MyControl_MouseHover(object sender, EventArgs e)
        {
            Draw(Color.FromKnownColor(KnownColor.Violet));          
        }
        void Draw(Color cd)
        {
            //Create a solid brush onject
            SolidBrush s = new SolidBrush(cd);
            //Create a Graphics object
            Graphics g = this.CreateGraphics();
        //    Color c = Color.FromArgb(255, cd.R - 1, cd.B - 1);        //Substracting equal amounts goves ligther color
            //Filling the Control
            g.FillRectangle(s, 0, 0, this.Width, this.Height);
            //Or else the label will always be in a fixed position so we write below line to that label is always at center
            // label1.Location = new Point((this.Width / 2) - (label1.Width / 2), (this.Height / 2)-(label1.Height / 2));
            PointF fpoint = new Point((this.Width / 2) - (Text.Length), (this.Height / 2) - (4));
            FontFamily ff = new FontFamily("Arial");
            Font f = new Font(ff, 8);
            g.DrawString(Text, f, new SolidBrush(Color.Black), fpoint);
            //Customizing button looks
            g.FillRectangle(new SolidBrush(Color.FromKnownColor(KnownColor.ControlLight)), 0, 0, this.Width, this.Height / 2);
        
        }

        private void MyControl_MouseLeave(object sender, EventArgs e)
        {
            //Called when mouse leaves the top
            Draw(Color.Red);
        }
    }
}
