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
    public class User : ModelBase
    {
        [XmlElement]
        public int m_nId { get; set; }
        [XmlElement]
        public string m_stPwd { get; set; }

        [XmlElement]
        public string m_stName { get; set; }

        [XmlElement]
        public string m_stGender { get; set; }

        [XmlElement]
        public string m_stEmail { get; set; }

        [XmlElement]
        public string m_stPhone { get; set; }

        [XmlElement]
        public string m_stAddress { get; set; }

        [XmlElement]
        public DateTime m_dtDob { get; set; }

        [XmlElement]
        public string m_stReligion { get; set; }

        [XmlElement]
        public string m_stMaritalStatus { get; set; }
        [XmlElement]
        public string? m_stDesignation { get; set; }
        [XmlElement]
        public string? m_stDepartment { get; set; }
        [XmlElement]
        public userRoles m_enRole { get; set; }
        [XmlElement]
        public double? m_dSalary { get; set; }
        [XmlElement]
        public Attendance m_attendance { get; set; }
        [XmlElement]
        public Leaves m_leaves { get; set; }

        //[XmlElement]
        //public Request m_request { get; set; }

        [XmlElement]
        public bool m_bIsAuthentic { get; set; }

    }
}
