using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestHC
{
    class Program
    {
        static void Main(string[] args)
        {
            HC.Data.EmployeeRepository e = new HC.Data.EmployeeRepository();
            e.Add(new HC.Data.Employee { FullName = "Hector", Age = 20, City = "Mexico", Email = "hector.valdes@outlook.com", Salary = 50000 });
            e.Delete("4f7689d3-8d29-4579-bfc2-e14c0ba37113");
            e.Update(
                new HC.Data.Employee
                {
                    FullName = "Julio",
                    Age = 40, City = "Canada",
                    Email = "hector.valdes@gmail.com",
                    Salary = 580000 }
                , "90ac38dc-7e29-4495-85d7-a1866e895d39");

            var lista = e.List;
        }
    }
}
