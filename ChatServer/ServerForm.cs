using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatServer
{
    public partial class ServerForm : Form
    {
        public ServerForm()
        {
            InitializeComponent();
        }

        private void ChattingList_Click()
        {
            Thread _child_thread = new Thread(handle_clients); 

        }
        private System.Windows.Forms.TextBox UserList;



    }
}
