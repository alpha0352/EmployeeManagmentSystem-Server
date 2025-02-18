using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace EMS_Repositories
{
    public enum RequestType
    {
        Attendance,
        Leaves,
        Signup
    }

    public enum RequestStatus
    {
        Pending,
        Approved,
        Rejected
    }
    public class Request : ModelBase
    {
        [XmlElement]
        public int m_reqID { get; set; }
        
        [XmlElement]
        public RequestType m_reqType { get; set; } //Signup/Leaves/Attendance
        
        [XmlElement]
        public RequestStatus m_reqStatus { get; set; } //Pending/Approved/Rejected
        
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

        // create different constructors for each m_stType of request
        public Request(int reqId, int raisedby) //contructor for Signup request.
        {
            this.m_reqID = reqId;
            this.m_reqType = RequestType.Signup;
            this.m_reqStatus = RequestStatus.Pending;
            this.m_raisedBy = raisedby;
            this.m_requestdate = DateTime.Now;
        }
        public Request(Request other)
        {
            if (other == null) throw new ArgumentNullException(nameof(other));

            m_reqID = other.m_reqID;
            m_reqType = other.m_reqType;
            m_reqStatus = other.m_reqStatus;
            m_raisedBy = other.m_raisedBy;
            m_approvedBy = other.m_approvedBy;
            m_requestdate = other.m_requestdate;
            m_approveddate = other.m_approveddate;

            // Perform deep copies if needed
            m_leaverequest = other.m_leaverequest != null ? new LeavesRequest(other.m_leaverequest) : null; ;
            m_attendancerequest = other.m_attendancerequest != null ? new AttendanceRequest(other.m_attendancerequest) : null;
            m_signuprequest = other.m_signuprequest != null ? new SignupRequest(other.m_signuprequest) : null;
        
        }

        public void UpdateFrom(Request other)
        {
            if (other == null) throw new ArgumentNullException(nameof(other));

            m_reqID = other.m_reqID;
            m_reqType = other.m_reqType;
            m_reqStatus = other.m_reqStatus;
            m_raisedBy = other.m_raisedBy;
            m_approvedBy = other.m_approvedBy;
            m_requestdate = other.m_requestdate;
            m_approveddate = other.m_approveddate;

            // Perform deep copies if needed
            m_leaverequest = other.m_leaverequest != null ? other.m_leaverequest : null;
            m_attendancerequest = other.m_attendancerequest != null ? other.m_attendancerequest : null;
            m_signuprequest = other.m_signuprequest != null ? other.m_signuprequest : null;
        }

    }
}
