using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;

namespace TCPlistener
{
    class Program
    {
        static void Main(string[] args)
        {
            var tcp = new TcpListener(IPAddress.Parse("127.0.0.1"), 9090);

            tcp.Start(32);

            var buf = new byte[512];
            using var tcpClient = tcp.AcceptTcpClient();
            tcpClient.GetStream().Read(buf, 32, 32);

            var data = Encoding.ASCII.GetString(buf);
            Console.WriteLine(data);

            tcp.Stop();

        }
    }
}
