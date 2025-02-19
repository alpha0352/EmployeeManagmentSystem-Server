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
            this.isAuthentic = other.isAuthentic;
            this.Attendance = other.Attendance;
            this.Leaves = other.Leaves;

        }

        public Employee(string name, int id, string pwd, string gender,DateTime dob, string email,string contactNo,string residence_address, string religion,string marStat) //called from Signup
        {
            this.Id = id;
            this.Name = name;
            this.Pwd = pwd;
            this.Gender = gender;
            this.Dob = dob;
            //this.Role = userRoles.Employee;
            this.Email = email;
            this.Phone = contactNo;
            this.Address = residence_address;
            this.Religion = religion;
            this.MaritalStatus = marStat;
            this.isAuthentic = false;
            this.Attendance = new Attendance(false, 0, 0, 0, 0, 0);
            this.Leaves = new Leaves(0,0,0);
        }

        public Employee(string name, int id, string pwd, string designation, userRoles role, double salary, int casuals, int sick, int approved)
        {
            this.Id = id;
            this.Name = name;
            this.Pwd = pwd;
            this.Designation = designation;
            this.Role = role;
            this.Salary = salary;
            this.Leaves = new Leaves(casuals, sick, approved);
            this.Attendance = new Attendance(false, 0, 0, 0, 0, 0);

        }

        
        public void UpdateFrom(Employee other)
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

            if (other.Attendance != null) this.Attendance = other.Attendance;

            if (other.Leaves != null) this.Leaves = other.Leaves;

            if (other.Attendance != null) this.isAuthentic = other.isAuthentic;
        }
    }
}
