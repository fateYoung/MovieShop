using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MovieShop.Data
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected MovieShopDbContext _dbContext;
        public Repository(MovieShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            _dbContext.SaveChanges();
        }

        public void Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            _dbContext.SaveChanges();
        }

        public void Delete(Expression<Func<T, bool>> where)
        {
            var objects = _dbContext.Set<T>().Where(where).AsEnumerable();
            foreach (var obj in objects)
                _dbContext.Set<T>().Remove(obj);

            _dbContext.SaveChanges();
        }

        public T Get(Expression<Func<T, bool>> where)
        {
            return _dbContext.Set<T>().Where(where).FirstOrDefault();
        }

        public IEnumerable<T> GetAll()
        {
            return _dbContext.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            return _dbContext.Set<T>().Find(id);
        }

        public IEnumerable<T> GetMany(Expression<Func<T, bool>> where)
        {
            return _dbContext.Set<T>().Where(where).ToList();
        }

        public void Update(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }
    }
}
