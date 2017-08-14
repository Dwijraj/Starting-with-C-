using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;

namespace AddressBook
{
    public partial class AddressBook : Form
    {
        List<Person> contacts=new List<Person>();
        string path;
        public AddressBook()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            if (!(Directory.Exists(path + "\\Address Book")))
                Directory.CreateDirectory(path + "\\Address Book");
            if (!(File.Exists(path + "\\Address Book" + "\\settings.xml")))
            {

                XmlTextWriter xw = new XmlTextWriter(path + "\\Address Book" + "\\settings.xml", Encoding.UTF8);
                xw.WriteStartElement("People");
                xw.WriteEndElement();
                xw.Close();

            }
            XmlDocument xdooc = new XmlDocument();
            xdooc.Load(path + "\\Address Book" + "\\settings.xml");

            foreach (XmlNode xnode in xdooc.SelectNodes("People/Person"))
            {
                /*XmlNode xEmail = xdooc.CreateElement("Email");
                XmlNode xBirthday = xdooc.CreateElement("Birthday");
                XmlNode xAditionalNotes = xdooc.CreateElement("AditionalNotes");
                XmlNode xStreet = xdooc.CreateElement("Name"); */

                Person p = new Person();
                p.Name = xnode.SelectSingleNode("Name").InnerText;
                p.Email = xnode.SelectSingleNode("Email").InnerText;
                p.Birthday = DateTime.FromFileTime(Convert.ToInt64(xnode.SelectSingleNode("Birthday").InnerText));
                p.AdditionalNotes = xnode.SelectSingleNode("AditionalNotes").InnerText;
                p.StreetAddress = xnode.SelectSingleNode("Address").InnerText;

                contacts.Add(p);
                listView1.Items.Add(p.Name);
            }
           
            
        }
        void Remove()
        {
            try
            {
                listView1.Items.Remove(listView1.SelectedItems[0]);
                contacts.RemoveAt(listView1.SelectedItems[0].Index);
            }
            catch { 
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Person p = new Person();
            p.Name = FullName.Text;
            p.Email = Email.Text;
            p.StreetAddress = Street.Text;
            p.AdditionalNotes = additionalnotes.Text;
            p.Birthday = Birthday.Value;
            contacts.Add(p);

            listView1.Items.Add(p.Name);
            FullName.Text="";
            Email.Text="";
            Street.Text="";
            additionalnotes.Text="";
            Birthday.Value=DateTime.Now;
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Person p =contacts[listView1.SelectedItems[0].Index];
            FullName.Text = p.Name;
            Email.Text = p.Email;
            Street.Text = p.StreetAddress;
            additionalnotes.Text = p.AdditionalNotes;
            Birthday.Value = p.Birthday;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Remove();
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Remove();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Person p = contacts[listView1.SelectedItems[0].Index];
            p.Name = FullName.Text;
            p.Email = Email.Text;
            p.StreetAddress = Street.Text;
            p.AdditionalNotes = additionalnotes.Text;
            p.Birthday = Birthday.Value;
            
        
        }

        private void listView1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            try
            {
                Person p = contacts[listView1.SelectedItems[0].Index];
                FullName.Text = p.Name;
                Email.Text = p.Email;
                Street.Text = p.StreetAddress;
                additionalnotes.Text = p.AdditionalNotes;
                Birthday.Value = p.Birthday;
            }
            catch { }
        }

        private void AddressBook_FormClosed(object sender, FormClosedEventArgs e)
        {
            XmlDocument xdooc = new XmlDocument();
            xdooc.Load(path + "\\Address Book" + "\\settings.xml");

            XmlNode xnode = xdooc.SelectSingleNode("People");
            xnode.RemoveAll();
            foreach (Person p in contacts)
            {
                XmlNode xtop = xdooc.CreateElement("Person");
                XmlNode xName = xdooc.CreateElement("Name");
                XmlNode xEmail = xdooc.CreateElement("Email");
                XmlNode xBirthday = xdooc.CreateElement("Birthday");
                XmlNode xAditionalNotes = xdooc.CreateElement("AditionalNotes");
                XmlNode xStreet = xdooc.CreateElement("Address");

                xName.InnerText = p.Name;
                xEmail.InnerText = p.Email;
                xBirthday.InnerText = p.Birthday.ToFileTime().ToString();
                xAditionalNotes.InnerText = p.AdditionalNotes;
                xStreet.InnerText = p.StreetAddress;

                xtop.AppendChild(xName);
                xtop.AppendChild(xEmail);
                xtop.AppendChild(xBirthday);
                xtop.AppendChild(xAditionalNotes);
                xtop.AppendChild(xStreet);

                xdooc.DocumentElement.AppendChild(xtop);
            }
            xdooc.Save(path + "\\Address Book" + "\\settings.xml");
        }

        private void Email_TextChanged(object sender, EventArgs e)
        {

        }

    }
    class Person
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string StreetAddress { get; set; }
        public string AdditionalNotes { get; set; }
        public DateTime Birthday { get; set; }

    }

}
