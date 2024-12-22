using ExampleGraphQL.DAO;
using ExampleGraphQL.Models;

namespace ExampleGraphQL.Data
{
    public class Query
    {
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        [GraphQLDescription("Method used to get list of all Posts")]
        public IQueryable<Post> GetPosts([Service] IPostRepository post) => post.GetPostsOnly();
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        [GraphQLDescription("Method used to get list of all Comments")]
        public IQueryable<Comment> GetComments([Service] ICommentRepository comment) => comment.GetAllComments();

    }
}
