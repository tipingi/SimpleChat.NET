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
  
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            client.Connect("127.0.0.1", 5000);
            stream = client.GetStream();
            message = "Connected to Server...";
            string.W


                //https://it-jerryfamily.tistory.com/entry/Program-C-%EC%84%9C%EB%B2%84%ED%81%B4%EB%9D%BC%EC%9D%B4%EC%96%B8%ED%8A%B8-1N-%ED%86%B5%EC%8B%A0
        }
    }
}
