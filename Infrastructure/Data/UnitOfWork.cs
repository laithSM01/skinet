using Core.Entities;
using Core.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    /*
     * Our UnitOfWork  is going to own the store context
     * responsable for creating this
     * As we initilize unitOfWork: 
     * 1) we're gonna create a new instance of our store context
     * 2) and any repositories that we used inside this unitofwork are gonna be stored in HashTable
     */
    public class UnitOfWork : IUnitOfWork
    {
        private readonly StoreContext _context;
        private Hashtable _repositories;

        public UnitOfWork(StoreContext context)
        {
            _context = context;
        }
        public async Task<int> Complete()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        /*
         * when ever we use this method Repository
         * we gonna give it the type of the entity
         * check if hashtable already created 
         * check the TEntity and whats its name is
         * check if the reposity hashtable already contained with the specific type
         * generate instance of this repo of the product, and pass the context  that we getting from untiofwork
         * pass this repo to the hashtable
         * then we return it
         */

        public IGenericRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity
        {
            try
            {
                // Check if the repository hashtable is initialized
                if (_repositories == null)
                {
                    _repositories = new Hashtable();
                }

                // Get the type name of the entity
                var type = typeof(TEntity).Name;

                // Check if the repository hashtable contains an entry for the entity
                if (!_repositories.ContainsKey(type))
                {
                    // Specify the repository type (GenericRepository<TEntity>)
                    var repositoryType = typeof(GenericRepository<>);
                    var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), _context);

                    // Add a new entry into the repository hashtable
                    _repositories.Add(type, repositoryInstance);
                }

                // Return the repository instance
                return (IGenericRepository<TEntity>)_repositories[type];
            }
            catch (Exception ex)
            {
                // Handle the exception here
                // You can log the exception, throw a custom exception, or return a default value
                // For now, rethrow the exception
                throw;
            }
        }
    }
}
