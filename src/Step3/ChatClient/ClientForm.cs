using ChatShare;
using System;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace ChatClient
{
    public partial class ClientForm : Form
    {
        private bool _is_connected = false;

        private TcpClient _tcp_client = new TcpClient();
        private NetworkStream _nw_stream = default(NetworkStream);
        private Thread _recv_thread;

        public ClientForm()
        {
            InitializeComponent();
        }


        private void btConnect_Click(object sender, EventArgs e) //Connect button
        {
            if (_is_connected)
            {
                MessageBox.Show("Already connected...");
                return;
            }

            if (!String.IsNullOrEmpty(tbUserName.Text))
            {
                _tcp_client.Connect(tbServerIp.Text, 5000);
                _nw_stream = _tcp_client.GetStream();

                var _buffer = Encoding.UTF8.GetBytes(tbUserName.Text);
                _nw_stream.Write(_buffer, 0, _buffer.Length);
                _nw_stream.Flush();

                this.WriteChatBox("Connected to server...");

                _recv_thread = new Thread(ReceiveMessage);
                _recv_thread.Start(_tcp_client);

                _is_connected = true;
            }
            else
                MessageBox.Show("Please put your name.");
        }

        private void btDisConnect_Click(object sender, EventArgs e) //Disconnect button
        {
            _is_connected = false;
         
            _tcp_client.Client.Shutdown(SocketShutdown.Send);

            _recv_thread.Join();
            _nw_stream.Close();           
        }

        private void btSender_Click(object sender, EventArgs e) //Enter button
        {
            if (!_is_connected)
            {
                MessageBox.Show("Please connect to server...");
                return;
            }

            var _message = tbSendChatMsg.Text;
            this.WriteChatBox("My: " + _message);

            var _buffer = Encoding.UTF8.GetBytes(_message);
            _nw_stream.Write(_buffer, 0, _buffer.Length);
            _nw_stream.Flush();

            tbSendChatMsg.Text = "";
        }
 
        private void ReceiveMessage(object o) //Receive Message TextBox
        {
            var _client = (TcpClient)o;
            var _stream = _client.GetStream();
            
            var _buffer = new byte[1024];

            while (true)
            {
                int _count = _stream.Read(_buffer, 0, _buffer.Length);
                if (_count <= 0)
                    break;

                var _packet = CConverter.BytesToClass(_buffer, _count);
                DisplayText(_packet);
            }
        }

 
        delegate void ShowDelegate(CPacket packet);

        private void DisplayText(CPacket packet)
        {
            if (InvokeRequired)
            {
                ShowDelegate del = new ShowDelegate(DisplayText);
                this.Invoke(del, new object[] { packet });
            }
            else
            {              
                if (packet.message == packet.userid)
                {
                    WriteChatBox("");
                }
               
                else
                {
                    WriteChatBox($"{packet.userid}: {packet.message}");
                }
            }
        }

            private void WriteChatBox(string message)
        {
            tbRecvChatMsg.AppendText(message + Environment.NewLine);
        }


        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}