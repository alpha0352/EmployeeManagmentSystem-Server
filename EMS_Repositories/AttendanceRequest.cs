using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Microsoft.VisualBasic;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EMS_Repositories
{
    public enum AttendanceType
    {
        Late,
        HalfDay,
        EarlyLeave 
    }
    public  class AttendanceRequest
    {
        [XmlElement]
        public AttendanceType m_attendancetype { get; set; }
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
        public AttendanceRequest(AttendanceType attType, DateTime attendanceDate, DateTime InDate, DateTime InTime, DateTime OutDate, DateTime OutTime,string reason)
        {
            this.m_attendancetype = attType;
            this.m_attendanceDate = attendanceDate;
            this.m_outdate = OutDate;
            this.m_outtime = OutTime;
            this.m_indate = InDate;
            this.m_intime = InTime;
            this.m_reason = reason;
        }

        public AttendanceRequest(AttendanceRequest other)
        {
            this.m_attendancetype = other.m_attendancetype;
            this.m_attendanceDate = other.m_attendanceDate;
            this.m_outdate = other.m_outdate;
            this.m_outtime = other.m_outtime;
            this.m_indate = other.m_indate;
            this.m_intime = other.m_intime;
            this.m_reason = other.m_reason;
        }
    }
}
