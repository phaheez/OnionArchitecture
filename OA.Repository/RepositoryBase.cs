using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OA.DataAccess;

namespace OA.Repository
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected RepositoryContext Context { get; set; }
        private readonly DbSet<T> _entities;
        public RepositoryBase(RepositoryContext context)
        {
            Context = context;
            _entities = Context.Set<T>();
        }

        public IQueryable<T> FindAll()
        {
            return _entities.AsNoTracking();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return _entities.Where(expression).AsNoTracking();
        }

        public void Create(T entity)
        {
            _entities.Add(entity);
        }

        public void Update(T entity)
        {
            _entities.Update(entity);
        }

        public void Delete(T entity)
        {
            _entities.Remove(entity);
        }
    }
}
