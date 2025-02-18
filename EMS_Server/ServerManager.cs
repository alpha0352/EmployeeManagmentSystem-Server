using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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

        public static Action<Client, Packet> msgRecieved;

        private static CacheManager m_CacheManager;
        public async Task Init()
        {
            m_CacheManager = CacheManager.Instance;
            StartServer();
            
        }

        public void AppExit(object? sender, EventArgs e)
        {
            CacheManager.Instance.SaveCache();
            Debug.WriteLine("PROCESS EXIT");
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

                while (!m_CancellationTokenSource.IsCancellationRequested)
                {
                    //Console.WriteLine("Waiting for client....");
                    TcpClient client = serverSocket.AcceptTcpClient();
                    NetworkStream ns = client.GetStream();

                    //byte[] uidbuffer = new byte[17000];
                    //ns.Read(uidbuffer, 0, uidbuffer.Length);
                    //string msg = Encoding.UTF8.GetString(uidbuffer, 0, uidbuffer.Length);

                    Guid clientID = Guid.NewGuid();
                    //Console.WriteLine($"Client {clientID} connected!");

                    Client newClient = new Client(client, clientID);
                    clients.Add(newClient);

                    if (clients.Count > 1)
                    {
                        throw new Exception("server crash!");
                    }

                    Task.Run(() => HandleClient(newClient));
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception in StartServer");
                Console.WriteLine(ex.Message);
                m_CacheManager.SaveCache();
            }
            finally
            {

                Debug.WriteLine("Exception in StartServer");
                serverSocket.Dispose();
                serverSocket.Stop();

            }

        }

        private static void HandleClient(object obj)
        {
            PacketHandler? pkthndlr = new PacketHandler();
            Client client = (Client)obj;
            NetworkStream ns = client.client_socket.GetStream();
            try
            {
                
                while (client.client_socket.Connected)
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        byte[] buffer = new byte[1024];
                        int bytesRead = ns.Read(buffer, 0, buffer.Length);
                        while (bytesRead > 0)
                        {
                            ms.Write(buffer, 0, bytesRead);
                            if (!ns.DataAvailable) break;
                            bytesRead = ns.Read(buffer, 0, buffer.Length);
                        }
                        string message = Encoding.ASCII.GetString(ms.ToArray());
                        
                        if (!string.IsNullOrEmpty(message))
                        {
                            Console.WriteLine($"\n\nReceived: {message}\n\n");
                            Debug.WriteLine($"\n\nReceived: {message}\n\n");
                            Packet jsonPacket = JsonSerializer.Deserialize<Packet>(message);
                            msgRecieved?.Invoke(client, jsonPacket);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.GetType().Name == "IOException")
                {
                    Console.WriteLine("Client Disconnected");
                }
                else
                {
                    Debug.WriteLine(ex);
                }
            }
            finally
            {
                if(pkthndlr != null)
                {
                    pkthndlr.Dispose();
                }
                clients.Remove(client);
                client.client_socket.Close();
            }

        }
        public static void SendMessage(Packet pkt, Client client)
        {
            byte[] buffer = new byte[1024];
            NetworkStream ns = client.client_socket.GetStream();
            //Console.WriteLine($"\n\nSending: {pkt.dataPayload}\n\n");
            Debug.WriteLine($"\n\nSending: {pkt.m_stDataPayload}\n\n");
            buffer = Encoding.ASCII.GetBytes(JsonSerializer.Serialize(pkt));
            ns.WriteAsync(buffer, 0, buffer.Length);
            ns.Flush();
        }

        public static void BroadcastUpdates(Packet pkt,Client CurrentClient)
        {
            Console.WriteLine("Sending Broadcast...");
            byte[] buffer = new byte[1024];
            pkt.m_enMethod = MethodType.PUT;
            buffer = Encoding.ASCII.GetBytes(JsonSerializer.Serialize(pkt));

            foreach (Client client in clients)
            //{
                if (client != CurrentClient) 
                {
                    NetworkStream ns = client.client_socket.GetStream();
                    ns.WriteAsync(buffer, 0, buffer.Length);
                    
                }
            }
        }
    }
