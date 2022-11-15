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
    [Route("api/categories")]

    public class CategoriesController : ControllerBase
    {
        private IGenericRepository<Category> categoryRepo;
        public CategoriesController(IGenericRepository<Category> _categoryRepo) { categoryRepo = _categoryRepo; }

        // GET: api/Categories
        [HttpGet]
        public CustomProductRes Get()
        {
            CustomProductRes customProductRes = null;

            try
            {
                List<Category> categories = categoryRepo.GetALL();
                customProductRes = new CustomProductRes() { Success = true, Results = categories };

            }
            catch (Exception ex)
            {
                customProductRes = new CustomProductRes() { Success = false, Messages = new List<string>() { "Error happen while fetching categories details." } };

            }
            return customProductRes;
            
        }

    }
}


     
