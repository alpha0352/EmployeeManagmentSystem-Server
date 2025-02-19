using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using EMS_CacheManager;
using EMS_Repositories;

namespace EMS_Server
{
    public class PacketHandler : IDisposable
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


        public void HandleRequest(Client client, Packet pkt)
        {

            if (pkt.Method == MethodType.GET)
            {
                if (pkt.DataType == CacheType.Admin)
                {
                    string AdminData = JsonSerializer.Serialize(CacheManager.Instance.AdminCache);
                    Packet adminPkt = new Packet("Response", MethodType.POST, CacheType.Admin, AdminData);
                    //ServerManager.SendMessage(AdminData, "AdminCache", client);
                    ServerManager.SendMessage(adminPkt, client);
                }
                else if (pkt.DataType == CacheType.Employee)
                {
                    string EmployeeData = JsonSerializer.Serialize(CacheManager.Instance.EmployeeCache);
                    Packet empPkt = new Packet("Response", MethodType.POST, CacheType.Employee, EmployeeData);
                    ServerManager.SendMessage(empPkt, client);
                }
                else if (pkt.DataType == CacheType.Request)
                {
                    string ReqData = JsonSerializer.Serialize(CacheManager.Instance.RequestsCache);
                    Packet reqPkt = new Packet("Response", MethodType.POST, CacheType.Request, ReqData);
                    ServerManager.SendMessage(reqPkt, client);
                }
                else if (pkt.DataType == CacheType.All)
                {
                    Dictionary <CacheType, string> AllCache = new Dictionary<CacheType, string>(); 

                    string EmployeeData = JsonSerializer.Serialize(CacheManager.Instance.EmployeeCache);
                    AllCache.Add(CacheType.Employee, EmployeeData);

                    string AdminData = JsonSerializer.Serialize(CacheManager.Instance.AdminCache);
                    AllCache.Add(CacheType.Admin, AdminData);

                    string ReqData = JsonSerializer.Serialize(CacheManager.Instance.RequestsCache);
                    AllCache.Add(CacheType.Request,ReqData);

                    string allCache = JsonSerializer.Serialize(AllCache);
                    Packet AllPkt = new Packet("Response", MethodType.POST, CacheType.All, allCache);
                    ServerManager.SendMessage(AllPkt, client);

                }
            }
            else if (pkt.Method == MethodType.POST)
            {
                if (pkt.DataType == CacheType.All) return;

                else if (pkt.DataType == CacheType.Admin)
                {
                    Admin recd_admin = JsonSerializer.Deserialize<Admin>(pkt.m_stDataPayload);
                    CacheManager.Instance.updateCache(recd_admin, pkt.Type);
                    
                    Debug.WriteLine("Updated Admin Cache");
                }
                else if (pkt.DataType == CacheType.Employee)
                {
                    Employee recd_emp = JsonSerializer.Deserialize<Employee>(pkt.m_stDataPayload);
                    CacheManager.Instance.updateCache(recd_emp, pkt.Type);
                    Debug.WriteLine("Updated Employee Cache");
                }
                else if (pkt.DataType == CacheType.Request)
                {
                    Request recd_req = JsonSerializer.Deserialize<Request>(pkt.m_stDataPayload);
                    CacheManager.Instance.updateCache(recd_req, pkt.Type);
                    Debug.WriteLine("Updated Request Cache");
                }
                ServerManager.BroadcastUpdates(pkt,client);
            }
            else if(pkt.Method == MethodType.PUT)
            {
                Dictionary<CacheType, string> allCache = JsonSerializer.Deserialize<Dictionary<CacheType, string>>(pkt.m_stDataPayload);

                CacheManager.Instance.EmployeeCache = JsonSerializer.Deserialize<ObservableCollection<Employee>>(allCache[CacheType.Employee]);
                CacheManager.Instance.AdminCache = JsonSerializer.Deserialize<ObservableCollection<Admin>>(allCache[CacheType.Admin]);
                CacheManager.Instance.RequestsCache = JsonSerializer.Deserialize<ObservableCollection<Request>>(allCache[CacheType.Request]);
            }


            return;


        }

        public void Dispose()
        {
            Console.WriteLine("Disposed!");
            if (isSubscribed) 
            {
                ServerManager.msgRecieved -= HandleRequest;
                isSubscribed = false;
            }
        }
    }
}
