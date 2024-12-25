using ExampleGraphQL.Models;

namespace ExampleGraphQL.DAO
{
    public interface IPostRepository
    {
        IQueryable<Post> GetAllPostsWithComments();
        IQueryable<Post> GetPostsOnly();
        Task<Post> GetPostById(int Id);
        Task<Post> AddPost(Post post);
        Task<bool> DeletePost(int id);
        Task<Post> UpdatePost(Post model);
    }
}
