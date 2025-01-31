using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace EMS_Repositories
{
    public class Request : ModelBase
    {
        [XmlElement]
        public int m_reqID { get; set; }
        
        [XmlElement]
        public string m_reqType { get; set; } //Signup/Leaves/Attendance
        
        [XmlElement]
        public string m_reqStatus { get; set; } //Pending/Approved/Rejected
        
        [XmlElement]
        public int? m_raisedBy { get; set; } //User ID
        
        [XmlElement]
        public int? m_approvedBy { get; set; } //Admin ID

        [XmlElement]
        public DateTime m_requestdate { get; set; }

        [XmlElement]
        public DateTime? m_approveddate { get; set; }

        [XmlElement]
        public LeavesRequest m_leaverequest { get; set; }
        
        [XmlElement]
        public AttendanceRequest m_attendancerequest { get; set; }
        
        public SignupRequest m_signuprequest { get; set; }
        public Request()
        {
        }

        // create different constructors for each type of request
        public Request(int reqId, string reqType, int raisedby) //contructor for Signup request.
        {
            this.m_reqID = reqId;
            this.m_reqType = reqType;
            this.m_reqStatus = "Pending";
            this.m_raisedBy = raisedby;
            this.m_requestdate = DateTime.Now;
        }
    }
}
