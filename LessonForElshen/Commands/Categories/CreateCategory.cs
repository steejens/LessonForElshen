using LessonForElshen.Commands.Categories.Requests;
using LessonForElshen.Commands.Categories.Responses;
using LessonForElshen.Entities;
using LessonForElshen.Repository;
using LessonForElshen.Repository.CategoryRepository;

namespace LessonForElshen.Commands.Categories
{
    public class CreateCategory
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateCategory(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
        {
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<CreateCategoryResponse> Handler(CreateCategoryRequest request)
        {
            var response = new CreateCategoryResponse();
            var newCategory = new Category()
            {
                Title = request.Title,
                Status = 1,
                CreateDate = DateTime.Now
            };
            try
            {

                await _categoryRepository.AddAsync(newCategory);
                await _unitOfWork.CompleteAsync(CancellationToken.None);
            }
            catch
            {
                response.Message = "not successful";
                return response;
            }

            var newCategoryResponse = new CategoryResponse()
            {
                Id = newCategory.Id,
                Title = request.Title
            };
            response.Message = "success";
            response.Response = newCategoryResponse;
            return response;
        }
    }
}
