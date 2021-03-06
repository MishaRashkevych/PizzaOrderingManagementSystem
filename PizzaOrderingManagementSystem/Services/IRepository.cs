using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PizzaOrderingManagementSystem.Services
{
    interface IRepository<TEntity> where TEntity : class
    {
        TEntity Create(TEntity item);
        TEntity FindById(int id);
        IEnumerable<TEntity> Get();
        IEnumerable<TEntity> Get(Func<TEntity, bool> predicate);
        void Remove(TEntity item);
        void Update(TEntity item);
    }
}