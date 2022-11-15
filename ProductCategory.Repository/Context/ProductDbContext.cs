using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProductCategory.Repository.Entities;

namespace ProductCategory.Repository.Context
{
    public class ProductDbContext:DbContext
    {
        public ProductDbContext(DbContextOptions Options):base(Options){ }
        public DbSet<Product> Product { get; set; }
        public DbSet<Category> Category { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Category>().HasData(new List<Category> (){ new Category() {ID="1", Name="Category#1"}, new Category() { ID = "2", Name = "Category#2", } });

        }


    }
}
