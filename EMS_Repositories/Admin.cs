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
        public Admin(string name,int id,string pwd,string designation,string role,double salary,int casuals,int sick,int annual)
        {
            this.m_Id = id; 
            this.m_name = name;
            this.m_pwd = pwd;
            this.m_designation = designation;
            this.m_role = role;
            this.m_salary = salary;
            this.m_leaves = new Leaves(casuals,sick,annual);
            this.m_attendance = new Attendance(false,0,0,0,0,0);
        }

        public void UpdateFrom(Admin other)
        {
            if (other == null) return;

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

            if (other.m_attendance != null)
                this.m_attendance = other.m_attendance;

            if (other.m_leaves != null)
                this.m_leaves = other.m_leaves;

            // Uncomment if uses m_request
            // if (other.m_request != null)
            //    this.m_request = other.m_request;

            this.m_isAuthentic = other.m_isAuthentic;
        }
    }
}
