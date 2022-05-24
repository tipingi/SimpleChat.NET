using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Text;

namespace ChatClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var _ipaddress = IPAddress.Parse("127.0.0.1");
            var _port_no = 5000;

            var _client = new TcpClient();
            _client.Connect(_ipaddress, _port_no);

            Console.WriteLine("connected to server...");
            
            var _stream = _client.GetStream();

            var _receive_thread = new Thread(ReceiveMessage);
            _receive_thread.Start(_client);

            while (true)
            {
                var _message = Console.ReadLine();
                if (String.IsNullOrEmpty(_message))
                    break;

                var _buffer = Encoding.UTF8.GetBytes(_message);
                _stream.Write(_buffer, 0, _buffer.Length);
            }

            _client.Client.Shutdown(SocketShutdown.Send);
            _receive_thread.Join();

            _stream.Close();

            Console.WriteLine("Disconnect from Server");
            Console.ReadKey();
        }

        static void ReceiveMessage(object o)
        {
            var _client = (TcpClient)o;

            var _stream = _client.GetStream();
            var _buffer = new byte[1024];

            while(true)
            {
                var _count = _stream.Read(_buffer, 0, _buffer.Length);
                if (_count <= 0)
                    break;

                var _message = Encoding.UTF8.GetString(_buffer, 0, _count);
                Console.Write(_message);
            }
        }
    }
}