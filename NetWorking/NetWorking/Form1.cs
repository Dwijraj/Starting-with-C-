using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;   // NetWorking Library

namespace NetWorking
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            WebClient wb = new WebClient(); //Instantiating we client
            textBox1.Text = wb.DownloadString("https://firebasestorage.googleapis.com/v0/b/buyup-4891b.appspot.com/o/API%20KEYS.txt?alt=media&token=0c3c4ded-5b35-4305-9fdd-854e3598fc03"); //Downloading HTML text and displaying in textbox
            
           

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        //Downloading File using WebClient
        private void DOWNLOAD_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                WebClient wc = new WebClient();

                //Downloads the File Async(In different Thread so that we needn't write Threading ourselfs and saves UI from freezing)"
                wc.DownloadFileAsync(new Uri("https://firebasestorage.googleapis.com/v0/b/buyup-4891b.appspot.com/o/Aqua%20Power%2B_20150927_004929.jpg?alt=media&token=8df32e46-e551-4a3a-936d-05f4ad8d1c12"), sfd.FileName);

                //An event that is Triggered when Downloading is Completed
                wc.DownloadFileCompleted += new AsyncCompletedEventHandler(wc_DownloadFileCompleted);
                //An event which is fired everytime the Progress of Downloading changes can be used to update Progress Bar
                wc.DownloadProgressChanged += new DownloadProgressChangedEventHandler(wc_DownloadProgressChanged);

            }
        }

        void wc_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            //Called when change in Progress
            label1.Text = "Progress " + e.ProgressPercentage;
           
        }

        void wc_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            //Shows when Downloading is Complete
            MessageBox.Show("Downloading complete");
        }
    }
}
