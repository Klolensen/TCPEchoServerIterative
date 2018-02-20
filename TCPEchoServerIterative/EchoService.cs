using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;

namespace TCPEchoServerIterative
{
    class EchoService
    {
        private TcpClient _tcp;

        public EchoService(TcpClient tcp)
        {
            _tcp = tcp;
        }

        public void DoIt()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Ready for client");
                    Stream networkStream = _tcp.GetStream();
                    StreamReader streamReader = new StreamReader(networkStream);
                    StreamWriter streamWriter = new StreamWriter(networkStream);
                    streamWriter.AutoFlush = true;

                    string message = streamReader.ReadLine();
                    string answer = "";

                    while (message != null && message != "")
                    {
                        Console.WriteLine("Client: " + message);
                        answer = message.ToUpper();
                        streamWriter.WriteLine(answer);
                        message = streamReader.ReadLine();
                    }
                }
                catch (Exception)
                {
                    return;
                }
            }
        }
    }
}

