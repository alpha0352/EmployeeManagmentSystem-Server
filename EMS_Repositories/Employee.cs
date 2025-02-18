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
            this.m_nId = other.m_nId;
            this.m_stPwd = other.m_stPwd;
            this.m_stName = other.m_stName;
            this.m_stGender = other.m_stGender;
            this.m_stEmail = other.m_stEmail;
            this.m_stPhone = other.m_stPhone;
            this.m_stAddress = other.m_stAddress;
            this.m_dtDob = other.m_dtDob;
            this.m_stReligion = other.m_stReligion;
            this.m_stMaritalStatus = other.m_stMaritalStatus;
            this.m_stDesignation = other.m_stDesignation;
            this.m_stDepartment = other.m_stDepartment;
            this.m_enRole = other.m_enRole;
            this.m_dSalary = other.m_dSalary;
            this.m_bIsAuthentic = other.m_bIsAuthentic;
            this.m_attendance = other.m_attendance;
            this.m_leaves = other.m_leaves;

        }

        public Employee(string name, int id, string pwd, string gender,DateTime dob, string email,string contactNo,string residence_address, string religion,string marStat) //called from Signup
        {
            this.m_nId = id;
            this.m_stName = name;
            this.m_stPwd = pwd;
            this.m_stGender = gender;
            this.m_dtDob = dob;
            //this.m_enRole = userRoles.Employee;
            this.m_stEmail = email;
            this.m_stPhone = contactNo;
            this.m_stAddress = residence_address;
            this.m_stReligion = religion;
            this.m_stMaritalStatus = marStat;
            this.m_bIsAuthentic = false;
            this.m_attendance = new Attendance(false, 0, 0, 0, 0, 0);
            this.m_leaves = new Leaves(0,0,0);
        }

        public Employee(string name, int id, string pwd, string designation, userRoles role, double salary, int casuals, int sick, int approved)
        {
            this.m_nId = id;
            this.m_stName = name;
            this.m_stPwd = pwd;
            this.m_stDesignation = designation;
            this.m_enRole = role;
            this.m_dSalary = salary;
            this.m_leaves = new Leaves(casuals, sick, approved);
            this.m_attendance = new Attendance(false, 0, 0, 0, 0, 0);

        }

        public void UpdateFrom(Employee other)
        {
            if (other == null) return;

            this.m_nId = other.m_nId;
            this.m_stPwd = other.m_stPwd;
            this.m_stName = other.m_stName;
            this.m_stGender = other.m_stGender;
            this.m_stEmail = other.m_stEmail;
            this.m_stPhone = other.m_stPhone;
            this.m_stAddress = other.m_stAddress;
            this.m_dtDob = other.m_dtDob;
            this.m_stReligion = other.m_stReligion;
            this.m_stMaritalStatus = other.m_stMaritalStatus;
            this.m_stDesignation = other.m_stDesignation;
            this.m_stDepartment = other.m_stDepartment;
            this.m_enRole = other.m_enRole;
            this.m_dSalary = other.m_dSalary;

            if (other.m_attendance != null)
                this.m_attendance = other.m_attendance;

            if (other.m_leaves != null)
                this.m_leaves = other.m_leaves;

            // Uncomment if uses m_request
            // if (other.m_request != null)
            //    this.m_request = other.m_request;

            this.m_bIsAuthentic = other.m_bIsAuthentic;
        }
    }
}
