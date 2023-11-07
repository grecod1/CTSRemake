using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Helpline.Repository.Interfaces
{
    interface IGenericRepository<T> where T:class
    {
        IEnumerable<T> GetAll(Expression<Func<T, bool>> filter = null,
          string includeProperties = "");

        T GetOne(Expression<Func<T, bool>> filter, string includedProperties);

        void Create(T model);

        void Edit(T model);

        void Remove(T model);

    }
}
