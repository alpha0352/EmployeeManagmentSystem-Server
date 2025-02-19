using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Xml.Serialization;
using System.Threading.Tasks;
using EMS_Repositories;
using System.Collections.ObjectModel;

namespace EMS_ServerUtilities
{
    public class xmlSerializer
    {
        const string path = "C:\\Users\\anasali\\OneDrive - TRAFiX, LLC\\Documents\\Project\\EMS_Server\\EMS_Server\\Data\\";
        
        public void Serialize<T>(T obj)
        {
            string file_name = typeof(T) == typeof(Employee)? "Employee.xml" : 
                typeof(T) == typeof(ObservableCollection<Employee>)? "Employee.xml" : 
                typeof(T) == typeof(Admin) ? "Admin.xml" : typeof(T) == typeof(ObservableCollection<Admin>) ? "Admin.xml" : 
                typeof(T) == typeof(Request) ? "Request.xml" : typeof(T) == typeof(ObservableCollection<Request>) ? "Request.xml" : 
                throw new InvalidDataException("Invalid Object Type");

                XmlSerializer serializer = new XmlSerializer(typeof(T));
                using (System.IO.StreamWriter writer = new System.IO.StreamWriter(path + file_name))
                {
              
                    serializer.Serialize(writer, obj);
                }
        }
        public T Deserialize<T>()
        {

            string file_name;

            if (typeof(T) == typeof(Employee) || typeof(T) == typeof(ObservableCollection<Employee>)) file_name = "Employee.xml";
            else if (typeof(T) == typeof(Admin) || typeof(T) == typeof(ObservableCollection<Admin>)) file_name = "Admin.xml";
            else if (typeof(T) == typeof(Request) || typeof(T) == typeof(ObservableCollection<Request>)) file_name = "Request.xml";
            else throw new InvalidDataException("Invalid Object Type");

            if (!File.Exists(path + file_name))
            {
                T defaultInstance = Activator.CreateInstance<T>();
                Console.WriteLine($"File not found: {path + file_name}");

                this.Serialize(defaultInstance);
            }

            XmlSerializer serializer = new XmlSerializer(typeof(T));
            try
            {

                using (System.IO.StreamReader reader = new System.IO.StreamReader(path + file_name))
                {
                    var result = (T)serializer.Deserialize(reader);
                    return result;
                }
            }
            catch (Exception e)
            {
                if (e.GetType().Name == "FileNotFoundException")
                {
                    Console.WriteLine(e.Message);
                    return default(T);
                }
                else
                {
                    throw e;
                }
            }
        }
    }
}