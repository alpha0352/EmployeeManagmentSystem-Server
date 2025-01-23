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
        private int _m_id;
        [XmlElement]
        public int m_Id
        {
            get { return _m_id; }
            set
            {
                _m_id = value;
                OnPropertyChanged(nameof(m_Id));
            }
        }

        private string _m_pwd;
        [XmlElement]
        public string m_pwd
        {
            get { return _m_pwd; }
            set
            {
                _m_pwd = value;
                OnPropertyChanged(nameof(m_pwd));
            }
        }

        private string _m_name;
        [XmlElement]
        public string m_name
        {
            get { return _m_name; }
            set
            {
                _m_name = value;
                OnPropertyChanged(nameof(m_name));
            }
        }

        private string _m_designation;
        [XmlElement]
        public string m_designation
        {
            get { return _m_designation; }
            set
            {
                _m_designation = value;
                OnPropertyChanged(nameof(m_designation));
            }
        }

        private string _m_role;
        [XmlElement]
        public string m_role
        {
            get { return _m_role; }
            set
            {
                _m_role = value;
                OnPropertyChanged(nameof(m_role));
            }
        }

        private double _m_salary;
        [XmlElement]
        public double m_salary
        {
            get { return _m_salary; }
            set
            {
                _m_salary = value;
                OnPropertyChanged(nameof(m_salary));
            }
        }

        private Attendance _m_attendance;
        [XmlElement]
        public Attendance m_attendance
        {
            get { return _m_attendance; }
            set
            {
                _m_attendance = value;
                OnPropertyChanged(nameof(m_attendance));
            }
        }

        private Leaves _m_leaves;
        [XmlElement]
        public Leaves m_leaves
        {
            get { return _m_leaves; }
            set
            {
                _m_leaves = value;
                OnPropertyChanged(nameof(m_leaves));
            }
        }
    }
}
