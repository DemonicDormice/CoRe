using System;
using System.Net;
using System.Net.Sockets;
namespace CoRe_Server
{


    public class Network
    {

        public TcpListener ServerSocket;
        public static Network instance = new Network();
        public void StartServer()
        {
            ServerSocket = new TcpListener(IPAddress.Any, 5500);
            ServerSocket.Start();
            ServerSocket.BeginAcceptTcpClient(OnClientConnect);
        }

        void OnClientConnect(IAsyncResult result)
        {
            TcpClient client = ServerSocket.EndAcceptTcpClient(result);
            client.NoDelay = false;
            ServerSocket.BeginAcceptTcpClient(OnClientConnect, null);
        }
    }

}