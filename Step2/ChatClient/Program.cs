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
            IPAddress ip = IPAddress.Parse("127.0.0.1");
            //IPAddress ipAddress = Dns.Resolve("localhost").AddressList[0];
            int port = 5000;
            TcpClient client = new TcpClient();
            client.Connect(ip, port);
            Console.WriteLine("Client Connected");

            NetworkStream ns = client.GetStream();
            Thread thread = new Thread(o => ReceiveData((TcpClient)o));

            thread.Start(client);

            string s;
            while (!string.IsNullOrEmpty((s = Console.ReadLine())))
            {
                byte[] buffer = Encoding.UTF8.GetBytes(s);
                ns.Write(buffer, 0, buffer.Length);
            }

            client.Client.Shutdown(SocketShutdown.Send);
            thread.Join();
            ns.Close();
            Console.WriteLine("Disconnect from Server");
            Console.ReadKey();
        }

        static void ReceiveData(TcpClient client)
        {
            NetworkStream ns = client.GetStream();
            byte[] receivedBytes = new byte[1024];

            int byte_count;

            while((byte_count = ns.Read(receivedBytes, 0, receivedBytes.Length))> 0)
            {
                Console.Write(Encoding.UTF8.GetString(receivedBytes, 0, byte_count));
            }

        }

    }
}