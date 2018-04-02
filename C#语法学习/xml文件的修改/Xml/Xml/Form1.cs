using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Xml
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SaveXmlFile setxml = new SaveXmlFile(@Application.StartupPath + @"\set.xml");;
                setxml = new SaveXmlFile(Application.StartupPath + "\\set.xml");
                setxml.SaveXmlNode("InPut", "PrintName", textBox1.Text);
                setxml.SaveChanges();
            }
            catch(Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                SaveXmlFile setxml = new SaveXmlFile(Application.StartupPath + "\\set.xml");
                string str = setxml.ReadXmlNodeValue("InPut", "PrintName");
                textBox2.Text = str;
            }catch(Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
