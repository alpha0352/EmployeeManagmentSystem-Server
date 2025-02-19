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
        public int PresentDays { get; set; }
        public int AbsentDays { get; set; }
        public int HalfDays { get; set; }
        public int Lates { get; set; }
        public int EarlyLeaves { get; set; }

        public Attendance() { }
        public Attendance(bool ispres, int presDays,int absDays, int halfDays, int late,int earlyleaves)
        {
            isPresent = ispres;
            PresentDays = presDays;
            AbsentDays = absDays;
            HalfDays = halfDays;
            Lates = late;
            EarlyLeaves = earlyleaves;

        }

    }
}