using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Entity;

namespace DataAccess.Repository
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetEntities();
        T GetEntityById(int id);
        void InsertEntity(T entity);
        void DeleteEntity(int id);
        void UpdateEntity(T entity);
        void Save();
        UnitOfWork.UnitOfWork BeginUnitOfWork();
    }
}
