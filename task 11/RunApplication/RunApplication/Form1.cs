using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RunApplication
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            switch (userControl11.color)
            {
                case "brown":{
                    textBox1.ForeColor = Color.Brown;
                    break;
                }
                case "Black":
                    {

                        textBox1.ForeColor = Color.Black;
                        break;
                    }
                case "blue":
                    {

                        textBox1.ForeColor = Color.Blue;
                        break;
                    }
                default :
                    {
                        textBox1.Text = "choose color";
                        break;
                    }
            }
        }
    }
}
