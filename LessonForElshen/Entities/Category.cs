using System.ComponentModel.DataAnnotations;

namespace LessonForElshen.Entities
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }
    }
}
