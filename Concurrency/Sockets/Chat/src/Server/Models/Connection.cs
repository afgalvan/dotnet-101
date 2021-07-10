using System;
using System.Net.Sockets;

namespace Server.Models
{
    public class Connection
    {
        public Socket Socket  { get; set; }
        public byte[] Message { get; set; }

        public Connection(Socket socket, byte[] message)
        {
            Socket  = socket;
            Message = message;
        }

        public Connection(Socket socket) : this(socket, new byte[100])
        {
        }

        public bool IsConnected()
        {
            try
            {
                return !(Socket.Poll(1, SelectMode.SelectRead) &&
                         Socket.Available == 0);
            }
            catch (SocketException)
            {
                return false;
            }
        }

        public void Close()
        {
            try
            {
                Socket.Shutdown(SocketShutdown.Both);
                Socket.Close();
            }
            catch (Exception)
            {
                // ignored
            }
        }
    }
}
