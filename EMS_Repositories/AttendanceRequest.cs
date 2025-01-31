using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace EMS_Repositories
{
    public  class AttendanceRequest
    {
        [XmlElement]
        public DateTime m_attendanceDate { get; set; }
        [XmlElement]
        public DateTime m_indate { get; set; }
        [XmlElement]
        public DateTime m_intime { get; set; }
        [XmlElement]
        public DateTime m_outdate { get; set; }
        [XmlElement]
        public DateTime m_outtime { get; set; }
        [XmlElement]
        public string m_reason { get; set; }

        public AttendanceRequest()
        {
        }
        public AttendanceRequest( DateTime attendanceDate, DateTime InDate, DateTime InTime, DateTime OutDate, DateTime OutTime,string reason)
        {

            this.m_attendanceDate = attendanceDate;
            this.m_outdate = OutDate;
            this.m_outtime = OutTime;
            this.m_indate = InDate;
            this.m_intime = InTime;
            this.m_reason = reason;
        }
    }
}
