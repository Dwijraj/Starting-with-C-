using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;         //For Sound Player

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
            Clipboard.SetImage(pictureBox1.Image);//Sets Image to Clipboard
            Clipboard.Clear();                  //Clears Clipboard
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
           // cd.AllowFullOpen = false;           //Disallows User to select Custom Color
            cd.FullOpen = true;                 //Shows CustomColor Picker Default
            cd.ShowHelp = true;                 //Show Help Button
            cd.HelpRequest += new EventHandler(cd_HelpRequest); // Event when someone clicks help button
            if (cd.ShowDialog() == DialogResult.OK)
            {
                button3.BackColor = cd.Color;   //Gets the selected Color cd.Color
            }
        }

        void cd_HelpRequest(object sender, EventArgs e)
        {
            //Called when we click the help button
            MessageBox.Show("Choose color for the backgroun of your button");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
            {
                Color c = cd.Color;
                if (c.IsNamedColor)                              //Returns if color has name 
                    MessageBox.Show(c.Name);                     //Shows name of the color if it has name won't show for custom color    
                if (c.IsKnownColor)                              //Known COlors are colors which are used for Windows Property like scrollbar or button
                    MessageBox.Show(c.ToKnownColor().ToString());// Gets the KnownColor

               // KnownColor.ActiveBorder;                       // KnowColor enumeration contains all the colors that are known
               // Color                                          // Color. Gives the name of all the colors that are known i.e KnownColors   
               // Color.FromKnownColor(KnownColor.)             // KnowColor enumeration contains all the colors that are known

               // Color CO ;
               //CO.ToArgb().ToString("X")                     //Converts a color to 32bit
               //Color.FromArgb(123);                          //Convert from int to Color 

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FontDialog fd = new FontDialog();
            fd.MaxSize = 23;        //Sets the Max size User can select
            fd.MinSize = 10;        //Sets Min Size in User can select
            fd.ShowColor = true;    //Allows to Select Color too
            fd.ShowHelp = true;     //Shows a Help Button
            fd.HelpRequest += new EventHandler(fd_HelpRequest); //Event When Help button click
            if (fd.ShowDialog() == DialogResult.OK)
            {
                textBox1.Font = fd.Font;
                textBox1.ForeColor = fd.Color;
            }
        }

        void fd_HelpRequest(object sender, EventArgs e)
        {
            MessageBox.Show("Choose a Font for the text Box");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            timer1.Start(); //Timer starts ticking regularly after interval(1s) till it is not stop
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();  //This code will stop the timer after it ticks once 
            //Timer tick event
            MessageBox.Show("Hello");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                SoundPlayer sp = new SoundPlayer(ofd.FileName);
               // sp.SoundLocation = ofd.FileName;
               // sp.PlaySync();        //When Played Can't move Application
               // sp.PlayLooping();     //Play in Loop
               // sp.Play();            //Use to Play only wav files not any other


                SystemSounds.Asterisk.Play();   //Plays System Asterisk sound
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            //Create an Instance to The next form 
            Form3 f3 = new Form3(textBox2.Text);
            f3.Show();  //Show the Form we can move between two forms
           // f3.ShowDialog();    //If ShowDialog is used we cannot move between two forms 
        }

        private void button10_Click(object sender, EventArgs e)
        {
            //Creating MDI (Multi Document Interface)
            this.IsMdiContainer = true; //This allows forms to be inside this form now Making an MDI which means this form can now hold forms and those forms can only be moved inside the container
            Form3 f3 = new Form3();     //Create Instance to the form which we want inside the container
            f3.MdiParent = this;        //This makes sure that f3 now resides inside form 1
            f3.Show();                  //Now using ShowDialog for obvious reasons :P
        }

        private void button11_Click(object sender, EventArgs e)
        {
            //Arranging the Forms in the MDI
            this.LayoutMdi(MdiLayout.ArrangeIcons); //This Line only arranges the forms when they are minimized
            this.LayoutMdi(MdiLayout.Cascade);      //Just Makes the Form Bigger 

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            MessageBox.Show("Test");
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Dwijraj")
            {
                comboBox1.Items[0] = "DWIJRAJ"; //Editing the contents of the comboList
                comboBox1.Items.Add("DINKUS");  //Adding items to the comboBox
                int ItemsTotal= comboBox1.Items.Count;          //Return number of items
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            ListView ls = new ListView();
            ls.Show();
        }
    }
}
