using System;
using System.Net;
using System.Net.Sockets;

namespace Bank.Server
{
    class BankServer
    {
        public BankServer()
        {
            server = new TcpListener(localAddr, port);
            server.Start();
            serverStart();
        }

        private void serverStart()
        {
            while (true)
            {
                try
                {
                    TcpClient client = server.AcceptTcpClient();
                    NetworkStream stream = client.GetStream();

                }
            }
        }

        private IPAddress localAddr = IPAddress.Parse("127.0.0.1");
        private int port = 8888;
        private TcpListener server;
    }
}
