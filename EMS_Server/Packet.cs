using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Json;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using EMS_CacheManager;
using EMS_Repositories;
using EMS_ServerUtilities;

namespace EMS_Server
{
    public class Packet
    {
        public string type { get; set; }    // Request/Response
        public string method { get; set; } // GET/POST
        public string dataType { get; set; }    // AdminCache/EmployeeCache
        public string dataPayload { get; set; }    // JSON data

        public Packet(string type ,string method, string datatype,string datapayload)
        {
            this.type = type;
            this.method = method;
            this.dataType = datatype;
            this.dataPayload = datapayload;
        }
    }
    public class PacketHandler
    {
        public PacketHandler()
        {
            if (!isSubscribed) //not necessary here, in case other used by class
            {
                ServerManager.msgRecieved += HandleRequest;
                isSubscribed = true;
            }
        }
        private static bool isSubscribed = false;


        public void HandleRequest(Client client,Packet pkt)
        {

            if (pkt.method == "GET")
            {
                if (pkt.dataType == "AdminCache")
                {
                    Console.WriteLine(pkt);
                    string AdminData = JsonSerializer.Serialize(CacheManager.Instance.AdminCache);
                    Packet adminPkt = new Packet("Response", "POST", "AdminCache", AdminData);
                    //ServerManager.SendMessage(AdminData, "AdminCache", client);
                    ServerManager.SendMessage(adminPkt, client);
                }
                else if (pkt.dataType == "EmployeeCache")
                {
                    string EmployeeData = JsonSerializer.Serialize(CacheManager.Instance.EmployeeCache);
                    Packet empPkt = new Packet("Response", "POST", "EmployeeCache", EmployeeData);
                    ServerManager.SendMessage(empPkt, client);
                }
            }
            else if (pkt.method == "POST")
            {
                if (pkt.dataType == "AdminCache")
                {
                    CacheManager.Instance.AdminCache = JsonSerializer.Deserialize<ObservableCollection<Admin>>(pkt.dataPayload);
                    Debug.WriteLine(CacheManager.Instance.AdminCache);
                }
                else if (pkt.dataType == "EmployeeCache")
                {
                    CacheManager.Instance.EmployeeCache = JsonSerializer.Deserialize<ObservableCollection<Employee>>(pkt.dataPayload);
                    Debug.WriteLine(CacheManager.Instance.EmployeeCache);
                }
            }

            return;


            //switch (pkt.method)
            //{
            //    case "GET":
            //        switch (pkt.dataType)
            //        {
            //            case "AdminCache":
            //                Console.WriteLine(pkt);
            //                string AdminData = JsonSerializer.Serialize(CacheManager.Instance.AdminCache);
            //                Packet adminPkt = new Packet("Response", "POST", "AdminCache", AdminData);
            //                ServerManager.SendMessage(AdminData, "AdminCache", client);
            //                break;
            //            case "EmployeeCache":
            //                string EmployeeData = JsonSerializer.Serialize(CacheManager.Instance.EmployeeCache);
            //                Packet empPkt = new Packet("Response", "POST", "EmployeeCache", EmployeeData);
            //                ServerManager.SendMessage(EmployeeData, "EmpCache", client);
            //                break;
            //        }
            //        break;

            //    case "POST":
            //        switch (pkt.dataType)
            //        {
            //            case "AdminCache":
            //                CacheManager.Instance.AdminCache = JsonSerializer.Deserialize<ObservableCollection<Admin>>(pkt.dataPayload);
            //                break;
            //            case "EmployeeCache":
            //                CacheManager.Instance.EmployeeCache = JsonSerializer.Deserialize<ObservableCollection<Employee>>(pkt.dataPayload);
            //                break;

            //        }
            //        break;


            //}

        }
        //~PacketHandler()
        //{
        //    ServerManager.msgRecieved -= HandleRequest;
        //}
    }
}
