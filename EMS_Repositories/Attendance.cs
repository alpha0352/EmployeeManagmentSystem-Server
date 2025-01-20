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
        public bool isPresent { get; set; }
        public int m_presentdays { get; set; }
        public int m_absentdays { get; set; }
        public int m_halfdays { get; set; }
        public int m_late { get; set; }
        public int m_earlyleave { get; set; }

        public Attendance() { }
        public Attendance(bool ispres, int presDays,int absDays, int halfDays, int late,int earlyleaves)
        {
            isPresent = ispres;
            m_presentdays = presDays;
            m_absentdays = absDays;
            m_halfdays = halfDays;
            m_late = late;
            m_earlyleave = earlyleaves;

        }

    }
}