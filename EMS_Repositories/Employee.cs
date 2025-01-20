using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS_Repositories
{
    public class Employee : User
    {
        public bool CheckIn()
        {
            Console.WriteLine("Checked-In");
            return true;
        }

        public bool CheckOut() 
        { 
            Console.WriteLine("Checked-Out"); return true; 
        }

        public bool ApplyLeave(int days)
        {
            Console.WriteLine("Applied for Leave");
            return true;
        }

        public void CheckPaySlip()
        {
            Console.WriteLine("Checked PaySlip");
        }

        public void ViewAttendance()
        {
            Console.WriteLine("Viewed Attendance");
        }



    }
}
