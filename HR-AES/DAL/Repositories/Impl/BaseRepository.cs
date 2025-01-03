using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repositories.Impl
{
    public abstract class BaseRepository<T> : IRepository<T> where T : class
    {
        protected readonly DbSet<T> _set;
        private readonly DbContext _context;

        public BaseRepository(DbContext context)
        {
            _context = context;
            _set = context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return _set.ToList();
        }

        public T Get(int id)
        {
            return _set.Find(id);
        }

        public IEnumerable<T> Find(Func<T, bool> predicate)
        {
            return _set.Where(predicate).ToList();
        }

        public void Create(T item)
        {
            _set.Add(item);
            _context.SaveChanges();
        }

        public void Update(T item)
        {
            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var item = Get(id);
            if (item != null)
            {
                _set.Remove(item);
                _context.SaveChanges();
            }
        }
    }
}

