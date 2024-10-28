using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    // IDisposable: this is going to look for dispose method in unitOFwork , when we finish our transaction is going to dispose of our context
    public interface IUnitOfWork : IDisposable 
    {
        /*
         * Our Entity frameWork is gonna track all the changes to the Entity
         * what ever we do inside this unitofwork
         * then we run complete() and thats the part that gonna save changes to Db
         * and return number of changes
         */
        IGenericRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity;
        Task<int> Complete(); //gonna return number of changes to our DB
    }
}
