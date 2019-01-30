using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        private const string PathSeparator = "\\";
        private readonly List<string> _extensions = new List<string>()
        {
            ".jpg",
            ".gif",
            ".png"
        };
        private string _path;

        public Form1()
        {
            InitializeComponent();
            setFolder();
        }
        private void setFolder()
        {
            try
            {
                using (var fbd = new FolderBrowserDialog())
                {
                    var result = fbd.ShowDialog();
                    if (result != DialogResult.OK || string.IsNullOrWhiteSpace(fbd.SelectedPath)) return;
                    
                    var files = Directory.GetFiles(fbd.SelectedPath, "*.*")
                        .Where(file => _extensions.Contains(Path.GetExtension(file)))
                        .Select(Path.GetFullPath)
                        .ToList();
                    if (files.Count > 0)
                    {
                        listBox1.Items.Clear();
                        foreach (var file in files)
                        {
                            listBox1.Items.Add(file);
                        }
                        _path = fbd.SelectedPath;
                        textBox1.Text = fbd.SelectedPath;
                    }
                    else
                    {
                        MessageBox.Show("Files not found in folder: " + fbd.SelectedPath);
                        setFolder();
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Exception Occured: " + e.Message);
            }

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var listBox = (ListBox)sender;
            if ((string)listBox.SelectedItem != null)
            {
                pictureBox2.ImageLocation = (string)listBox.SelectedItem;
                
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            setFolder();
        }

    }
}
