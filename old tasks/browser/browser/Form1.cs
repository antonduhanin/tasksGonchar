using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace browser
{
    public partial class Form1 : Form
    {
        public TcpClient client;
        public NetworkStream stream;
        public Form1()
        {
            InitializeComponent();
            InitSocket();
        }
        public void InitSocket()
        {
            client = new TcpClient();
            client.Connect("127.0.0.1", 9999);
            stream = client.GetStream();
        }
        public void recieveFile()
        {
            int BufferSize = 1024;
            byte[] RecData = new byte[BufferSize];
            int recBytes;
            string SaveFileName = string.Empty;
            SaveFileDialog dialogSave = new SaveFileDialog();
            dialogSave.Filter = "All files (*.*)|*.*";
            dialogSave.RestoreDirectory = true;
            dialogSave.Title = "where do you wans to save the file";
            dialogSave.InitialDirectory = @"F:/";
            dialogSave.ShowDialog();
            SaveFileName = dialogSave.FileName;
            if (!SaveFileName.Equals(string.Empty))
            {
                int totalrecbytes = 0;
                FileStream fs = new FileStream(SaveFileName,FileMode.OpenOrCreate,FileAccess.Write);
                while((recBytes=stream.Read(RecData,0,RecData.Length))>0)
                {
                    fs.Write(RecData, 0, recBytes);
                    totalrecbytes += recBytes;
                }
                fs.Close();

            }
        }
        private void button1_Click(object sender, EventArgs e)
        {


            string message = textBox1.Text;
            byte[] sendbytes = Encoding.ASCII.GetBytes(message);
            byte[] intLength = BitConverter.GetBytes(sendbytes.Length);
            stream.Write(intLength, 0, intLength.Length);
            stream.Write(sendbytes, 0, sendbytes.Length);

            recieveFile();

        }
    }
}
