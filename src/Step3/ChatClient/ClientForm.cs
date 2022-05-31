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

namespace ChatClient
{
    public partial class ClientForm : Form
    {
        TcpClient client = new TcpClient();
        NetworkStream stream = default(NetworkStream);
        string message = string.Empty;
        public ClientForm()
        {
            InitializeComponent();
        }
  
        private void textBox1_TextChanged(object sender, EventArgs e) //ChattingList
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e) //MyChat
        {

        }

        private void button2_Click(object sender, EventArgs e) //Enter
        {

        }

        private void button1_Click(object sender, EventArgs e) //Start
        {
            client.Connect("127.0.0.1", 5000);
            stream = client.GetStream();
            ChattingLog.Text = "Connected to server...";

            Thread receive_message = new Thread(ReceiveMessage);
            receive_message.Start();
        }

       static void ReceiveMessage(object o)
        {
            TcpClient _client = (TcpClient)o;
            NetworkStream _stream = _client.GetStream();
            byte[] _buffer = new byte[1024];

            while (true)
            {
                int _count = _stream.Read(_buffer, 0, _buffer.Length);
                
                if (_count <= 0)
                    break;

                string _message = Encoding.UTF8.GetString(_buffer, 0, _count);
                
            }
            
        }


        //https://it-jerryfamily.tistory.com/entry/Program-C-%EC%84%9C%EB%B2%84%ED%81%B4%EB%9D%BC%EC%9D%B4%EC%96%B8%ED%8A%B8-%EC%B1%84%ED%8C%85-%ED%86%B5%EC%8B%A0?category=611730
    }
}
