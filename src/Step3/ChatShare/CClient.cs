using System.Net.Sockets;

namespace ChatShare
{
    public class CClient
    {
        public int connectId
        {
            get;
            set;
        }

        public bool isusername
        {
            get;
            set;
        }

        public string userid
        {
            get;
            set;
        }

        public TcpClient client
        {
            get;
            set;
        }
    }
}