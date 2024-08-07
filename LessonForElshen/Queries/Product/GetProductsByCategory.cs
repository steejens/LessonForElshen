using System.Linq.Expressions;
using LessonForElshen.Commands.Categories.Responses;
using LessonForElshen.Extensions;
using LessonForElshen.Repository.ProductRepository;
using Microsoft.EntityFrameworkCore;
using LessonForElshen.Queries.Product.Responses;

namespace LessonForElshen.Queries.Product
{
    public class GetProductsByCategory
    {
        private readonly IProductRepository _productRepository;

        public GetProductsByCategory(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<List<ProductResponse>> Handler(int? id)

        {
            Expression<Func<Entities.Product, bool>> predicate = x => true;
            if (id != null)
            {
                Expression<Func<Entities.Product, bool>> CategoryPredicate = x => x.CatId == id;

                // Combine the predicates using 'AndAlso'
                predicate = predicate.AndAlso(CategoryPredicate);
            }

            var products = await _productRepository.GetAll(predicate).Include("Category").ToListAsync();
            var response = new List<ProductResponse>();

            foreach (var product in products)
            {
                var categoryDto = new CategoryResponse();
                if (product.Category != null)
                {
                    categoryDto.Title = product.Category.Title;
                    categoryDto.Id = product.Category.Id;
                }

                var productDto = new ProductResponse
                {
                    Id = product.Id,
                    Title = product.Title,
                    Description = product.Description,
                    Count = product.Count,
                    Price = product.Price,
                    Category = categoryDto
                };
                response.Add(productDto);
            }

            return response;
        }
    }
}
