using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS_Repositories
{
    public class SignupRequest : Request
    {

        public SignupRequest()
        {
            
        }
        public SignupRequest(int reqId, string reqType)
        {
            this.ReqID = reqId;
            this.ReqStatus = RequestStatus.Pending;
            this.RequestDate = DateTime.Now;
            //this.ApprovedDate = DateTime.Now;
        }
        public SignupRequest(SignupRequest other)
        {
            this.ReqID = other.ReqID;
            this.ReqStatus = other.ReqStatus;
            this.RequestDate = other.RequestDate;
            //this.ApprovedDate = DateTime.Now;
        }
    }
}
