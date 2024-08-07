using LessonForElshen.Commands.Categories;
using LessonForElshen.Commands.Categories.Requests;
using LessonForElshen.Commands.Categories.Responses;
using LessonForElshen.Repository;
using LessonForElshen.Repository.CategoryRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CategoryResponse = LessonForElshen.Commands.Categories.Responses.CategoryResponse;

namespace LessonForElshen.Controllers
{
    public class CategoryController: BaseController
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly CreateCategory _createCategory;

        public CategoryController(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork, CreateCategory createCategory)
        {
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
            _createCategory = createCategory;
        }

        [Produces("application/json")]
        [HttpPost]
        public async Task<CreateCategoryResponse> Add([FromBody] CreateCategoryRequest request)

        {
            var response =await _createCategory.Handler(request);
            return response;

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
