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

        public Employee(Employee other)
        {
            this.m_Id = other.m_Id;
            this.m_pwd = other.m_pwd;
            this.m_name = other.m_name;
            this.m_gender = other.m_gender;
            this.m_email = other.m_email;
            this.m_phone = other.m_phone;
            this.m_address = other.m_address;
            this.m_dob = other.m_dob;
            this.m_religion = other.m_religion;
            this.m_maritalstatus = other.m_maritalstatus;
            this.m_designation = other.m_designation;
            this.m_department = other.m_department;
            this.m_role = other.m_role;
            this.m_salary = other.m_salary;
            this.m_isAuthentic = other.m_isAuthentic;
            this.m_attendance = other.m_attendance;
            this.m_leaves = other.m_leaves;

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
