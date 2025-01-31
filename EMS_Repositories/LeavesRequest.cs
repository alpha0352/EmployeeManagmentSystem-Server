using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace EMS_Repositories
{
    public class LeavesRequest
    {
        [XmlElement]
        public string m_leaveType { get; set; }
        [XmlElement]
        public int m_noOfDays { get; set; }
        [XmlElement]
        public DateTime m_startDate { get; set; }
        [XmlElement]
        public DateTime m_endDate { get; set; }
        [XmlElement]
        public string m_reason { get; set; }

        public LeavesRequest()
        {
            
        }
        public LeavesRequest(string typeofleave,int noOfDays,DateTime start,DateTime end,string reason)
        {

            //this.m_approveddate = DateTime.Now;

            this.m_leaveType = typeofleave;
            this.m_noOfDays = noOfDays;
            this.m_startDate = start;
            this.m_endDate = end;
            this.m_reason = reason;

        }

    }
}
