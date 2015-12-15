using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DataAccess.UnitOfWork;
namespace DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T: class 
    {
        protected DbContext context;
        protected DbSet<T> dbSet;
        protected UnitOfWork.UnitOfWork UnitOfWork;

        public UnitOfWork.UnitOfWork BeginUnitOfWork()
        {
            if (this.UnitOfWork == null)
            {
                this.UnitOfWork = new UnitOfWork.UnitOfWork(context);
            }

            return this.UnitOfWork;
        }

        public Repository()
        {
            this.context = new UniversityContext();
            this.dbSet = this.context.Set<T>();
        }
        public IEnumerable<T> GetEntities()
        {
            return dbSet.ToList();
        }

        public T GetEntityById(int id)
        {
            return dbSet.Find(id);
        }

        public void InsertEntity(T entity)
        {
            dbSet.Add(entity);
        }

        public void DeleteEntity(int id)
        {
            T entity = dbSet.Find(id);
            dbSet.Remove(entity);
        }

        public void UpdateEntity(T entity)
        {
            dbSet.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
