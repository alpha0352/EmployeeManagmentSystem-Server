using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS_Repositories
{

    public class Employee : User
    {
        public Employee()
        {
            
        }
        public Employee(string name, int id, string pwd, string designation, string role, double salary, int casuals, int sick, int approved)
        {
            this.m_Id = id;
            this.m_name = name;
            this.m_pwd = pwd;
            this.m_designation = designation;
            this.m_role = role;
            this.m_salary = salary;
            this.m_leaves = new Leaves(casuals, sick, approved);
            this.m_attendance = new Attendance(false, 0, 0, 0, 0, 0);

        }
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
