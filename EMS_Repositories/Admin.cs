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
        public Admin(string name,int id,string pwd,string designation, userRoles role,double salary,int casuals,int sick,int annual)
        {
            this.Id = id; 
            this.Name = name;
            this.Pwd = pwd;
            this.Designation = designation;
            this.Role = role;
            this.Salary = salary;
            this.Leaves = new Leaves(casuals,sick,annual);
            this.Attendance = new Attendance(false,0,0,0,0,0);
        }

        public void UpdateFrom(Admin other)
        {
            if (other == null) return;

            this.Id = other.Id;
            this.Pwd = other.Pwd;
            this.Name = other.Name;
            this.Gender = other.Gender;
            this.Email = other.Email;
            this.Phone = other.Phone;
            this.Address = other.Address;
            this.Dob = other.Dob;
            this.Religion = other.Religion;
            this.MaritalStatus = other.MaritalStatus;
            this.Designation = other.Designation;
            this.Department = other.Department;
            this.Role = other.Role;
            this.Salary = other.Salary;

            if (other.Attendance != null)
                this.Attendance = other.Attendance;

            if (other.Leaves != null)
                this.Leaves = other.Leaves;

            // Uncomment if uses m_request
            // if (other.m_request != null)
            //    this.m_request = other.m_request;

            this.isAuthentic = other.isAuthentic;
        }
    }
}
