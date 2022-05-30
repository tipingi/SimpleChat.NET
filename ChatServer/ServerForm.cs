using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatServer
{
    public partial class ServerForm : Form
    {
        static readonly object _locket = new object();
        static readonly Dictionary<int, TcpClient> _clients = new Dictionary<int, TcpClient>();
        public ServerForm()
        {
            InitializeComponent();
        }

        private void ChattingList_Click()
        {
            

        }

        private void ChattingList_TextChanged(object sender, EventArgs e) //broadcast
        {
            
        }

        private void UserList_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
