using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HC.Data
{
    public class Employee : IEntity
    {

        public Guid GuidId { get; set; }
        public string FullName { get; set; }

        public int Age { get; set; }

        public string City { get; set; }

        public string Email { get; set; }

        public decimal Salary { get; set; }


    }
}
