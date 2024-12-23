using ExampleGraphQL.Models;

namespace ExampleGraphQL.DAO
{
    public interface IPostRepository
    {
        IQueryable<Post> GetAllPostsWithComments();
        IQueryable<Post> GetPostsOnly();
        Task<Post> GetPostById(long Id);
        Task<Post> AddPost(Post post);
    }
}
