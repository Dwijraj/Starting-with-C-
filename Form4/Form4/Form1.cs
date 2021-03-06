﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Collections;
using System.IO;
using Ionic.Zip;

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

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            //Making KeyBoard Shortcuts
            //Fired when focus on form
            if (e.Control && e.KeyCode.ToString().Equals("A"))
            {
                MessageBox.Show("Dwijraj");
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            //Making KeyBoard Shortcuts
            //Fired when focus on textBox
            if (e.Control && e.KeyCode.ToString().Equals("A"))
            {
                MessageBox.Show("SPred");
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            //Fired when User leaves this control for another
            if (textBox2.Text == "")
            {
                MessageBox.Show("Select name");
                textBox2.Select();  //Puts cursor to the textBox
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Item i2 = new Item();
            i2.item = 2121;
            Item i3 = new Item();
            i3.item = 2021;

            Item i4 = i2 + i3; //Calling Overloaded Operator

            Item i5 = (Item)5;  //Calling explicit conversion
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
        }
        //Yield return doesn't complete the function completely
        //it goes through on itertion than send it's result then
        //again calls the function with different values
        //IEumerable is iterface
        IEnumerable GetNumbers(int min, int max)
        {
            while (min <= max)
            {
                min++;
                yield return min;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            FileSystemWatcher fs = new FileSystemWatcher();
            fs.Path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            fs.NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.FileName;
            fs.Filter = "*.txt";
            fs.Changed += new FileSystemEventHandler(fs_Changed);
            fs.Renamed += new RenamedEventHandler(fs_Renamed);
            fs.EnableRaisingEvents = true;
        }

        void fs_Renamed(object sender, RenamedEventArgs e)
        {
            MessageBox.Show("You renamed a file");
        }

        void fs_Changed(object sender, FileSystemEventArgs e)
        {
            MessageBox.Show("You saved a file");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofs = new OpenFileDialog();
            if (ofs.ShowDialog() == DialogResult.OK)
            {
                ZipFile zp = new ZipFile(Environment.GetFolderPath(Environment.SpecialFolder.Desktop)+"\\MyFiles.zip");
                zp.AddDirectory("Maina");  //Maina is a directory and should be created 
                zp.AddFile(ofs.FileName,"Maina");   //this line shows that file should be inside Maina Directory
                zp.Save();
            }
        }
    }
    class Item
    {
        public int item
        {
            get {
                return item; 
            }
            set 
            {
                this.item = value;
            }
        }
        /*
         * Overloaded Operators must be public static <returnType> operator<use the operator>(arguements)
         * */
        /// <summary>
        /// Overloaded + operator
        /// </summary>
        /// <param name="I1">First Item</param>
        /// <param name="I2">Secon Item</param>
        /// <returns>return Item Object</returns>
        public static Item operator+(Item I1,Item I2)
        {
            Item ret = new Item();
            ret.item = I1.item + I2.item;
            return ret;
        }
        //On Overloading == we must always overload != also and vice versa
        public static bool operator ==(Item i1, Item i2)
        {
            if (i1.item == i2.item)
                return true;
            return false;
        }
        public static bool operator !=(Item i1, Item i2)
        {
            if (i1.item != i2.item)
                return true;
            return false;
        }

        //Conversions
        //We cannot have both explicti and implicit conversion in same class
        //For implicit just change explicit in following function to implicit
        public static explicit operator Item(int a)
        {
            Item ad = new Item();
            ad.item = a;
            return ad;
        }
        //Works like call by reference
        //if we use ref and call func with a variable with unassigned value we get error
        // if we use out and func with a variable with unassigned value we don't get error but inside method we should assign it some value
        void changeRef(ref int a)
        {
            a++;
        }
        void FunctionWithOptionalParam(int a, int b = 10)
        {
            //Here b is optional and it's default value is 10 
            //Optional parameter should always be the last param
            //Nothing to do;
        }
    }
}