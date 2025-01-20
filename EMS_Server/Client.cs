using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace EMS_Server
{
    public class Client
    {
        public TcpClient client_socket;
        public string uid;

        public Client(TcpClient client, string userID)
        {
            this.uid = userID;
            this.client_socket = client;
        }

    }
}

