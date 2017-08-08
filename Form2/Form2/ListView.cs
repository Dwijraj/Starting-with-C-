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
    public partial class ListView : Form
    {
        public ListView()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ListViewItem lsi = new ListViewItem(textBox2.Text); //Creating a ListViewItem with First Row Data
            lsi.SubItems.Add(textBox1.Text);                    //Adding SubsequentColumns data of particular row
            lsi.SubItems.Add(textBox3.Text);                    //Adding column data 
            listView1.Items.Add(lsi);
            textBox2.Text = "";
            textBox3.Text = "";
            textBox1.Text = "";
        }

        private void getNameOfItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //To make sure we have actually selected items
            if (listView1.SelectedItems.Count != 0)
            {
                    //  for(int i=0;i<listView1.SelectedItems.Count;i++)  
                    //    MessageBox.Show(listView1.SelectedItems[i].SubItems[0].Text); 
                    //          OR
                      foreach (ListViewItem lvi in listView1.SelectedItems)
                          MessageBox.Show(lvi.SubItems[0].Text);
            }
        }

        private void removeSelectedItemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count != 0)
            {
                     
                //Removes selected Items
                foreach (ListViewItem lvi in listView1.SelectedItems)
                    lvi.Remove();
            }
        }

        private void removeAllItemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();        //Clears all items
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Removes Checked Items
            foreach (ListViewItem lvi in listView1.Items)
                if (lvi.Checked)
                    lvi.Remove();
        }
    }
}
