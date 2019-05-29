using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HC.Data.Data
{
    public class EmployeeDBContext
    {

        string strPath = ConfigurationManager.AppSettings["JsonPath"];


        public IEnumerable<T> List<T>()
        {
            var lst = new List<Employee>();
            foreach (var item in Directory.GetFiles(strPath))
            {
                string jsonFile = Path.Combine(strPath, item);
                string myJson = string.Empty;
                using (var r = new StreamReader(jsonFile))
                {
                    myJson = r.ReadToEnd();
                    Employee e = JsonConvert.DeserializeObject<Employee>(myJson);
                    lst.Add(e);
                }
            }
            return (IEnumerable<T>)lst;
        }

        public Employee UpdateEmployee(Employee emp, string id)
        {
            string jsonFile = Path.Combine(strPath, id + ".json");
            try
            {
                string myJson = string.Empty;
                using (var r = new StreamReader(jsonFile))
                {
                    myJson = r.ReadToEnd();
                }
                Employee e = JsonConvert.DeserializeObject<Employee>(myJson);
                e.Age = emp.Age;
                e.City = emp.City;
                e.Email = emp.Email;
                e.FullName = emp.FullName;
                e.Salary = emp.Salary;
                e.GuidId = emp.GuidId;
                
                DeleteEmplioyee(id);
                AddEmployee(e);
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool DeleteEmplioyee(string guid) {
            try
            {
                File.Delete(Path.Combine(strPath, guid + ".json"));
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public bool AddEmployee(Employee emp)
        {
            Guid g = Guid.NewGuid();
            string jsonFile = Path.Combine(strPath, g + ".json");
            try
            {
                //Set IdEmployee based on number of json files created
                int employeeNumber = Directory.GetFiles(strPath).Length;
                emp.Id = employeeNumber + 1;
                emp.GuidId = g;
                //Create Employee 
                string jsonResult = JsonConvert.SerializeObject(emp);

                //Save Employee
                using (var j = new StreamWriter(jsonFile, true))
                {
                    j.WriteLine(jsonResult.ToString());
                    j.Close();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
