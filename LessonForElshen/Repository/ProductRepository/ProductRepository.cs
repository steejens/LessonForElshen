using LessonForElshen.Entities;

namespace LessonForElshen.Repository.ProductRepository
{
    public class ProductRepository:Repository<Product>,IProductRepository
    {
        public ProductRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
