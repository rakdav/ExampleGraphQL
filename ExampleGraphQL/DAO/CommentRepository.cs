using ExampleGraphQL.Models;
using Microsoft.EntityFrameworkCore;

namespace ExampleGraphQL.DAO
{
    public class CommentRepository : ICommentRepository
    {
        private readonly BlogDbContext db;
        public CommentRepository(BlogDbContext db)
        {
            this.db = db;
        }
        public IQueryable<Comment> GetAllComments()
        {
            return db.Comments.AsQueryable();
        }

        //public async Task<Comment> AddComment(string author,string content)
        //{
        //    Comment comment = new Comment()
        //    {
        //        Author = author,
        //        Content = content,
        //    };
        //    db.Comments.Add(comment);
        //    await db.SaveChangesAsync();
        //    return comment;
        //}
        //public async Task<Comment> UpdateComment(Comment model)
        //{
        //    var comment = await db.Comments.Where(p => p.Id == model.Id).FirstOrDefaultAsync();
        //    if (comment != null)
        //    {
        //        if (!string.IsNullOrEmpty(model.Content))
        //            comment.Content = model.Content;
        //        if (!string.IsNullOrEmpty(model.Author))
        //            comment.Author = model.Author;
        //        comment.CreatedAt = DateTime.Now;
        //        db.Comments.Update(comment);
        //        await db.SaveChangesAsync();
        //    }
        //    return comment!;
        //}
        //public async Task DeleteComment(Guid id)
        //{
        //    var comment = await db.Comments.Where(p => p.Id == id).FirstOrDefaultAsync();
        //    if (comment != null)
        //    {
        //        db.Comments.Remove(comment);
        //        await db.SaveChangesAsync();
        //    }
        //}

    }
}
