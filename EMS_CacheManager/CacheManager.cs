using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using System.Xml.Serialization;
using EMS_Repositories;
using EMS_ServerUtilities;

namespace EMS_CacheManager
{
    public class CacheManager
    {
        private static CacheManager m_instance;

        public static CacheManager Instance
        {
            get
            {
                if (m_instance == null)
                {
                    m_instance = new CacheManager();
                }
                return m_instance;
            }
        }

        public ObservableCollection<Admin> AdminCache { get; set; }
        public ObservableCollection<Employee> EmployeeCache { get; set; }
        public ObservableCollection<Request> RequestsCache { get; set; }

        private xmlSerializer xmlHandler = new xmlSerializer();
        private CacheManager()
        {
            this.AdminCache = xmlHandler.Deserialize<ObservableCollection<Admin>>();
            this.EmployeeCache = xmlHandler.Deserialize<ObservableCollection<Employee>>();
            this.RequestsCache = xmlHandler.Deserialize<ObservableCollection<Request>>();
        }
        public void updateCache<T>(T temp_obj,string action)
        {
            if (temp_obj is Employee emp)
            {
                switch (action)
                {
                    case "ADD":
                        EmployeeCache.Add((Employee)(object)temp_obj);
                        break;
                    case "UPDATE":

                        Employee TempEmp = EmployeeCache.FirstOrDefault(Employee => Employee.m_nId == emp.m_nId);

                        if(TempEmp == null)
                        {
                            TempEmp = EmployeeCache.FirstOrDefault(Employee => Employee.m_stEmail == emp.m_stEmail && Employee.m_stName == emp.m_stName);
                        }

                        TempEmp.UpdateFrom(emp);

                        break;

                    case "DELETE":

                        var itemToRemove = EmployeeCache.Where(e => e.m_nId == emp.m_nId).SingleOrDefault();
                        if (itemToRemove != null)
                        {
                            EmployeeCache.Remove(itemToRemove);
                        }
                        break;
                }
            }
            else if (temp_obj is Admin temp_admin)
            {
                switch (action)
                {
                    case "ADD":
                        AdminCache.Add((Admin)(object)temp_obj);
                        
                        break;
                    case "UPDATE":

                        Admin EditAdmin = AdminCache.FirstOrDefault(Admin => Admin.m_nId == temp_admin.m_nId);

                        //adminToEdit.m_nId = (int)obj;
                        //EditAdmin.m_stName = temp_admin.m_stName;
                        //EditAdmin.m_stPwd = temp_admin.m_stPwd;
                        //EditAdmin.m_stDesignation = temp_admin.m_stDesignation;
                        //EditAdmin.m_enRole = temp_admin.m_enRole;
                        //EditAdmin.m_dSalary = temp_admin.m_dSalary;
                        //EditAdmin.m_leaves.m_nSickLeaves = temp_admin.m_leaves.m_nSickLeaves;
                        //EditAdmin.m_leaves.m_nCasualLeaves = temp_admin.m_leaves.m_nCasualLeaves;
                        //EditAdmin.m_leaves.m_nTotalAvailedLeaves = temp_admin.m_leaves.m_nTotalAvailedLeaves;
                        //EditAdmin.m_leaves.m_nBalanceLeaves = temp_admin.m_leaves.m_nBalanceLeaves;
                        EditAdmin.UpdateFrom(temp_admin);

                        break;

                    case "DELETE":

                        var itemToRemove = AdminCache.Where(e => e.m_nId == temp_admin.m_nId).SingleOrDefault();
                        if (itemToRemove != null)
                        {
                            AdminCache.Remove(itemToRemove);
                            
                        }
                        break;
                }
            }
            else if (temp_obj is Request temp_request)
            {
                switch (action)
                {
                    case "ADD":
                        RequestsCache.Add((Request)(object)temp_obj);
                        break;
                    case "UPDATE":

                        Request EditRequest = RequestsCache.FirstOrDefault(req => req.m_reqID == temp_request.m_reqID);

                        //adminToEdit.m_nId = (int)obj;

                        EditRequest.UpdateFrom(temp_request);

                        break;

                    case "DELETE":

                        var itemToRemove = RequestsCache.Where(r => r.m_reqID == temp_request.m_reqID).SingleOrDefault();
                        if (itemToRemove != null)
                        {
                            RequestsCache.Remove(itemToRemove);
                            
                        }
                        break;
                }
            }
            else
            {
                Debug.WriteLine("Invalid m_enDataType");
            }
        }

        public void SaveCache()
        {
            xmlHandler.Serialize(this.AdminCache);
            xmlHandler.Serialize(this.EmployeeCache);
            xmlHandler.Serialize(this.RequestsCache);
        }

        
    }
}
