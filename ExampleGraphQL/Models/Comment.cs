using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExampleGraphQL.Models
{
    public class Comment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
        [Required]
        public string Author { get; set; }
        [ForeignKey("PostId")]
        public int PostId { get; set; }
        public Post? Post { get; set; }
        public Comment()
        {
            CreatedAt = DateTime.Now;
        }
    }
}
