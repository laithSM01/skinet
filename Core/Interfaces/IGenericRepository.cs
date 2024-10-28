using Core.Entities;
using Core.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<T> GetByIdAsync(int id);
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<T> GetEntityWithSpec(ISpecification<T> specification);
        Task<IReadOnlyList<T>> ListAsync(ISpecification<T> specification);
        Task<int> CountAsync(ISpecification<T> specification);

        //support methods for updating:
        /*
         * these methods are not aysnc, why? 
         * we are not going to be directly adding these to DB while we using these methods
         * all we saying to Entity Framework , we want to use this so track it
         * its happening in memory
         * its not happening in DB Technology
         * our repo is not responsable to save changes to DB thats left to UnitOfWork
         */
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
