using ExampleGraphQL.Models;

namespace ExampleGraphQL.DAO
{
    public interface IPostRepository
    {
        IQueryable<Post> GetAllPostsWithComments();
        IQueryable<Post> GetPostsOnly();
        Post GetPostById(Guid Id);
        Post AddPost(Post post);
    }
}
