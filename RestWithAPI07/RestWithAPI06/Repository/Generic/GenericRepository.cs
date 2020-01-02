using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using RestWithAPI.Model.Context;
using RestWithAPI.Model.Base;

namespace RestWithAPI.Repository.Generic
{
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {
        private MySQLContext _context;
        private DbSet<T> dataset;
        public GenericRepository(MySQLContext context)
        {
            _context = context;
            dataset = context.Set<T>();
        }

        public T Create(T item)
        {
            try
            {
                dataset.Add(item);
                _context.SaveChanges();
                return item;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(long? id)
        {
            var result = dataset.SingleOrDefault(p => p.Id == id);
            if (result != null)
            {
                _context.Remove(result);
                _context.SaveChanges();
            }
        }

        public bool Exists(long? id)
        {
            return dataset.Any(p => p.Id.Equals(id));
        }

        public List<T> FindAll()
        {
            return dataset.ToList();
        }

        public T FindById(long? id)
        {
            return dataset.SingleOrDefault(p => p.Id == id);
        }

        public T Update(T item)
        {
            if (!Exists(item.Id)) return null;

            var result = dataset.SingleOrDefault(p => p.Id.Equals(item.Id));
            if (result != null)
            {
                _context.Entry(result).CurrentValues.SetValues(item);
                _context.SaveChanges();
                return item;
            }
            return null;
        }
    }
}