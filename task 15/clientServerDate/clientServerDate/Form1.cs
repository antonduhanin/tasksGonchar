using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace clientServerDate
{
    public partial class Form1 : Form
    {
        private bool serverStart = false;
        private TcpListener listener = new TcpListener(IPAddress.Parse("127.0.0.1"), 9999);
        Thread t1;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!serverStart)
            {
                serverStart = true;
                listener.Start();
                t1 = new Thread((new ThreadStart(() =>
                {
                    while (true)
                    {

                        TcpClient client = listener.AcceptTcpClient();
                        NetworkStream stream = client.GetStream();
                        byte[] buffer = new byte[client.ReceiveBufferSize];
                        int bytesRead = stream.Read(buffer, 0, client.ReceiveBufferSize);
                       
                        string dataRecieved = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                        string textToSend;
                        if (dataRecieved.Equals("getDate"))
                        {
                            textToSend = DateTime.Now.ToString();
                        }
                        else {
                            textToSend = "incorrect query";
                        }
                        byte[] bytesToSend = ASCIIEncoding.ASCII.GetBytes(textToSend);
                        stream.Write(bytesToSend, 0, bytesToSend.Length);
                        
                       
                    }
                })));

                button1.Text = "stop server";
                t1.Start();
               
            }
            else
            {

                button1.Text = "start server";
                serverStart = false;
                listener.Stop();
                t1.Suspend();
            }
            
            
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                
                TcpClient client = new TcpClient("127.0.0.1", 9999);
                NetworkStream nwStream = client.GetStream();
                string sendMessage;
                if (textBox1.Text.Equals(""))
                {
                    sendMessage = "incorrect";

                }
                else
                {
                    sendMessage = textBox1.Text;
                }
                byte[] bytesToSend = ASCIIEncoding.ASCII.GetBytes(sendMessage);

                nwStream.Write(bytesToSend, 0, bytesToSend.Length);

                byte[] bytesToRead = new byte[client.ReceiveBufferSize];
                int bytesRead = nwStream.Read(bytesToRead, 0, client.ReceiveBufferSize);
                textBox1.Text=Encoding.ASCII.GetString(bytesToRead, 0, bytesRead);
            
            }
            catch
            {
                MessageBox.Show("connection failed");
            }
        }
    }
}
