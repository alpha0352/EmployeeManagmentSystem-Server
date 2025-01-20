using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            ServerManager.msgRecieved += HandleRequest;
        }
        private void HandleRequest(Client client,Packet pkt)
        {
            //Console.WriteLine("type: " + pkt.type);
            //Console.WriteLine("method: " + pkt.method);
            //Console.WriteLine("dataType: " + pkt.dataType);
            //Console.WriteLine("dataPayload: " + pkt.dataPayload);
            //Console.WriteLine("INVOKED");

            switch (pkt.method)
            {
                case "GET":
                    switch (pkt.dataType)
                    {
                        case "AdminCache":
                            string AdminData = JsonSerializer.Serialize(CacheManager.Instance.AdminCache);
                            //var Payload = new
                            //{
                            //    type = "Response",
                            //    method = "POST",
                            //    dataType = "AdminCache",
                            //    dataPayload = AdminData

                            //};
                            Packet adminPkt = new Packet("Response", "POST", "AdminCache", AdminData);
                            ServerManager.SendMessage(adminPkt, client);
                            adminPkt = null;
                            break;
                        case "EmployeeCache":
                            string EmployeeData = JsonSerializer.Serialize(CacheManager.Instance.EmployeeCache);
                            Packet empPkt= new Packet("Response", "POST", "EmployeeCache", EmployeeData);
                            ServerManager.SendMessage(empPkt, client);
                            empPkt = null;
                            break;
                    }
                    break;

                    //case "POST":
                    //    switch (dataType)
                    //    {
                    //        case "AdminCache":
                    //            CacheManager.Instance.AdminCache = JsonSerializer.Deserialize<ObservableCollection<Admin>>(dataPayload);
                    //            break;
                    //        case "EmployeeCache":
                    //            CacheManager.Instance.EmployeeCache = JsonSerializer.Deserialize<ObservableCollection<Employee>>(dataPayload);
                    //            break;

                    //    }
                    //    break;


            }

            //string data=null;
            //if(this.type == "request" && this.dataType == "AdminCache")
            //{
            //     data = JsonSerializer.Serialize(cm.AdminCache);
            //     ServerManager.SendMessage(new Packet("Response", "POST", "AdminCache",data), client);
            //}
            return;
        }
    }
}
