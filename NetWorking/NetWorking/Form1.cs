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

                //Changing progress Bar style to Marque Animation
                progressBar1.Style = ProgressBarStyle.Marquee;
            
            }
        }

        void wc_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            //Called when change in Progress
           // progressBar1.Value = e.ProgressPercentage;
            //Marqueue animation is used when we don't know when actually the task will end
            progressBar1.MarqueeAnimationSpeed = 10;
           
        }

        void wc_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            //Shows when Downloading is Complete
            MessageBox.Show("Downloading complete");
           // progressBar1.MarqueeAnimationSpeed = 0; //Only holds not a goot way to  stop
            progressBar1.Style = ProgressBarStyle.Blocks;

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Opens the webpage
            //webBrowser1.Navigate(textBox2.Text);
            //webBrowser1.Navigate("http://www.geeksforgeeks.org/");
            webBrowser1.Navigate("http://www.yahoo.com");
            webBrowser1.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(webBrowser1_DocumentCompleted);
        }

        void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
          //Event when document Load Completed
        }

        private void webBrowser1_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            //Event when WeBrowser Navigates to a Page
            textBox2.Text = webBrowser1.Url.ToString(); //Gives real URL of the navigated Page
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Goes to previous page
            webBrowser1.GoBack();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Refresh Page
            webBrowser1.Refresh();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Go forward
            webBrowser1.GoForward();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //Go Home
            webBrowser1.GoHome();   //Since WebBrowser is Made of IE it goes to default homepage of IExplorer
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //Setting the search by getting the ID of search bar and setting the text
            webBrowser1.Document.GetElementById("uh-search-box").InnerText = textBox2.Text;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //Getting the ID of the search Button and Invoking the member Click
            webBrowser1.Document.GetElementById("uh-search-button").InvokeMember("Click");
        }

    }
}
