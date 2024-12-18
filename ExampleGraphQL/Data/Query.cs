using ExampleGraphQL.Models;

namespace ExampleGraphQL.Data
{
    public class Query
    {
        [Serial]
        [UsePaging]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Post> GetPosts([Service] BlogDbContext context) => context.Posts;
        [Serial]
        [UsePaging]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Comment> GetComments([Service] BlogDbContext context) => context.Comments;
    }
}
