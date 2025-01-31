using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EMS_Repositories
{

    public class Employee : User
    {
        public Employee()
        {
            
        }

        public Employee(string name, int id, string pwd, string gender,DateTime dob, string email,string contactNo,string residence_address, string religion,string marStat) //called from Signup
        {
            this.m_Id = id;
            this.m_name = name;
            this.m_pwd = pwd;
            this.m_gender = gender;
            this.m_dob = dob;
            this.m_email = email;
            this.m_phone = contactNo;
            this.m_address = residence_address;
            this.m_religion = religion;
            this.m_maritalstatus = marStat;
            this.m_isAuthentic = false;
            this.m_attendance = new Attendance(false, 0, 0, 0, 0, 0);
            this.m_leaves = new Leaves(0,0,0);
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
