using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PilotChatServer
{
    internal class Program
    {
        static readonly object _lock_objcet = new object();
        static readonly Dictionary<int, TcpClient> _dict_client = new Dictionary<int, TcpClient>();
        static void Main(string[] args)
        {
            var count = 1;

            TcpListener _server = new TcpListener(IPAddress.Any, 5000);
            _server.Start();

            while (true)
            {
                TcpClient _client = _server.AcceptTcpClient();
                lock (_lock_objcet) { _dict_client.Add(count, _client); }
                Console.WriteLine("Client #{0} Connected", count);

                Thread _child_thread = new Thread(HandleClient);
                _child_thread.Start();

                count++;
            }

        }

        public static void HandleClient(object o)
        {
            int _sender = (int)o;
            TcpClient _client = null;
            lock (_lock_objcet) {_client = _dict_client[_sender]; }

            while (true)
            {
                NetworkStream _stream = _client.GetStream();
                byte[] _buffer = new byte[1024];
                int _count = _stream.Read(_buffer, 0, _buffer.Length);

                if(_count == 0)
                {
                    break;
                }

                string message = Encoding.UTF8.GetString(_buffer, 0, _count);
                Console.WriteLine(message);

                Broadcast(message, _count);
            }
            Console.WriteLine("Client #{0} is disconnected", _sender);
            lock (_lock_objcet) { _dict_client.Remove(_sender); }
            _client.Client.Shutdown(SocketShutdown.Both);
            _client.Close();
        }

        public static void Broadcast(string message, int count)
        {
            byte[] _packet = Encoding.UTF8.GetBytes(message + Environment.NewLine);

            lock (_lock_objcet)
            {
                foreach(KeyValuePair<int , TcpClient> _dict in _dict_client)
                {
                    if (_dict.Key == count) continue;

                    TcpClient _client = _dict.Value;
                    NetworkStream _stream = _client.GetStream();
                    _stream.Write(_packet, 0, _packet.Length);

                }
            }
            
        }


    }
}
