using ProductCategory.Repository.Context;
using ProductCategory.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ProductCategory.Repository.Mapper;
namespace ProductCategory.Repository.Repository
{
    /// <summary>
    /// Product Repository Managment for (create, update, delete and view Products).
    /// </summary>
    public class ProductRepository : IGenericRepository<ProductDTO>
    {
        ProductDbContext ProductDbContext;
        public ProductRepository(ProductDbContext productDbContext) { ProductDbContext = productDbContext; }

        public void Delete(ProductDTO dto)
        {
            ProductDbContext.Remove(ProductMapper.MapFromDto(dto));
            ProductDbContext.SaveChanges();
        }

        public bool DeleteById(string Id)
        {
            bool Status = false;
            Product Product=  ProductDbContext.Product.Where(p => p.ID == Id).FirstOrDefault();
            if(Product != null)
            {
                ProductDbContext.Remove(Product);
                ProductDbContext.SaveChanges();
                Status = true;
            }
            return Status; 

        }

        public List<ProductDTO> GetALL()
        {
            List<ProductDTO> result = new List<ProductDTO>();
            IQueryable<Product> Prods = ProductDbContext.Product;
            List<Product> p = new List<Product>(Prods);
            if (ProductDbContext.Product.ToList<Product>().Count == 0)
            {
                return new List<ProductDTO>();
            }
            List<Product> products = ProductDbContext.Product.ToList();
            foreach (Product product in products)
            {
                result.Add(ProductMapper.MapToDTO(product));
            }
            return result;
           
        }

        public ProductDTO GetById(string id)
        {
            Product product = ProductDbContext.Product.Where(p => p.ID == id).FirstOrDefault();
            if (product != null)
            {
               return ProductMapper.MapToDTO(product);
            }
            return null ;
        }

        public void Insert(ProductDTO Product)
        {
            if (Product!=null) {
                _ = ProductDbContext.Add(ProductMapper.MapFromDto(Product));
                ProductDbContext.SaveChanges();
            }
        }

        public void Update(ProductDTO Product)
        {

           Product SelectedPro= ProductDbContext.Product.Where(p => p.ID == Product.ID).FirstOrDefault();

            if (SelectedPro != null &&Product!=null )
            {
                SelectedPro.Name = Product.Name;
                SelectedPro.ImgURL = Product.ImgURL;
                SelectedPro.Price = Product.Price;
                SelectedPro.Quantity = Product.Quantity;
                ProductDbContext.SaveChanges();
            }
        }
    }
}
