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
                if (m_instance == null) m_instance = new CacheManager();
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
                        EmployeeCache.Add((Employee)(object)emp);
                        break;
                    case "UPDATE":

                        Employee TempEmp = EmployeeCache.FirstOrDefault(Employee => Employee.Id == emp.Id);

                        if(TempEmp == null)
                        {
                            TempEmp = EmployeeCache.FirstOrDefault(Employee => Employee.Email == emp.Email && Employee.Name == emp.Name);
                        }

                        TempEmp.UpdateFrom(emp);

                        break;

                    case "DELETE":

                        var itemToRemove = EmployeeCache.Where(e => e.Id == emp.Id).SingleOrDefault();
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
                        AdminCache.Add((Admin)(object)temp_admin);
                        
                        break;
                    case "UPDATE":

                        Admin EditAdmin = AdminCache.FirstOrDefault(Admin => Admin.Id == temp_admin.Id);

                        //adminToEdit.Id = (int)obj;
                        //EditAdmin.Name = temp_admin.Name;
                        //EditAdmin.Pwd = temp_admin.Pwd;
                        //EditAdmin.Designation = temp_admin.Designation;
                        //EditAdmin.Role = temp_admin.Role;
                        //EditAdmin.Salary = temp_admin.Salary;
                        //EditAdmin.Leaves.SickLeaves = temp_admin.Leaves.SickLeaves;
                        //EditAdmin.Leaves.CasualLeaves = temp_admin.Leaves.CasualLeaves;
                        //EditAdmin.Leaves.AvailedLeaves = temp_admin.Leaves.AvailedLeaves;
                        //EditAdmin.Leaves.BalanceLeaves = temp_admin.Leaves.BalanceLeaves;
                        EditAdmin.UpdateFrom(temp_admin);

                        break;

                    case "DELETE":

                        var itemToRemove = AdminCache.Where(e => e.Id == temp_admin.Id).SingleOrDefault();
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
                        RequestsCache.Add((Request)(object)temp_request);
                        break;
                    case "UPDATE":

                        Request EditRequest = RequestsCache.FirstOrDefault(req => req.ReqID == temp_request.ReqID);

                        //adminToEdit.Id = (int)obj;

                        EditRequest.UpdateFrom(temp_request);

                        break;

                    case "DELETE":

                        var itemToRemove = RequestsCache.Where(r => r.ReqID == temp_request.ReqID).SingleOrDefault();
                        if (itemToRemove != null)
                        {
                            RequestsCache.Remove(itemToRemove);
                            
                        }
                        break;
                }
            }
            else
            {
                Debug.WriteLine("Invalid DataType");
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
