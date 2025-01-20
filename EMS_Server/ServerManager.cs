using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection.Metadata;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using EMS_CacheManager;
using EMS_Repositories;
using EMS_ServerUtilities;

namespace EMS_Server
{
    public class ServerManager
    {

        //create stances which will initialize and all the services which will run when server starts.
        //tcp connection
        private static List<Client> clients = new List<Client>(); //list of clients
        private static TcpListener serverSocket; //server socket
        private static CancellationTokenSource m_CancellationTokenSource;
        private static CancellationToken m_cancellationToken;

        public static Action<Client,Packet> msgRecieved;

        private static CacheManager m_CacheManager;
        public async Task Init()
        {
            m_CacheManager = CacheManager.Instance;
            StartServer();
        }


        private static void StartServer()
        {
            Console.WriteLine("Starting server....");
            int port = 5000;
            IPAddress localIP = IPAddress.Parse("127.0.0.1");

            m_CancellationTokenSource = new CancellationTokenSource();
            m_cancellationToken = m_CancellationTokenSource.Token;

            serverSocket = new TcpListener(localIP, port);
            serverSocket.Start();
            try
            {

                while(!m_CancellationTokenSource.IsCancellationRequested)
                {
                    Console.WriteLine("Waiting for client....");
                    TcpClient client = serverSocket.AcceptTcpClient();
                    NetworkStream ns = client.GetStream();

                    byte[] uidbuffer = new byte[1024];
                    ns.Read(uidbuffer, 0, uidbuffer.Length);
                    string uid = Encoding.UTF8.GetString(uidbuffer, 0, uidbuffer.Length);

                    Console.WriteLine($"Client {uid} connected!");
                    
                    Client newClient = new Client(client, uid);
                    clients.Add(newClient);

                    Task.Run(() => HandleClient(newClient));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                serverSocket.Dispose();
                serverSocket.Stop();

            }

        }

        private static void HandleClient(object obj)
        {

            Client client = (Client)obj;
            PacketHandler pkthndlr = new PacketHandler();
            NetworkStream ns = client.client_socket.GetStream();
            try 
            {
                while (client.client_socket.Connected)
                {

                    byte[] buffer = new byte[1024];
                    int bytesRead = ns.Read(buffer, 0,buffer.Length);
                    string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);

                    Packet jsonPacket = JsonSerializer.Deserialize<Packet>(message);
                    Console.WriteLine($"\n\nReceived: {message}\n\n");
                    Debug.WriteLine($"\n\nReceived: {message}\n\n");

                    msgRecieved?.Invoke(client,jsonPacket);
                }
            } 
            catch(Exception ex)
            {
                if (ex.GetType().Name == "IOException")
                {
                    Console.WriteLine("Client Disconnected");
                }

                    
            }
            finally
            {
                clients.Remove(client);
                client.client_socket.Close();
            }

        }

        public static void SendMessage(Packet pkt,Client client)
        {
            byte[] buffer = new byte[1024];
            NetworkStream ns = client.client_socket.GetStream();
            Console.WriteLine($"\n\nSending: {pkt.dataPayload}\n\n");
            buffer = Encoding.ASCII.GetBytes(JsonSerializer.Serialize(pkt));
            ns.WriteAsync(buffer, 0, buffer.Length);
            ns.Flush();
        }
    }
}

//var admins = new List<Employee>
//{
//    new Employee
//    {
//        m_Id = 1,
//        m_name = "Harry Potter",
//        m_designation = "System Administrator",
//        m_role = "Employee",
//        m_pwd = "Emp456",
//        m_salary = 90000.00,
//        m_attendance = new Attendance(true, 90, 10, 1, 2, 1),
//        m_leaves = new Leaves(10, 10, 2, 2, 16)
//    },
//    new Employee
//    {
//        m_Id = 2,
//        m_name = "John Doe",
//        m_designation = "System Administrator",
//        m_role = "Employee",
//        m_salary = 90000.00,
//        m_pwd = "Emp123",
//        m_attendance = new Attendance(true, 90, 10, 1, 2, 1),
//        m_leaves = new Leaves(10, 10, 2, 2, 16)
//    }
//};
//Admin admin = new Admin();
//admin.m_Id = 1;
//admin.m_name = "Harry Potter";
//admin.m_designation = "System Administrator";
//admin.m_role = "Employee";
//admin.m_pwd = "Emp456";
//admin.m_salary = 90000.00;
//admin.m_attendance = new Attendance(true, 90, 10, 1, 2, 1);
//admin.m_leaves = new Leaves(10, 10, 2, 2, 16);

//xmlSerializer xmlSerializer = new xmlSerializer();
//xmlSerializer.Serialize(admins);

//xmlSerializer xmlDeserializer = new xmlSerializer();
//List<Admin> admins = xmlDeserializer.Deserialize<List<Admin>>();
//foreach (Admin admin in admins)
//{
//    Console.WriteLine(admin.m_Id);
//}
