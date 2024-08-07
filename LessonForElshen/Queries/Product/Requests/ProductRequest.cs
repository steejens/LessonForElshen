namespace LessonForElshen.Queries.Product.Requests
{
    public class ProductRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Count { get; set; }
        public int CatId { get; set; }
    }
}
