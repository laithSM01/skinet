﻿using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly StoreContext _context;

        public GenericRepository(StoreContext context)
        {
            _context = context;
        }


        public async Task<int> CountAsync(ISpecification<T> specification)
        {
           return await ApplySpecification(specification).CountAsync();
        }


        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            //set the entity that we will be working with, we don't know the entity which is coming
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            //set the entity that we will be working with, we don't know the entity which is coming
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<T> GetEntityWithSpec(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).FirstOrDefaultAsync();
        }

        public async Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).ToListAsync(); // list of things :D
        }


        /*
         * T will be replaced with products for example
         * and converted into Queryable
         * read note from -> SpecificationEvaluator.GetQuery
         */
        private IQueryable<T> ApplySpecification(ISpecification<T> spec)
        {
            return SpecificationEvaluator<T>.GetQuery(_context.Set<T>().AsQueryable(), spec);
        }
        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }
        public void Update(T entity)
        {
            _context.Set<T>().Attach(entity); //attach this entity to be changed
            _context.Entry(entity).State = EntityState.Modified; // marks entity as modified
        }
        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

    }
}
