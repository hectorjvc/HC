using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HC.WebApp.Models
{
    public class EmployeeModel
    {
        public Guid GuidId { get; set; }
        public int ID { get; set; }
        public string FullName { get; set; }

        public int Age { get; set; }

        public string City { get; set; }

        public string Email { get; set; }

        public decimal Salary { get; set; }
    }
}