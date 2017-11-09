using System;
using System.Net.Sockets;


namespace CoRe_Server
{
    public class Client
    {
        public int Index;
        public string IP;
        public TcpClient Socket;
        public NetworkStream myStream;
        private byte[] readBuffer;

        public void Start()
        {
            Socket.SendBufferSize = 4096;
            Socket.ReceiveBufferSize = 4096;
            myStream = Socket.GetStream();
            Array.Resize(ref readBuffer, Socket.ReceiveBufferSize);
            myStream.BeginRead(readBuffer, 0, Socket.ReceiveBufferSize, OnReceiveData, null);
        }

        private void OnReceiveData(IAsyncResult ar)
        {
            try
            {
                int readBytes = myStream.EndRead(ar);
                if(Socket == null)
                {
                    return;
                }
                if(readBytes <= 0)
                {
                    CloseConnection();
                    return;
                }

                byte[] newBytes = null;
                Array.Resize(ref newBytes, readBytes);
                Buffer.BlockCopy(readBuffer, 0, newBytes, 0, readBytes);

                //Handle Data

                if(Socket == null)
                {
                    return;
                }

                myStream.BeginRead(readBuffer, 0, Socket.ReceiveBufferSize, OnReceiveData, null);
            }
            catch (Exception ex)
            {
                //Show Error-Msg
                CloseConnection();
                return;
            }
        }

        private void CloseConnection()
        {
            Socket.Close();
            Socket = null;
            Console.WriteLine("Player disconnected: " + IP);
        }
    }
}
