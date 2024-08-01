using LessonForElshen.Entities;
using LessonForElshen.Extensions;
using LessonForElshen.Repository;
using LessonForElshen.Repository.ProductRepository;
using LessonForElshen.RequestTypes;
using LessonForElshen.ResponseTypes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace LessonForElshen.Controllers
{
    public class ProductController: BaseController
    {
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ProductController(IProductRepository productRepository, IUnitOfWork unitOfWork)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
        }

        [Produces("application/json")]
        [HttpPost]
        public async Task<string> Add([FromBody] ProductRequest request)

        {

            await _productRepository.AddAsync(new Product()
            {
                Title = request.Title,
                Description = request.Description,
                CatId = request.CatId,
                Count = request.Count,
                Price = request.Price,
            });
            await _unitOfWork.CompleteAsync(CancellationToken.None);
            return "success";

        }

        [Produces("application/json")]
        [HttpGet("by-cat")]
        public async Task<List<ProductResponse>> GetProduct([FromQuery] int? id)

        {
            Expression<Func<Product, bool>> predicate = x => true;
            if (id != null)
            {
                Expression<Func<Product, bool>> CategoryPredicate = x => x.CatId == id;

                // Combine the predicates using 'AndAlso'
                predicate = predicate.AndAlso(CategoryPredicate);
            }
            var products =await _productRepository.GetAll(predicate).Include("Category").ToListAsync();
            var response = new List<ProductResponse>();

            foreach (var product in products)
            {
                var categoryDto = new CategoryResponse();
                if (product.Category != null)
                {
                    categoryDto.Title = product.Category.Title;
                    categoryDto.Id = product.Category.Id;
                }

                var productDto = new ProductResponse {
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
