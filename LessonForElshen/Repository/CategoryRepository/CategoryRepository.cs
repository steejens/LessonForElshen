using LessonForElshen.Entities;

namespace LessonForElshen.Repository.CategoryRepository
{
    public class CategoryRepository:Repository<Category>,ICategoryRepository
    {
        public CategoryRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
