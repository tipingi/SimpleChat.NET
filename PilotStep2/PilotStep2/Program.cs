using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Net.WebSockets;
using System.Threading;

namespace PilotStep2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IPAddress _ipaddress = IPAddress.Parse("127.0.0.1");
            int _port_no = 5000;

            TcpClient _client = new TcpClient();
            _client.Connect(_ipaddress, _port_no);

            Console.WriteLine("Connected to server");
            NetworkStream _stream = _client.GetStream();
            Thread _receive_thread = new Thread(ReceiveMessage);
            _receive_thread.Start();

            while (true)
            {
                Console.Write("My: ");
                string _message = Console.ReadLine();
                if (String.IsNullOrEmpty(_message)) break;

                byte[] buffer = Encoding.UTF8.GetBytes(_message);
                _stream.Write(buffer, 0, buffer.Length);                
            }

            _client.Client.Shutdown(SocketShutdown.Send);
            _receive_thread.Join();

            _stream.Close();

            Console.WriteLine("Closed");
            Console.ReadKey();
            

        }
        static void ReceiveMessage(object o)
        {
            TcpClient _client = (TcpClient)o;

            NetworkStream _stream = _client.GetStream();
            byte[] _buffer = new byte[1024];


            while (true)
            {
                int _count = _stream.Read(_buffer, 0, _buffer.Length); //NetworkStream.Read: NetworkStream 에서 데이터를 읽는데 데이터가 오는 걸 기다린다. 데이터가 오면 byte 배열에 저장.
                //그리고 byte 수만큼 반환.
                if (_count <= 0) break;

                string _message = Encoding.UTF8.GetString(_buffer, 0, _count);
                Console.WriteLine(_message);
            }

        }

    }
}
