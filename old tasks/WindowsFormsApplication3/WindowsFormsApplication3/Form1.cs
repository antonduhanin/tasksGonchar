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

namespace WindowsFormsApplication3
{
    public partial class Form1 : Form
    {
        List<string> files = new List<string>();
        public Form1()
        {
            InitializeComponent();
            textBox3.ReadOnly = true;

        }

        private void setFolder()
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.ShowDialog();
   


           string[]filesArray =Directory.GetFiles(fbd.SelectedPath);
            List<string>imgfiles = new List<string>();
            foreach (string s in filesArray)
            {
            if(s.EndsWith("jpg")){
                imgfiles.Add(s);
        }
        }
            if(imgfiles.Capacity<1){
                setFolder();
            }else{
                files = imgfiles;
            }
        }
        private void Form1_Load(object sender, EventArgs e){
            setFolder();
            listBox1.DataSource = files;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var listBox = (ListBox)sender;
            pictureBox2.ImageLocation = (string)listBox.SelectedItem;


        }



      
    }
}
