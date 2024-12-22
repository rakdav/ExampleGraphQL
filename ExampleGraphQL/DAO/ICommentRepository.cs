using ExampleGraphQL.Models;

namespace ExampleGraphQL.DAO
{
    public interface ICommentRepository
    {
        IQueryable<Comment> GetAllComments();
    }
}
