using ChatShare;
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
        static readonly Dictionary<int, CClient> _clients = new Dictionary<int, CClient>();

        static void Main(string[] args)
        {
            var _count = 1;

            var _server = new TcpListener(IPAddress.Any, 5000);
            _server.Start();

            while (true)
            {
                var _client = _server.AcceptTcpClient();

                var _connector = new CClient
                {
                  //  isconnected = true,
                    connectId = _count,
                    userid = "",
                    isusername = false,
                    client = _client
                };

                lock (_locker) 
                    _clients.Add(_count, _connector); 

                Console.WriteLine($"client {_connector.connectId} is connected");

                var _child_thread = new Thread(handle_clients);
                _child_thread.Start(_connector);

                _count++;
            }
        }

        public static void handle_clients(object o)
        {
            var _sender = (CClient)o;
            var _connectId = _sender.connectId;
           
            try
            {
                while (true)
                {                   
                    var _stream = _sender.client.GetStream();                    
                    var _buffer = new byte[1024];
                  //  var _is_connected = _sender.isconnected;

                    var _count = _stream.Read(_buffer, 0, _buffer.Length);
                    if (_count == 0)
                        break;

                    var _message = Encoding.UTF8.GetString(_buffer, 0, _count);
                    
                    if (!_sender.isusername) //username이면
                    {
                        _sender.userid = _message;
                        _sender.isusername = true;

                        broadcast(PacketType.command, _message, _sender);
                    }
                    else
                    {
                        broadcast(PacketType.message, _message, _sender);
                    }
                }
                
                _sender.client.Client.Shutdown(SocketShutdown.Both);
                _sender.client.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{_sender.userid} occured error: {ex.Message}");
            }
            finally
            {
                Console.WriteLine($"{_sender.userid}(=client {_connectId}) is disconnected");
                lock (_locker) { _clients.Remove(_sender.connectId); }
            }
        }

        public static void broadcast(PacketType type, string message, CClient sender)
        {
            var _packet = new CPacket
            {
                type = type,
                userid = sender.userid,
                message = message,
               // isconnected = sender.isconnected             
            };

            var _buffer = CConverter.ClassToBytes(_packet);

            lock (_locker)
            {
                foreach (var _dict in _clients)
                {
                    if (_dict.Key == sender.connectId)
                        continue;
                                   
                    var _client = _dict.Value;
                    var _stream = _client.client.GetStream();         
                    _stream.Write(_buffer, 0, _buffer.Length);

                    // TcpClient _client 변수에 GetStream 함수 사용으로 인해 데이터를 보내고 받는데 사용되는 NetworkStream 값을 반환.
                    // continue문: 아래에 있는 실행해야 하는 문장들을 건너뛰고 다음 반복문 실행.
                    // break문: 더 이상 반복하지 말고 while, for문 끝냄.

                }
            }
        }
    }
}