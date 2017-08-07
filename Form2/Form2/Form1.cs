using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Form2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime dt = dateTimePicker1.Value;
           // MessageBox.Show(dt.ToString());


            DateTime date = DateTime.Today;  //Gives date 
            DateTime dNt = DateTime.Now;  //Gives date as well as current time
            bool isLeap = DateTime.IsLeapYear(2011); //Self Explanatory
            DateTime d = new DateTime(1995,10,16);
            DateTime.DaysInMonth(2012, 2);
            DateTime.Now.ToFileTime().ToString("X"); // If we need to store in File


            OpenFileDialog ofd = new OpenFileDialog();
           // ofd.Filter = "PNG Image|*.png";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
               /* Image img = Image.FromFile(ofd.FileName); //Converting Location to Image
                pictureBox1.Image = img;*/                  //Setting the Image in the PictureBox

                pictureBox1.ImageLocation = "https://www.w3schools.com/css/img_fjords.jpg"; //As long as the link contains only Image it's ok
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Clipboard.GetText();               //Gets text on clipboard 
            Clipboard.GetImage();              //Gets the Image which is copied on the clipboard
            Clipboard.GetData(DataFormats.Rtf);//Gets data of desired format from clipboard
            Clipboard.SetText("Hello");        //Sets a text in the Clipboard
        }
    }
}
