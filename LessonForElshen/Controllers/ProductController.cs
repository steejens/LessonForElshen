using LessonForElshen.Entities;
using LessonForElshen.Extensions;
using LessonForElshen.Repository;
using LessonForElshen.Repository.ProductRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using LessonForElshen.Queries.Product;
using LessonForElshen.Queries.Product.Requests;
using LessonForElshen.Queries.Product.Responses;

namespace LessonForElshen.Controllers
{
    public class ProductController: BaseController
    {
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly GetProductsByCategory _getProductsByCategoryHandler;

        public ProductController(IProductRepository productRepository, IUnitOfWork unitOfWork, GetProductsByCategory getProductsByCategoryHandler)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
            _getProductsByCategoryHandler = getProductsByCategoryHandler;
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
            var response =await _getProductsByCategoryHandler.Handler(id);
            return response;

        }
    }
}
