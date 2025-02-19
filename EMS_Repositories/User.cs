using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace EMS_Repositories
{
    public enum userRoles
    {
        Unassigned,
        Employee,
        Admin
    }
    [Serializable]
    public class User
    {
        [XmlElement]
        public int Id { get; set; }
        [XmlElement]
        public string Pwd { get; set; }

        [XmlElement]
        public string Name { get; set; }

        [XmlElement]
        public string Gender { get; set; }

        [XmlElement]
        public string Email { get; set; }

        [XmlElement]
        public string Phone { get; set; }

        [XmlElement]
        public string Address { get; set; }

        [XmlElement]
        public DateTime Dob { get; set; }

        [XmlElement]
        public string Religion { get; set; }

        [XmlElement]
        public string MaritalStatus { get; set; }
        [XmlElement]
        public string? Designation { get; set; }
        [XmlElement]
        public string? Department { get; set; }
        [XmlElement]
        public userRoles Role { get; set; }
        [XmlElement]
        public double? Salary { get; set; }
        [XmlElement]
        public Attendance Attendance { get; set; }
        [XmlElement]
        public Leaves Leaves { get; set; }

        //[XmlElement]
        //public Request m_request { get; set; }

        [XmlElement]
        public bool isAuthentic { get; set; }

    }
}
