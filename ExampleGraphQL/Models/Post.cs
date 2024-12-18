using System.ComponentModel.DataAnnotations;

namespace ExampleGraphQL.Models
{
    public class Post
    {
        [Key]
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public DateTime? CreateAt { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public Post()
        {
            Id = Guid.NewGuid();
            CreateAt = DateTime.Now;
        }
    }
}
