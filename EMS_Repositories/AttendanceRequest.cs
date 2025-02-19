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
        public AttendanceType AttendanceType { get; set; }
        [XmlElement]
        public DateTime AttendanceDate { get; set; }
        [XmlElement]
        public DateTime InDate { get; set; }
        [XmlElement]
        public DateTime InTime { get; set; }
        [XmlElement]
        public DateTime OutDate { get; set; }
        [XmlElement]
        public DateTime OutTime { get; set; }
        [XmlElement]
        public string Reason { get; set; }

        public AttendanceRequest()
        {
        }
        public AttendanceRequest(AttendanceType attType, DateTime attendanceDate, DateTime InDate, DateTime InTime, DateTime OutDate, DateTime OutTime,string reason)
        {
            this.AttendanceType = attType;
            this.AttendanceDate = attendanceDate;
            this.OutDate = OutDate;
            this.OutTime = OutTime;
            this.InDate = InDate;
            this.InTime = InTime;
            this.Reason = reason;
        }

        public AttendanceRequest(AttendanceRequest other)
        {
            this.AttendanceType = other.AttendanceType;
            this.AttendanceDate = other.AttendanceDate;
            this.OutDate = other.OutDate;
            this.OutTime = other.OutTime;
            this.InDate = other.InDate;
            this.InTime = other.InTime;
            this.Reason = other.Reason;
        }
    }
}
