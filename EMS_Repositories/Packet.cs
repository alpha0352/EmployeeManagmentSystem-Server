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
        public string Type { get; set; }    // Request/Response
        public MethodType Method { get; set; } // GET/POST
        public CacheType DataType { get; set; }    // AdminCache/EmployeeCache
        public string m_stDataPayload { get; set; }    // JSON data

        public Packet(string Type, MethodType Method, CacheType DataType, string m_stDataPayload)
        {
            this.Type = Type;
            this.Method = Method;
            this.DataType = DataType;
            this.m_stDataPayload = m_stDataPayload;
        }
    }
}
