using Microsoft.EntityFrameworkCore;
using Repository.Context;
using Repository.Context.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Repositories
{
    public class ProductRepository : IRepository<Product>,IDisposable
    {
        private readonly InventoryContext _context;

        public ProductRepository(InventoryContext context)
        {
            _context = context;
        }
        public int Add(Product entity)
        {
            _context.Products.Add(entity);
            _context.SaveChanges();
            return entity.Id;
        }

        public void AddRange(List<Product> entities)
        {
            _context.Products.AddRange(entities);
            _context.SaveChanges();
        }

        public void Delete(Product entity)
        {
            _context.Products.Remove(entity);
            _context.SaveChanges();
        }

        public Product Get(object id)
        {
            return _context.Products.Where( p => p.Id == Convert.ToInt32(id)).First();
        }

        public IEnumerable<Product> GetAll()
        {
            return _context.Products.ToList();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Product entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }
    }
}
