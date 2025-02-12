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
        public string type { get; set; }    // Request/Response
        public MethodType method { get; set; } // GET/POST
        public CacheType dataType { get; set; }    // AdminCache/EmployeeCache
        public string dataPayload { get; set; }    // JSON data

        public Packet(string type, MethodType method, CacheType datatype, string datapayload)
        {
            this.type = type;
            this.method = method;
            this.dataType = datatype;
            this.dataPayload = datapayload;
        }
    }
}
