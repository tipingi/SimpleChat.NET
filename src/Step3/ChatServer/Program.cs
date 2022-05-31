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
        static readonly object _locker = new object();
        static readonly Dictionary<int, TcpClient> _clients = new Dictionary<int, TcpClient>();

        class User
        {
            public int count;
            public string name;
            public TcpClient client;
        }

        static void Main(string[] args)
        {
            var _count = 1;

            var _server = new TcpListener(IPAddress.Any, 5000);
            _server.Start();

            while (true)
            {
                var _client = _server.AcceptTcpClient();

                lock (_locker) { _clients.Add(_count, _client); }
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

            lock (_locker) { _client = _clients[_sender]; }

            try
            {
                while (true)
                {
                    var _stream = _client.GetStream();
                    var _buffer = new byte[1024];

                    var _count = _stream.Read(_buffer, 0, _buffer.Length);
                    if (_count == 0)
                        break;

                    var _message = Encoding.UTF8.GetString(_buffer, 0, _count);
                    Console.WriteLine(_message);

                    broadcast(_message, _sender);
                }

                _client.Client.Shutdown(SocketShutdown.Both);
                _client.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"client #{_sender} is error: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("client #{0} is disconnected", _sender);
                lock (_locker) { _clients.Remove(_sender); }
            }
        }

        public static void broadcast(string data, int sender)
        {
            var _packet = Encoding.UTF8.GetBytes(data + Environment.NewLine);

            lock (_locker)
            {
                foreach (var _dict in _clients)
                {
                    if (_dict.Key == sender)
                        continue;
                    // continue문: 아래에 있는 실행해야 하는 문장들을 건너뛰고 다음 반복문 실행.
                    // break문: 더 이상 반복하지 말고 while, for문 끝냄.
                    var _client = _dict.Value;

                    var _stream = _client.GetStream();
                    //TcpClient _client 변수에 GetStream 함수 사용으로 인해 데이터를 보내고 받는데 사용되는 NetworkStream 값을 반환.
                    _stream.Write(_packet, 0, _packet.Length);
                }
            }
        }
    }
}