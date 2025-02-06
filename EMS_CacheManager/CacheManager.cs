using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

                        Employee TempEmp = EmployeeCache.FirstOrDefault(Employee => Employee.m_Id == emp.m_Id);

                        if(TempEmp == null)
                        {
                            TempEmp = EmployeeCache.FirstOrDefault(Employee => Employee.m_email == emp.m_email && Employee.m_name == emp.m_name);
                        }

                        TempEmp.UpdateFrom(emp);

                        break;

                    case "DELETE":

                        var itemToRemove = EmployeeCache.Where(e => e.m_Id == emp.m_Id).SingleOrDefault();
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

                        Admin EditAdmin = AdminCache.FirstOrDefault(Admin => Admin.m_Id == temp_admin.m_Id);

                        //adminToEdit.m_Id = (int)obj;
                        //EditAdmin.m_name = temp_admin.m_name;
                        //EditAdmin.m_pwd = temp_admin.m_pwd;
                        //EditAdmin.m_designation = temp_admin.m_designation;
                        //EditAdmin.m_role = temp_admin.m_role;
                        //EditAdmin.m_salary = temp_admin.m_salary;
                        //EditAdmin.m_leaves.m_SickLeaves = temp_admin.m_leaves.m_SickLeaves;
                        //EditAdmin.m_leaves.m_CasualLeaves = temp_admin.m_leaves.m_CasualLeaves;
                        //EditAdmin.m_leaves.m_TotalAvailedLeaves = temp_admin.m_leaves.m_TotalAvailedLeaves;
                        //EditAdmin.m_leaves.m_BalanceLeaves = temp_admin.m_leaves.m_BalanceLeaves;
                        EditAdmin.UpdateFrom(temp_admin);

                        break;

                    case "DELETE":

                        var itemToRemove = AdminCache.Where(e => e.m_Id == temp_admin.m_Id).SingleOrDefault();
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

                        //adminToEdit.m_Id = (int)obj;

                        EditRequest.m_reqStatus = temp_request.m_reqStatus;
                        EditRequest.m_approvedBy = temp_request.m_approvedBy;
                        EditRequest.m_approveddate = temp_request.m_approveddate;

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
