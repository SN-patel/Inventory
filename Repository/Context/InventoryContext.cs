using Microsoft.EntityFrameworkCore;
using Repository.Context.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Context
{
    public class InventoryContext:DbContext
    {
        public InventoryContext(DbContextOptions<InventoryContext> options):base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
