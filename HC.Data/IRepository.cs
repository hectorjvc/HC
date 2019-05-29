using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HC.Data
{
    public interface IRepository<T> where T : IEntity
    {
        IEnumerable<T> List { get; }
        bool Add(T entity);
        bool Delete(string Id);
        Employee Update(T entity, string Id);
      
    }
}
