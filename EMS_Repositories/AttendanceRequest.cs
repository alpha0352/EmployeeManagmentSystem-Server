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
        public DateTime m_dtAttendanceDate { get; set; }
        [XmlElement]
        public DateTime m_dtInDate { get; set; }
        [XmlElement]
        public DateTime m_dtInTime { get; set; }
        [XmlElement]
        public DateTime m_dtOutDate { get; set; }
        [XmlElement]
        public DateTime m_dtOutTime { get; set; }
        [XmlElement]
        public string m_stReason { get; set; }

        public AttendanceRequest()
        {
        }
        public AttendanceRequest(AttendanceType attType, DateTime attendanceDate, DateTime InDate, DateTime InTime, DateTime OutDate, DateTime OutTime,string reason)
        {
            this.m_attendancetype = attType;
            this.m_dtAttendanceDate = attendanceDate;
            this.m_dtOutDate = OutDate;
            this.m_dtOutTime = OutTime;
            this.m_dtInDate = InDate;
            this.m_dtInTime = InTime;
            this.m_stReason = reason;
        }

        public AttendanceRequest(AttendanceRequest other)
        {
            this.m_attendancetype = other.m_attendancetype;
            this.m_dtAttendanceDate = other.m_dtAttendanceDate;
            this.m_dtOutDate = other.m_dtOutDate;
            this.m_dtOutTime = other.m_dtOutTime;
            this.m_dtInDate = other.m_dtInDate;
            this.m_dtInTime = other.m_dtInTime;
            this.m_stReason = other.m_stReason;
        }
    }
}
