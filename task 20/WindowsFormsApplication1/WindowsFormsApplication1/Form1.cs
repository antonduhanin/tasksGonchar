using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        Thread t1;
        bool start = false;
        TcpListener listener = new TcpListener(IPAddress.Parse("127.0.0.1"),9999);
        string path = "";
        public Form1()
        {
            InitializeComponent();
        }



        private void button2_Click(object sender, EventArgs e)
        {
            if (!path.Equals("") && path.EndsWith("txt"))
            {
                try
                {
                    TcpClient client = new TcpClient("127.0.0.1", 9999);
                    NetworkStream stream = client.GetStream();

                    byte[] bytesToSend = Encoding.ASCII.GetBytes(path);
                    stream.Write(bytesToSend, 0, bytesToSend.Length);
                    byte[] buffer = new byte[client.ReceiveBufferSize];
                    int bytesRead = stream.Read(buffer, 0, client.ReceiveBufferSize);
                    FolderBrowserDialog fbd = new FolderBrowserDialog();
                    fbd.ShowDialog();
                    Random r = new Random();
                    string pathToSaveFile = fbd.SelectedPath+"\\"+r.Next()+".txt";
                    File.Create(path).Dispose();

                    File.WriteAllBytes(pathToSaveFile, buffer);
                    richTextBox1.Text =Encoding.ASCII.GetString(buffer);
                    
                  
                }
                catch
                {
                    MessageBox.Show("client error");
                }
            }
            else
            {
                MessageBox.Show("empty file or not txt");
             
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.ShowDialog();
            
                path = ofd.InitialDirectory + ofd.FileName;
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!start)
            {
                button1.Text = "stop server";
                t1 = new Thread(new ThreadStart(() =>
                {
                    while (true)
                    {
                        TcpClient client = listener.AcceptTcpClient();
                        NetworkStream stream = client.GetStream();
                        byte[] recievedBytes = new byte[client.ReceiveBufferSize];
                        int bytesRead = stream.Read(recievedBytes, 0, recievedBytes.Length);
                        string recievedPath = Encoding.ASCII.GetString(recievedBytes, 0, bytesRead);
                        string path = @recievedPath;
                        byte[] fileBytes = File.ReadAllBytes(path);
                        stream.Write(fileBytes, 0, fileBytes.Length);
                    }
                }));
                listener.Start();
                t1.Start();
            }
            else
            {
                start = false;
                button1.Text = "start server";
            }
        }
    }
}
