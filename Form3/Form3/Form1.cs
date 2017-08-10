using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;       //All XML classes are present Inside this Namespace

namespace Form3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "XML|*.xml";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                XmlDocument xdoc = new XmlDocument();//Creating Instance of XMLDocument
                xdoc.Load(ofd.FileName);            //Loading the Document

                MessageBox.Show(xdoc.SelectSingleNode("People/Person/Name").InnerText);
 
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "XML|*.xml";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                XmlDocument xdoc = new XmlDocument();//Creating Instance of XMLDocument
                xdoc.Load(ofd.FileName);            //Loading the Document

                //Writing in a XML file
                xdoc.SelectSingleNode("People/Person/Name").InnerText="HelloWorld";
                xdoc.Save(ofd.FileName);

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Writing on a existing XML file 

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "XML|*.xml";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                XmlDocument xdoc = new XmlDocument();//Creating Instance of XMLDocument
                xdoc.Load(ofd.FileName);            //Loading the Document

                //there should be atleast one Person nodes present
                XmlNode Person = xdoc.CreateElement("Person");
                XmlNode Name = xdoc.CreateElement("Name");  //Creating another Node Name
                Name.InnerText = "arnab";                   //Assigning name to Arnab in new Person Node
                Person.AppendChild(Name);                   //Appending the Name to Person
                xdoc.DocumentElement.AppendChild(Person);   //Adding the Person element to Document
                xdoc.Save(ofd.FileName);                    //Make sure the changes persists

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SaveFileDialog ofd = new SaveFileDialog();
            ofd.Filter = "XML|*.xml";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                XmlTextWriter xw = new XmlTextWriter(ofd.FileName,Encoding.UTF8);// Encoding should be in UTF-8
                xw.Formatting = Formatting.Indented;
                xw.WriteStartElement("People");//<People>
                xw.WriteStartElement("Person");//   <Person>
                xw.WriteStartElement("Name");  //         <Name>                                               
                                               //                 Maina (Inner Text)       
                xw.WriteString("Maina");      //          </Name>   
                xw.WriteEndElement();         //    </Person> 
                xw.WriteEndElement();         //</People>
                xw.WriteEndElement();        //
                xw.Close();                 // So that if we try to read it here we don't get an error
             
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "XML|*.xml";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                XmlDocument xdoc = new XmlDocument();//Creating Instance of XMLDocument
                xdoc.Load(ofd.FileName);            //Loading the Document
                foreach (XmlNode xnode in xdoc.SelectNodes("Person/People"))
                {
                    if (xnode.SelectSingleNode("Name").InnerText=="Dwirjaj")
                    {
                      //  xdoc.RemoveAll();       //Will remove name age and Email but not <Person> </Person> under which they are encapsulated
                        xdoc.ParentNode.RemoveChild(xnode); //Overcomes the previous line's problem
                    }

                }
                xdoc.Save(ofd.FileName);
            }
        }
    }
}
