using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS_Repositories
{
    public enum CacheType
    {
        All,
        Request,
        Employee,
        Admin
    }
    public enum MethodType { GET,POST,PUT }

    public class Packet
    {
        public string m_stType { get; set; }    // Request/Response
        public MethodType m_enMethod { get; set; } // GET/POST
        public CacheType m_enDataType { get; set; }    // AdminCache/EmployeeCache
        public string m_stDataPayload { get; set; }    // JSON data

        public Packet(string m_stType, MethodType m_enMethod, CacheType m_enDataType, string m_stDataPayload)
        {
            this.m_stType = m_stType;
            this.m_enMethod = m_enMethod;
            this.m_enDataType = m_enDataType;
            this.m_stDataPayload = m_stDataPayload;
        }
    }
}
