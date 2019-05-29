using HC.Data.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HC.Data
{
    public class EmployeeRepository : IRepository<Employee>
    {
        private EmployeeDBContext _context = null;

        public IEnumerable<Employee> List
        {
            get
            {
                return _context.List<Employee>();
            }
        }

        public EmployeeRepository()
        {
            _context = new EmployeeDBContext();
        }

        public bool Add(Employee entity)
        {
           return  _context.AddEmployee(entity);
        }

        public bool Delete(string Id)
        {
            return _context.DeleteEmplioyee(Id);
        }

        public Employee Update(Employee entity, string Id)
        {
            return _context.UpdateEmployee(entity, Id);
        }
    }
}
