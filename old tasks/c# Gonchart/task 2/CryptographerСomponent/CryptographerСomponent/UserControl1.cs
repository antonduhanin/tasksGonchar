using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace CryptographerСomponent
{
    public partial class UserControl1: UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            int  key = Decimal.ToInt32( numericUpDown1.Value);
            string text = richTextBox1.Text;
            string newText = "";
            if (!text.Equals(""))
            {
                foreach (char character in text)
                {
                    int number = Convert.ToInt32(character);
                    number += key;
                    newText += Convert.ToChar(number);
                }      
            }
            try
            {
                int randomNumber = new Random().Next();
                string path = Path.Combine(MyPath, randomNumber + ".txt");
                File.Create(path).Dispose();
                newText += Environment.NewLine + key;
                File.WriteAllText(path, newText);
                richTextBox1.Text = "file with path: " + path + " created with key";
            }
            catch
            {
                MessageBox.Show("file can not be created;");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            try
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string strfilename = ofd.InitialDirectory + ofd.FileName;
                    if (!strfilename.EndsWith(".txt"))
                    {
                        throw new Exception();
                    }
                    string[] lines = File.ReadAllLines(strfilename);
                    string text = lines[0];
                    string keyString = lines[1];

                    int key = Int32.Parse(keyString); ;
                    string newText = "";
                    if (!text.Equals(""))
                    {
                        foreach (char character in text)
                        {
                            int number = Convert.ToInt32(character);
                            number -= key;
                            newText += Convert.ToChar(number);
                        }

                        richTextBox1.Text = newText;
                    }
                }
            }
            catch
            {
                MessageBox.Show("error");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            try
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string strfilename = ofd.InitialDirectory + ofd.FileName;
                    if (!strfilename.EndsWith(".txt"))
                    {
                        throw new Exception();
                    }
                    string[] lines = File.ReadAllLines(strfilename);
                    string text = lines[0];
                    

                    int key = Decimal.ToInt32(numericUpDown1.Value) ;
                    string newText = "";
                    if (!text.Equals(""))
                    {
                        foreach (char character in text)
                        {
                            int number = Convert.ToInt32(character);
                            number -= key;
                            newText += Convert.ToChar(number);
                        }

                        richTextBox1.Text = newText;
                    }
                }
            }
            catch
            {
                MessageBox.Show("error");
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            int key = Decimal.ToInt32(numericUpDown1.Value);
            string text = richTextBox1.Text;
            string newText = "";
            if (!text.Equals(""))
            {
                foreach (char character in text)
                {
                    int number = Convert.ToInt32(character);
                    number += key;
                    newText += Convert.ToChar(number);
                }
            }
            try
            {
                int randomNumber = new Random().Next();
                string path = Path.Combine(MyPath, randomNumber + ".txt");
                File.Create(path).Dispose();
                File.WriteAllText(path, newText);
                richTextBox1.Text = "file with path: " + path;
            }
            catch
            {
                MessageBox.Show("file can not be created;");
            }

        }
    }
}
