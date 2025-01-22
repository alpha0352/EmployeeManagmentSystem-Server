using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace EMS_Repositories
{
    public class Admin : User
    {
        public Admin()
        {
            
        }
        public Admin(string name,int id,string pwd,string designation,string role,double salary,int casuals,int sick,int approved)
        {
            this.m_Id = id; 
            this.m_name = name;
            this.m_pwd = pwd;
            this.m_designation = designation;
            this.m_role = role;
            this.m_salary = salary;
            this.m_leaves = new Leaves(casuals,sick,approved);
            this.m_attendance = new Attendance(false,0,0,0,0,0);
        }

        public bool AddEmployee()
        {
            Console.WriteLine("Employee Added");
            return true;
        }
        public bool RemoveEmployee()
        {
            Console.WriteLine("Employee Removed");
            return true;
        }
        public bool UpdateEmployee()
        {
            Console.WriteLine("Employee Updated");
            return true;
        }
        public bool AddAdmin()
        {
            Console.WriteLine("Admin Added");
            return true;
        }
        public bool RemoveAdmin()
        {
            Console.WriteLine("Admin Removed");
            return true;
        }
        public bool UpdateAdmin()
        {
            Console.WriteLine("Admin Updated");
            return true;
        }
        public bool AddLeave()
        {
            Console.WriteLine("Leave Added");
            return true;
        }
        public bool RemoveLeave()
        {
            Console.WriteLine("Leave Removed");
            return true;
        }
        public bool ApproveLeave()
        {
            Console.WriteLine("Leave Approved");
            return true;
        }
        public bool AddAttendance()
        {
            Console.WriteLine("Attendance Added");
            return true;
        }
        public bool RemoveAttendance()
        {
            Console.WriteLine("Attendance Removed");
            return true;
        }
        public bool UpdateAttendance()
        {
            Console.WriteLine("Attendance Updated");
            return true;
        }
        public bool AddPaySlip()
        {
            Console.WriteLine("PaySlip Added");
            return true;
        }
    }
}
