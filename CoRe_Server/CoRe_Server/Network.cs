using System;
using System.Net;
using System.Net.Sockets;
namespace CoRe_Server
{


    public class Network
    {

        public TcpListener ServerSocket;
        public static Network instance = new Network();

        //Set number of clients that are able to connect
        public static Client[] clients = new Client[100];

        public void StartServer()
        {
            for (int i = 0; i < clients.Length; i++)
            {
                clients[i] = new Client();
            }

            ServerSocket = new TcpListener(IPAddress.Any, 5500);
            ServerSocket.Start();
            ServerSocket.BeginAcceptTcpClient(OnClientConnect, null);

            Console.WriteLine("Server is up and running.");
        }

        void OnClientConnect(IAsyncResult result)
        {
            TcpClient client = ServerSocket.EndAcceptTcpClient(result);
            client.NoDelay = false;
            ServerSocket.BeginAcceptTcpClient(OnClientConnect, null);

            for (int i = 0; i < clients.Length; i++)
            {
                if (clients[i].Socket == null)
                {
                    clients[i].Socket = client;
                    clients[i].Index = i;
                    clients[i].IP = client.Client.RemoteEndPoint.ToString();
                    clients[i].Start();
                    Console.WriteLine("Incoming connection from: " + clients[i].IP + "||Index= " + i);
                    //Send Welcome Message
                    return;
                }

            }
        }
    }

}