using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductCategory.Repository.Entities;
using System.ComponentModel.DataAnnotations;
using ProductCategory.Repository.Repository;
using ProductCategory.Repository.Model;

namespace ProductCategory.Repository.Controllers
{
    [Produces("application/json")]
    [Route("api/Products")]

    public class ProductsController : ControllerBase
    {
        private IGenericRepository<ProductDTO> ProductRepo;
        public ProductsController(IGenericRepository<ProductDTO> productRepo) { ProductRepo = productRepo; }

        // GET: api/Products
        [HttpGet]
        public CustomProductRes Get()
        {
            CustomProductRes customProductRes = null;

            try
            {
                List<ProductDTO> products = ProductRepo.GetALL();
                customProductRes = new CustomProductRes() { Success = true, Results = products };

            }catch(Exception ex)
            {
                customProductRes = new CustomProductRes() { Success = false, Messages = new List<string>() { "Error happen while fetching products details." } };

            }
            return customProductRes;
        }
        // GET: products/{id}
        [HttpGet("{id}")]
        public CustomProductRes GetProduct([FromRoute] string id)
        {
            CustomProductRes customProductRes = null;
            try
            {
                ProductDTO product = ProductRepo.GetALL().Where(b => b.ID == id).FirstOrDefault();
                if (product != null)
                {
                    customProductRes = new CustomProductRes() { Success = true, Results = product };
                }
                else
                {
                    customProductRes = new CustomProductRes() { Success = false, Messages = new List<string>() { "No product exist with this id, please enter valid id." } };
                }
            }
            catch(Exception ex)
            {
                customProductRes = new CustomProductRes() { Success = false, Messages = new List<string>() { "Error happen while fetching product details." } };
            }
            return customProductRes;
        }

        // GET: products?categoryID={id}
        [HttpGet("{categoryID}")]
        public CustomProductRes GetProducts([FromQuery] string categoryID)
        {
            CustomProductRes customProductRes = null;
            try
            {
                List<ProductDTO> products = ProductRepo.GetALL().Where(b => b.CategoryID== categoryID).ToList();
               
                customProductRes = new CustomProductRes() { Success = true, Results = products };
            }
            catch (Exception ex)
            {
                customProductRes = new CustomProductRes() { Success = false, Messages = new List<string>() { "Error happen while fetching products." } };
            }
            return customProductRes;

        }

        // POST: /products
        [HttpPost]
        public CustomProductRes InsertProduct([FromBody] ProductDTO product)
        {
            bool status = false;
            string msg = "Error happen while inserting new product.";
            if (product != null)
            {
                ProductRepo.Insert(product);
                status = true;
                msg = "New product has been inserted successfully.";
            }
            return new CustomProductRes() { Success=status, Messages=new List<string>() { msg } };
        }
        // PUT: products/{id}
        [HttpPut("{id}")]
        public CustomProductRes UpdateProduct([FromRoute]string ProductId, ProductDTO product)
        {
            bool status = false;
            string msg;
            try
            {
                ProductRepo.Update(product);
                status = true;
                msg = "Product has been updated successfully.";

            }
            catch (Exception ex)
            {
                msg = "Error happen while updating product with id {ProductId} in database.";
            }

            return new CustomProductRes() { Success = status, Messages = new List<string>() { msg } };

        }
    }
}