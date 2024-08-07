using LessonForElshen.Commands.Categories.Responses;

namespace LessonForElshen.Queries.Product.Responses
{
    public class ProductResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public CategoryResponse? Category { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Count { get; set; }
    }
}
