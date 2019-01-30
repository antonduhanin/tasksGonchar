using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace temp
{
    public partial class UserControl1: UserControl
    {
        private int key;
        public UserControl1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                key = Int32.Parse(textBox1.Text);
                
            }
            catch
            {
                textBox1.Text = "";
                MessageBox.Show("key must be number in range from 1 to 5");
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
