using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace ChatServer
{
    internal class Program
    {
        static readonly object _lock_object = new object();
        static readonly Dictionary<int, TcpClient> _dict_clients = new Dictionary<int, TcpClient>();
        

        static void Main(string[] args)
        {
            var _count = 1;

            var _server = new TcpListener(IPAddress.Any, 5000);
            _server.Start();

            while (true)
            {
                var _client = _server.AcceptTcpClient();
                lock (_lock_object) { _dict_clients.Add(_count, _client); }
                Console.WriteLine("client #{0} is connected", _count);

                var _child_thread = new Thread(handle_clients);
                _child_thread.Start(_count);

                _count++;
            }
        }

        public static void handle_clients(object o)
        {
            var _sender = (int)o;
            var _client = (TcpClient)null;

            lock (_lock_object) { _client = _dict_clients[_sender]; }

            while (true)
            {
                var _stream = _client.GetStream();

                var _buffer = new byte[1024];
                var _count = _stream.Read(_buffer, 0, _buffer.Length);

                if (_count == 0)
                    break;

                var _message = Encoding.UTF8.GetString(_buffer, 0, _count);
                brodcast(_message, _sender);

                Console.WriteLine(_message);
            }

            lock (_lock_object) { _dict_clients.Remove(_sender); }
            _client.Client.Shutdown(SocketShutdown.Both);
            _client.Close();
        }

        public static void brodcast(string data, int sender)
        {
            var _packet = Encoding.UTF8.GetBytes(data + Environment.NewLine);

            lock (_lock_object)
            {
                foreach (var _dict in _dict_clients)
                {
                    if (_dict.Key == sender)
                        continue;

                    var _client = (TcpClient)_dict.Value;

                    var _stream = _client.GetStream();
                    _stream.Write(_packet, 0, _packet.Length);
                }
            }
        }
    }
}