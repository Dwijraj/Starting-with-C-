using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DWIJRAJ.Event;
using DWIJRAJ.CustomDelegateEvent;
using MySpace;
using System.IO;

namespace DWIJRAJ
{
    public partial class Form1 : Form
    {
        string path;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

           /* MySpace.Class1 m = new MySpace.Class2(1,2);
            MySpace.Class2 m2 =(MySpace.Class2) m;
            MessageBox.Show(m2.a.ToString()+"<-->"+m.b.ToString()); */

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Here is the Title";
           // ofd.Filter = "Png IMAGE|*.png|JPG Image|*.jpg";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show(ofd.FileName);
            }

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }
        public static string R()
        {
          
            return "hi";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Class3 c = new Class3();
            c.OnPropertyChange += new EventHandler(c_OnPropertyChange);
        }

        void c_OnPropertyChange(object sender, EventArgs e)
        {
            MessageBox.Show("PropertyChanged");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Class3 cd = new Class3();
            cd.OnPropertyChange += new EventHandler(cd_OnPropertyChange);

        }

        void cd_OnPropertyChange(object sender, EventArgs e)
        {
            OpenFileDialog odf = new OpenFileDialog();
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Class4 c = new Class4();
            c.OnPropertyChanged += new Class4.MyDelegate(c_OnPropertyChanged);
            c.Propert = "Calling Property Change";
        }

        void c_OnPropertyChanged(string message)
        {
            MessageBox.Show("Dwijraj");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //IO Operations with file reading text

            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                path = ofd.FileName;
                button6.Enabled = true;

                StreamReader sr = new StreamReader(File.OpenRead(ofd.FileName));
               // textBox1.Text = sr.ReadToEnd();              //Reads text

                //For reading a single Byte
                sr.BaseStream.ReadByte().ToString("X");// Here X is needed else it reads decimal value instead of Hexadecimal

              //  sr.BaseStream.Position = 4;// Setting the Offset 
                 // sr.BaseStream.Position=0x0C  //Setting HexaDecimalOffset start with 0x
                //For reading Multiple Byte
                byte[] byteArr=new byte[3];
                sr.BaseStream.Read(byteArr, 0, 3);
                foreach (byte b in byteArr)
                {
                    textBox1.Text += b.ToString("X");
                }


                sr.Dispose(); //if not closed then it gives error saying File used by other process
            } 

        }

        private void button6_Click(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter(File.OpenWrite(path)); //This mode overwrites 
           
            //For writing texts
                // StreamWriter sw = new StreamWriter(File.Create(path)); //This method totally creates a new file deleting previous
                // sw.Write(textBox1.Text+"Whazzzupp "); 
            //For writing bytes
                 //For setting offset       
                    // sw.BaseStream.Position = 0x04;
                //For writing at a single position
                    //sw.BaseStream.WriteByte(0x0C);
                //For writing multiple bytes
                    byte[] buffer ={0x8,0x9,0xA};
                    sw.BaseStream.Write(buffer, 0, 3);
                    
            sw.Dispose();
        }
    }
}
