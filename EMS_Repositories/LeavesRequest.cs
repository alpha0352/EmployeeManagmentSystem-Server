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
        public LeaveType LeaveType { get; set; }
        [XmlElement]
        public int NoOfDays { get; set; }
        [XmlElement]
        public DateTime StartDate { get; set; }
        [XmlElement]
        public DateTime EndDate { get; set; }
        [XmlElement]
        public string Reason { get; set; }

        public LeavesRequest()
        {
     
        }
        public LeavesRequest(LeaveType typeofleave,int noOfDays,DateTime start,DateTime end,string reason)
        {

            //this.ApprovedDate = DateTime.Now;

            this.LeaveType = typeofleave;
            this.NoOfDays = noOfDays;
            this.StartDate = start;
            this.EndDate = end;
            this.Reason = reason;

        }

        public LeavesRequest(LeavesRequest other)
        {
            this.LeaveType = other.LeaveType;
            this.NoOfDays = other.NoOfDays;
            this.StartDate = other.StartDate;
            this.EndDate = other.EndDate;
            this.Reason = other.Reason;
        }

    }
}
