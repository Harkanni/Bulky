using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bulky.DataAccess.Repository.IRepository;
using Bulky.DataAcess.Data;

namespace Bulky.DataAccess.Repository
{
    internal class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDBContext _db;

        public Repository(ApplicationDBContext db)
        {
            _db = db;
        }
        public void Add(T entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteRange(System.Linq.Expressions.Expression<Func<T, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public T Get(System.Linq.Expressions.Expression<Func<T, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
