using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerMessaggiBaseAlContrario
{
    public class Server
    {
        private Itransport transport;

        public Server(Itransport gameTransport)
        {
            transport = gameTransport;
        }

        public void Start()
        {
            Console.WriteLine("Server Starto");

            while (true)
            {
                SingleStep();
            }
        }

        public void SingleStep()
        {
            EndPoint sender = transport.CreateEndPoint();
            byte[] data = transport.Recv(256, ref sender);

            Console.WriteLine(Encoding.UTF8.GetString(data));

            if (data != null)
            {
                byte[] packToSend = Process(data);

                if(Send(packToSend, sender))
                {
                    Console.WriteLine("Fatto: "+ sender);
                }
                else
                {
                    Console.WriteLine("dio can: " + sender);
                }
            }
        }

        public bool Send(byte[] packet, EndPoint endPoint)
        {
            return transport.Send(packet, endPoint);
        }

        public byte[] Process(byte[] data)
        {
            string message = Encoding.UTF8.GetString(data);

            char[] messageArr = message.ToCharArray();
            Array.Reverse(messageArr);
            message = new string(messageArr);

            data = Encoding.UTF8.GetBytes(message);
            
            return data;
        }
    }
}
