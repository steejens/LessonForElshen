using LessonForElshen.Entities;
using LessonForElshen.Repository;
using LessonForElshen.Repository.CategoryRepository;
using LessonForElshen.RequestTypes;
using LessonForElshen.ResponseTypes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LessonForElshen.Controllers
{
    public class CategoryController: BaseController
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CategoryController(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
        {
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
        }

        [Produces("application/json")]
        [HttpPost]
        public async Task<string> Add([FromBody] CategoryRequest request)

        {

           await _categoryRepository.AddAsync(new Category()
            {
                Title = request.Title,
            });
            await _unitOfWork.CompleteAsync(CancellationToken.None);
            return "success";

        }

        [Produces("application/json")]
        [HttpGet("{id}")]
        public async Task<CategoryResponse> GetCategory([FromRoute] int id)

        {
            var category =await _categoryRepository.GetFirstAsync(x=>x.Id == id);
            var response = new CategoryResponse()
            {
                Id = category.Id,
                Title = category.Title,
            };


            return response;

        }

        [Produces("application/json")]
        [HttpGet("all")]
        public async Task<List<CategoryResponse>> GetAll()

        {
            var categories = await _categoryRepository.GetAll().OrderBy(x=>x.Id).ToListAsync();
            var response = new List<CategoryResponse>();
            foreach (var category in categories)
            {
                var categoryResponse = new CategoryResponse()
                {
                    Id = category.Id,
                    Title = category.Title,
                };
                response.Add(categoryResponse);
            }
            return response;
        }

        [Produces("application/json")]
        [HttpPut("{id}")]
        public async Task<string> Update([FromRoute] int id, [FromBody] string title)

        {
            var category = await _categoryRepository.GetFirstAsync(x => x.Id == id);
            category.Title = title;
            await _unitOfWork.CompleteAsync(CancellationToken.None);

            return "success";

        }
    }
}
