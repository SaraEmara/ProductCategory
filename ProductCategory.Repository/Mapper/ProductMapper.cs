using ProductCategory.Repository.Entities;

namespace ProductCategory.Repository.Mapper
{
    public static class ProductMapper
    {
        public static ProductDTO MapToDTO(Product product)
        {
            return new ProductDTO()
            {
                CategoryID= product.CategoryId,
                Name= product.Name,
                Price= product.Price,
                ImgURL= product.ImgURL,
                Quantity= product.Quantity

            };
        }
        public static Product MapFromDto(ProductDTO dto)
        {
            return new Product()
            {
                CategoryId= dto.CategoryID,
                Name = dto.Name,
                Price = dto.Price,
                ImgURL = dto.ImgURL,
                Quantity = dto.Quantity

            };
        }
    }
}
