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
        TcpListener listener = new TcpListener(IPAddress.Parse("127.0.0.1"),9999);
        bool startServer = false;
        Thread t1;
        string path = "";

        public Form1()
        {
            InitializeComponent();
        }
        //server
        private void button1_Click(object sender, EventArgs e)
        {
            if (startServer)
            {
                listener.Stop();
                t1.Abort();
                button1.Text = "start server";
            }
            else
            {
                t1 = new Thread(new ThreadStart(() =>
                {
                    while (true)
                    {
                        TcpClient client = listener.AcceptTcpClient();
                        NetworkStream stream = client.GetStream();
                        byte[] buffer = new byte[client.ReceiveBufferSize];
                        int size = stream.Read(buffer, 0, buffer.Length);
                        string inputString = Encoding.ASCII.GetString(buffer, 0, size);

                        string path = @inputString;
                        byte[] fileBytes = File.ReadAllBytes(path);
                        stream.Write(fileBytes, 0, fileBytes.Length);
                    }
                }));
                button1.Text = "stop server";
                listener.Start();
                startServer = true;
                t1.Start();
            }

        }
        //browse to html file
        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.ShowDialog();
            path = fd.InitialDirectory + fd.FileName;
        }
        //client
        private void button2_Click(object sender, EventArgs e)
        {
            if (!path.Equals("") || path.EndsWith(".html"))
            {
                try
                {
                    TcpClient client = new TcpClient("127.0.0.1", 9999);
                    NetworkStream stream = client.GetStream();
                    byte[] bytesToSend = Encoding.ASCII.GetBytes(path);
                    stream.Write(bytesToSend,0,bytesToSend.Length);
                    byte[] buffer = new byte[client.ReceiveBufferSize];
                    int size = stream.Read(buffer, 0, buffer.Length);
                    FolderBrowserDialog fbd = new FolderBrowserDialog();
                    fbd.ShowDialog();
                    string folderPath = fbd.SelectedPath;
                    Random random = new Random();
                    folderPath +="\\"+random.Next()+".html";
                    File.Create(folderPath).Dispose();
                    File.WriteAllBytes(folderPath, buffer);

                    System.Diagnostics.Process.Start(folderPath);
                    client.Close(); 
                }
                catch {
                    MessageBox.Show("client error");
                }
            }
            else
            {

                MessageBox.Show("file is not html");


            }
            

        }
    }
}
