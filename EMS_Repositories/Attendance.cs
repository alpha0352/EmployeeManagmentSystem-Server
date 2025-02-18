using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace EMS_Repositories
{
    public class Attendance
    {
        public bool m_bIsPresent { get; set; }
        public int m_nPresentDays { get; set; }
        public int m_nAbsentDays { get; set; }
        public int m_nHalfDays { get; set; }
        public int m_nLate { get; set; }
        public int m_nEarlyLeave { get; set; }

        public Attendance() { }
        public Attendance(bool ispres, int presDays,int absDays, int halfDays, int late,int earlyleaves)
        {
            m_bIsPresent = ispres;
            m_nPresentDays = presDays;
            m_nAbsentDays = absDays;
            m_nHalfDays = halfDays;
            m_nLate = late;
            m_nEarlyLeave = earlyleaves;

        }

    }
}