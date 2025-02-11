using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using EMS_CacheManager;
using EMS_Repositories;

namespace EMS_Server
{
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


        public void HandleRequest(Client client, Packet pkt)
        {

            if (pkt.method == MethodType.GET)
            {
                if (pkt.dataType == CacheType.Admin)
                {
                    string AdminData = JsonSerializer.Serialize(CacheManager.Instance.AdminCache);
                    Packet adminPkt = new Packet("Response", MethodType.POST, CacheType.Admin, AdminData);
                    //ServerManager.SendMessage(AdminData, "AdminCache", client);
                    ServerManager.SendMessage(adminPkt, client);
                }
                else if (pkt.dataType == CacheType.Employee)
                {
                    string EmployeeData = JsonSerializer.Serialize(CacheManager.Instance.EmployeeCache);
                    Packet empPkt = new Packet("Response", MethodType.POST, CacheType.Employee, EmployeeData);
                    ServerManager.SendMessage(empPkt, client);
                }
                else if (pkt.dataType == CacheType.Request)
                {
                    string ReqData = JsonSerializer.Serialize(CacheManager.Instance.RequestsCache);
                    Packet reqPkt = new Packet("Response", MethodType.POST, CacheType.Request, ReqData);
                    ServerManager.SendMessage(reqPkt, client);
                }
                else if (pkt.dataType == CacheType.All)
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
            else if (pkt.method == MethodType.POST)
            {
                if (pkt.dataType == CacheType.Admin)
                {
                    Admin recd_admin = JsonSerializer.Deserialize<Admin>(pkt.dataPayload);
                    CacheManager.Instance.updateCache(recd_admin, pkt.type);
                    Debug.WriteLine(CacheManager.Instance.AdminCache);
                }
                else if (pkt.dataType == CacheType.Employee)
                {
                    Employee recd_emp = JsonSerializer.Deserialize<Employee>(pkt.dataPayload);
                    CacheManager.Instance.updateCache(recd_emp, pkt.type);
                    Debug.WriteLine(CacheManager.Instance.EmployeeCache);
                }
                else if (pkt.dataType == CacheType.Request)
                {
                    Request recd_req = JsonSerializer.Deserialize<Request>(pkt.dataPayload);
                    CacheManager.Instance.updateCache(recd_req, pkt.type);
                    Debug.WriteLine(CacheManager.Instance.RequestsCache);
                }
            }

            return;


        }
    }
}
