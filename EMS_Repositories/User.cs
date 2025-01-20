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
    [Serializable]
    public class User : ModelBase
    {
        [XmlElement]
        public int m_Id { get; set; }
        [XmlElement]
        public string m_pwd { get; set; }
        [XmlElement]
        public string m_name { get; set; }
        [XmlElement]
        public string m_designation {  get; set; }
        [XmlElement]
        public string m_role { get; set; }
        [XmlElement]
        public double m_salary { get; set; }
        [XmlElement]
        public Attendance m_attendance { get; set; }
        [XmlElement]
        public Leaves m_leaves { get; set; }


    }
}
