using AdamTaskApplication.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdamTaskApplication.Data.Repositries
{
    public class Repository<T> : IRepository<T> where T : class
    {

        protected readonly MainContext _context;
        public Repository(MainContext context)
        {
            _context = context;
        }

        protected void Save() => _context.SaveChanges();

        public int Count(Func<T, bool> predicate)
        {
            return _context.Set<T>().Where(predicate).Count();
        }

        public void Create(T entity)
        {
            _context.Add(entity);
            Save();
        }
        public IEnumerable<T> Find(Func<T, bool> predicate)
        {
            return _context.Set<T>().Where(predicate);
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>();
        }



        public T GetById(long id)
        {
            return _context.Set<T>().Find(id);
           //return _context.Set<T>().Max(x=>x.)
        }

        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            Save();
        }

        public void Delete(T entity)
        {
            _context.Remove(entity);
            Save();
        }
    }
}
