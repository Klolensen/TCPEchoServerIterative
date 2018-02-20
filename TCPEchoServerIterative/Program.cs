using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TCPEchoServerIterative
{
    class Program
    {
        static void Main(string[] args)
        {
            IPAddress ip = IPAddress.Parse("10.200.123.145");
            TcpListener serverSocket = new TcpListener(ip, 6789);
            serverSocket.Start();
            Console.WriteLine("Server started");
            
            TcpClient connectionSocket = serverSocket.AcceptTcpClient();
            EchoService service = new EchoService(connectionSocket);
            service.DoIt();
                

            
        }
    }
}
