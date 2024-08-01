using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LessonForElshen.Entities
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Count { get; set; }
        [ForeignKey(nameof(Category))]
        public int CatId { get; set; }
        public Category? Category { get; set; }
    }
}
