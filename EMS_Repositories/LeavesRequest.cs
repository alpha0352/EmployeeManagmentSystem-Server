using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace EMS_Repositories
{
    public enum LeaveType
    {
        Casual,
        Sick,
        Annual
    }
    public class LeavesRequest
    {
        [XmlElement]
        public LeaveType m_enLeaveType { get; set; }
        [XmlElement]
        public int m_nNoOfDays { get; set; }
        [XmlElement]
        public DateTime m_dtStartDate { get; set; }
        [XmlElement]
        public DateTime m_dtEndDate { get; set; }
        [XmlElement]
        public string m_stReason { get; set; }

        public LeavesRequest()
        {
     
        }
        public LeavesRequest(LeaveType typeofleave,int noOfDays,DateTime start,DateTime end,string reason)
        {

            //this.m_approveddate = DateTime.Now;

            this.m_enLeaveType = typeofleave;
            this.m_nNoOfDays = noOfDays;
            this.m_dtStartDate = start;
            this.m_dtEndDate = end;
            this.m_stReason = reason;

        }

        public LeavesRequest(LeavesRequest other)
        {
            this.m_enLeaveType = other.m_enLeaveType;
            this.m_nNoOfDays = other.m_nNoOfDays;
            this.m_dtStartDate = other.m_dtStartDate;
            this.m_dtEndDate = other.m_dtEndDate;
            this.m_stReason = other.m_stReason;
        }

    }
}
