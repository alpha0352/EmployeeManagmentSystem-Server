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
    public class Request
    {
        [XmlElement]
        public int ReqID { get; set; }
        
        [XmlElement]
        public RequestType ReqType { get; set; } //Signup/Leaves/Attendance
        
        [XmlElement]
        public RequestStatus ReqStatus { get; set; } //Pending/Approved/Rejected
        
        [XmlElement]
        public int? RaisedBy { get; set; } //User ID
        
        [XmlElement]
        public int? ApprovedBy { get; set; } //Admin ID

        [XmlElement]
        public DateTime RequestDate { get; set; }

        [XmlElement]
        public DateTime? ApprovedDate { get; set; }

        [XmlElement]
        public LeavesRequest LeaveRequest { get; set; }
        
        [XmlElement]
        public AttendanceRequest AttendanceRequest { get; set; }
        
        public SignupRequest SigupRequest { get; set; }
        public Request()
        {

        }

        // create different constructors for each Type of request
        public Request(int reqID, int raisedby) //contructor for Signup request.
        {
            this.ReqID = reqID;
            this.ReqType = RequestType.Signup;
            this.ReqStatus = RequestStatus.Pending;
            this.RaisedBy = raisedby;
            this.RequestDate = DateTime.Now;
        }
        public Request(Request other)
        {
            if (other == null) throw new ArgumentNullException(nameof(other));

            ReqID = other.ReqID;
            ReqType = other.ReqType;
            ReqStatus = other.ReqStatus;
            RaisedBy = other.RaisedBy;
            ApprovedBy = other.ApprovedBy;
            RequestDate = other.RequestDate;
            ApprovedDate = other.ApprovedDate;

            // Perform deep copies if needed
            LeaveRequest = other.LeaveRequest != null ? new LeavesRequest(other.LeaveRequest) : null; ;
            AttendanceRequest = other.AttendanceRequest != null ? new AttendanceRequest(other.AttendanceRequest) : null;
            SigupRequest = other.SigupRequest != null ? new SignupRequest(other.SigupRequest) : null;
        
        }

        public void UpdateFrom(Request other)
        {
            if (other == null) throw new ArgumentNullException(nameof(other));

            ReqID = other.ReqID;
            ReqType = other.ReqType;
            ReqStatus = other.ReqStatus;
            RaisedBy = other.RaisedBy;
            ApprovedBy = other.ApprovedBy;
            RequestDate = other.RequestDate;
            ApprovedDate = other.ApprovedDate;

            // Perform deep copies if needed
            LeaveRequest = other.LeaveRequest != null ? other.LeaveRequest : null;
            AttendanceRequest = other.AttendanceRequest != null ? other.AttendanceRequest : null;
            SigupRequest = other.SigupRequest != null ? other.SigupRequest : null;
        }

    }
}
