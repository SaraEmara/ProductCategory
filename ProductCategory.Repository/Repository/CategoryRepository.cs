using ProductCategory.Repository.Context;
using ProductCategory.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductCategory.Repository.Repository
{
    /// <summary>
    /// Product Repository Managment for (create, update, delete and view Products).
    /// </summary>
    public class CategoryRepository : IGenericRepository<Category>
    {
        ProductDbContext ProductDbContext;
        public CategoryRepository(ProductDbContext productDbContext) { ProductDbContext = productDbContext; }

        public void Delete(Category Category)
        {
            ProductDbContext.Remove(Category);
            ProductDbContext.SaveChanges();
        }

        public bool DeleteById(string Id)
        {
            bool Status = false;
            Category category = ProductDbContext.Category.Where(c => c.ID == Id).FirstOrDefault();
            if (category != null)
            {
                ProductDbContext.Remove(category);
                ProductDbContext.SaveChanges();
                Status = true;
            }
            return Status;
        }

        public List<Category> GetALL()
        {
            IQueryable<Category> categories = ProductDbContext.Category;
            List<Category> c = new List<Category>(categories);
            if (ProductDbContext.Category.ToList<Category>().Count == 0)
            {
                return new List<Category>();
            }
            return ProductDbContext.Category.ToList();
        }

        public Category GetById(string id)
        {
            return ProductDbContext.Category.Where(c => c.ID == id).FirstOrDefault();

        }

        public void Insert(Category category)
        {
            if (category != null)
            {
                object obj = ProductDbContext.Add(category);
                ProductDbContext.SaveChanges();
            }
        }

        public void Update(Category category)
        {

            Category SelectedCategory = ProductDbContext.Category.Where(p => p.ID == category.ID).FirstOrDefault();

            if (SelectedCategory != null && category != null)
            {
                SelectedCategory.Name = category.Name;
              
                ProductDbContext.SaveChanges();
            }
        }
    }
}
