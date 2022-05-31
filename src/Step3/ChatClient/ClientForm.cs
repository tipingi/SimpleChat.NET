using System;
using System.Net.Sockets;
using System.Text;
using System.Threading;
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


        private void btnEnter_Click(object sender, EventArgs e) //Enter
        {
            byte[] buffer = Encoding.UTF8.GetBytes(this.tbSendChatMsg.Text + "$"); 
            stream.Write(buffer, 0, buffer.Length); 
            stream.Flush();
        }

        private void button1_Click(object sender, EventArgs e) //Start
        {
            client.Connect("127.0.0.1", 5000);
            stream = client.GetStream();
            tbRecvChatMsg.Text = "Connected to server...";

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

        delegate void ShowDelegate(string text);

        private void DisplayText(string text) 
        { 
            if (InvokeRequired) 
            {
                ShowDelegate del = new ShowDelegate(DisplayText);
                this.Invoke(del, new object[] { text });

                //(new Action<string>(DisplayText)).Invoke(text);

                //chattingMsg.BeginInvoke(new MethodInvoker(delegate 
                //{ 
                //    chattingMsg.AppendText(text + Environment.NewLine); 
                //})); 
            }
            else
                tbRecvChatMsg.AppendText(text + Environment.NewLine); 
        }

        //https://it-jerryfamily.tistory.com/entry/Program-C-%EC%84%9C%EB%B2%84%ED%81%B4%EB%9D%BC%EC%9D%B4%EC%96%B8%ED%8A%B8-%EC%B1%84%ED%8C%85-%ED%86%B5%EC%8B%A0?category=611730
    }
}