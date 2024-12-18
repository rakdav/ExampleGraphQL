using ExampleGraphQL.Models;
using Faker;

namespace ExampleGraphQL.Data
{
    public static class DataSeeder
    {
        public static void SeedData(BlogDbContext db)
        {
            if (!db.Posts.Any())
            {
                for(int i = 1; i <= 10; i++)
                {
                    var post = new Post
                    {
                        Title = Lorem.Sentence(),
                        Content = Lorem.Paragraphs(3).FirstOrDefault(),
                        Author = Name.FullName(),
                        CreateAt=DateTime.Now
                    };
                    db.Posts.Add(post);
                    for(int j = 0; j < 10; j++)
                    {
                        var comment = new Comment
                        {
                            Content=Lorem.Sentence(),
                            Author=Name.FullName(),
                            CreatedAt=DateTime.Now,
                            Post=post
                        };
                        db.Comments.Add(comment);
                    }
                }
                db.SaveChanges();
            }
        }
    }
}
