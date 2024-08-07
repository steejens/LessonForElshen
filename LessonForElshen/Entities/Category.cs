using System.ComponentModel.DataAnnotations;

namespace LessonForElshen.Entities
{
    public class Category:BaseEntity
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }
    }
}
