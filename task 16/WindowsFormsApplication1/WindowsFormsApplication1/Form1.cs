using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (userControl11.dataFromDatabase != null && userControl11.dataFromDatabase != "")
            {
                XmlParser parser = new XmlParser(userControl11.dataFromDatabase);

                richTextBox1.Text = parser.parse();
            }
            else
            {
                MessageBox.Show("database is not read");
            }
        }
    }
}
