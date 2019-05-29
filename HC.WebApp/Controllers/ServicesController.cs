using HC.Data;
using HC.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HC.WebApp.Controllers
{
    public class ServicesController : ApiController
    {

        private EmployeeRepository _context;

        public ServicesController()
        {
            _context = new HC.Data.EmployeeRepository();
        }

        public void Post(EmployeeModel emp)
        {
            _context.Add(new Employee { Age = emp.Age, City = emp.City, Email = emp.Email, FullName = emp.FullName, Salary = emp.Salary });
        }

        public IEnumerable<EmployeeModel> Get()
        {
            IEnumerable<Employee> lst = _context.List;
            List<EmployeeModel> lstEmployee = new List<EmployeeModel>();
            foreach (var item in lst)
            {
                lstEmployee.Add(new EmployeeModel
                {                    
                    FullName = item.FullName,
                    Age = item.Age,
                    City = item.City,
                    Email = item.Email,
                    Salary = item.Salary,
                    ID = item.Id, 
                    GuidId = item.GuidId
                });
            }
            return lstEmployee;
        }

        //// GET api/<controller>
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/<controller>/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<controller>
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT api/<controller>/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/<controller>/5
        public void Delete(string guid)
        {
            _context.Delete(guid);
        }
    }
}