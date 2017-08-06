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
using System.Threading; //To use Threading class
using MySpace;
using System.IO; //For StreamReader StreamWriter Path Directory and other various classes
using System.Diagnostics; //For Process Class
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

        private void button7_Click(object sender, EventArgs e)
        {
            string path;
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                path = ofd.FileName;
                //Reading single character from file

                BinaryReader br = new BinaryReader(File.OpenRead(path));
                //br.BaseStream.Position = 0xA;
                //textBox1.Text = br.ReadChar().ToString();
                byte[] a= br.ReadBytes(4);
                Array.Reverse(a);

                textBox1.Text=BitConverter.ToInt32(a, 0).ToString();
                
                br.Dispose();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "TextFile|*.txt";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                string path = sfd.FileName;

                BinaryWriter bw = new BinaryWriter(File.Create(path));
                bw.Write("File Created through C#");
                bw.Dispose();
            }

        }

        private void button9_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                Directory.CreateDirectory(fbd.SelectedPath + "\\Dwijraj'sC#folder");//Creates a directory in specified path
                Directory.Move(fbd.SelectedPath + "\\Dwijraj'sC#folder", fbd.SelectedPath + "\\Dinku");//Moves the file or Directory specified
                Directory.Delete(fbd.SelectedPath);//Deleets the file/folder in the path
                string rootfolder = Environment.SpecialFolder.MyDocuments.ToString();
                MessageBox.Show(rootfolder);
                //fbd.SelectedPath givees the path of the selected Directory
                string[] files= Directory.GetFiles(fbd.SelectedPath);//Gets Files
                string[] directories = Directory.GetDirectories(fbd.SelectedPath); //Gets Directories
                string[] drives = Directory.GetLogicalDrives(); //Gets the drives
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string path = ofd.FileName;
                
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
              
                Path.GetDirectoryName(ofd.FileName); //Gets directory on which file is present
                Path.GetExtension(ofd.FileName);    //Gets extension of the selected file name
                Path.GetFileName(ofd.FileName);     //Gets File name of selected file with extension
                Path.GetFileNameWithoutExtension(ofd.FileName); //Gets filename without the extension
                Path.GetExtension(ofd.FileName);   //Gets the bool value weather or not the file has extension

            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
           // Process.Start("notepad.exe"); //For some programs no need to mention path mostly which are located in System32 folder
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
               // Process.Start(ofd.FileName);//Starts a process like startinf FIFA :D 
                MessageBox.Show(Process.GetCurrentProcess().ProcessName); //Gets current process for example this line would return DWIJRAJ the namespace 
                Process.GetCurrentProcess().Kill(); //Kills the process
                Process.GetProcesses(); //Gets list of processes
                Process.GetProcessesByName("Chrome");//Gets all processes with name chrome
                /*
                 * Null coalesence operator
                 */
                string randomstring = "";
                MessageBox.Show(randomstring ?? "Hello");  //The ?? is Null coalesence operator
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            short a = ~3;  //Flips all the 16 bits of a
            short b = 3 & 5;//Bitwise & operator
            short c = 3 | 4;//Bitwise OR operator 
            short xor = 6 ^ 7;//Bitwise XOR
            short RightShift = 3 >> 1; //Right Shift shifts the bits
            short LeftShift = 3 << 1; //Left Shift shifts the bits to left
            Convert.ToString(a,2); //Shows the Binary representation of a here 2 means Binary
        }
        Thread t;
        string my;
        private void button14_Click(object sender, EventArgs e)
        {
          //  t = new Thread(Freeze); //Instantiating a Thread object and attaching a function to run on thread
          //  t.Start();              //Starting a Thread

            t = new Thread(WriteMethod);
            t.Start();
            while (t.IsAlive)   // Otherwise it simply prints null no events in thread
            {
                textBox2.Text = my;
           
                textBox2.Update();
            }
            
        }
        void WriteMethod()
        {
            for (int i = 0; i < 1000; i++)
            {
                Thread.Sleep(5);
                my += "Dwijraj" + i.ToString() + "\r\n";
            }
        }
        /**Simple Method to Freeze our application */
        void Freeze()
        {
            while (true)
            {
               
            }
        }
        //This method is required as when if we have a thread running and we close our 
        //form then the process is not actually killed because the thread 
        // is actually running 
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            t.Abort();  //Now the entire process is completly killed
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
