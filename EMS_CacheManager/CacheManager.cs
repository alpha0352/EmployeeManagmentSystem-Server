using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        private xmlSerializer xmlHandler = new xmlSerializer();
        private CacheManager()
        {
            this.AdminCache = xmlHandler.Deserialize<ObservableCollection<Admin>>();
            this.EmployeeCache = xmlHandler.Deserialize<ObservableCollection<Employee>>();
        }

        public void SaveCache()
        {
            xmlHandler.Serialize(this.AdminCache);
            xmlHandler.Serialize(this.EmployeeCache);
        }

        
    }
}
