using App.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Interfaces
{
    interface IRepository<TEntity> : IDisposable where TEntity : Entity
    {
        Task Add(TEntity entity);
        Task<TEntity> GetById(Guid id);
        Task<List<TEntity>> List();
        Task Update(TEntity entity);
        Task Delete(Guid id);
        Task<int> SaveChanges();
    }
}
