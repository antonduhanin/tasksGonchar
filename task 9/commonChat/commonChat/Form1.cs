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

namespace commonChat
{
    public partial class Form1 : Form
    {
        TcpListener listener = new TcpListener(IPAddress.Parse("127.0.0.1"), 9999);
        Thread t1;
        List<NetworkStream> streams = new List<NetworkStream>();
        List<string> clients = new List<string>();
        TcpClient client;
 
        bool start = false;
        public Form1()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!start)
            {
                button1.Text = "stop server";
                start = true;
                t1 = new Thread(new ThreadStart(() =>
                {
                    while (true)
                    {
                        TcpClient client = listener.AcceptTcpClient();
                        NetworkStream stream = client.GetStream();
                        byte [] array = new byte[client.ReceiveBufferSize];
                        int size = stream.Read(array, 0, array.Length);
                        string name = Encoding.ASCII.GetString(array, 0, size);
                        bool find = false;
                        foreach(string c in clients){
                            if (c.Equals(name))
                            {
                                find = true;
                                break;
                            }
                        }
                        if(!find){
                            clients.Add(name);
                            streams.Add(stream);
                        }
                    
                            byte[] arrayMessage = new byte[client.ReceiveBufferSize];
                            int sizeMessage = stream.Read(array, 0, array.Length);


                            for (int i = 0; i < clients.Capacity;i++ )
                            {
                                byte[]clientName = Encoding.ASCII.GetBytes(clients[i]);
                                streams[i].Write(clientName, 0, clientName.Length);
                                streams[i].Write(arrayMessage, 0, arrayMessage.Length);
                            }
                        
                    }

                }));
                listener.Start();
                t1.Start();
            }else{
                button1.Text = "start server";
                start = false;
                listener.Stop();
                t1.Abort();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            client =   new TcpClient("127.0.0.1", 9999);
            string name = textBox1.Text;
            if(!name.Equals("")){
            NetworkStream stream= client.GetStream();
            byte[] bytes = Encoding.ASCII.GetBytes(name);
            stream.Write(bytes, 0, bytes.Length);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                NetworkStream stream = client.GetStream();
                string s =textBox2.Text;
                if (!s.Equals(""))
                {
                    byte[] mes = new byte[s.Length];
                    stream.Write(mes, 0, mes.Length);
                    byte[] array = new byte[client.ReceiveBufferSize];
                    int size = stream.Read(array, 0, array.Length);
                    string name = Encoding.ASCII.GetString(array, 0, size);
                    byte[] message = new byte[client.ReceiveBufferSize];
                    int sizeMessage = stream.Read(array, 0, array.Length);
                    string messs = Encoding.ASCII.GetString(array, 0, size);
                    listBox1.Items.Add(name);
                    listBox1.Items.Add(messs);

                }
            }
            catch
            {
                MessageBox.Show("error");
            }
        }
    }
}
