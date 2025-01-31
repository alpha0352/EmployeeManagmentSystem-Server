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
            this.m_reqID = reqId;
            this.m_reqStatus = "Pending";
            this.m_requestdate = DateTime.Now;
            //this.m_approveddate = DateTime.Now;
        }
    }
}
