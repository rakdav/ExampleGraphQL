﻿using ExampleGraphQL.Models;
using Microsoft.EntityFrameworkCore;

namespace ExampleGraphQL.DAO
{
    public class PostRepository
    {
        private readonly BlogDbContext db;
        public PostRepository(BlogDbContext db)
        {
            this.db = db;
        }
        public List<Post> GetAllPostOnly()
        {
            return db.Posts.ToList();
        }
        public List<Post> GetAllPostsWithComments() 
        {
            return db.Posts.Include(d => d.Comments).ToList();
        }
        public async Task<Post> AddPost(string title,string content,string author)
        {
            Post post = new Post()
            {
                Author = author,
                Content = content,
                Title = title
            };
            db.Posts.Add(post);
            await db.SaveChangesAsync();
            return post;
        }
        public async Task<Post> UpdatePost(Post model)
        {
            var post = await db.Posts.Where(p => p.Id == model.Id).FirstOrDefaultAsync();
            if (post != null)
            {
                if (!string.IsNullOrEmpty(model.Title))
                    post.Title = model.Title;
                if (!string.IsNullOrEmpty(model.Content))
                    post.Content = model.Content;
                if (!string.IsNullOrEmpty(model.Author))
                    post.Author = model.Author;
                post.CreateAt = DateTime.Now;
                db.Posts.Update(post);
                await db.SaveChangesAsync();
            }
            return post!;
        }
        public async Task DeletePost(Guid id)
        {
            var post = await db.Posts.Where(p => p.Id == id).FirstOrDefaultAsync();
            if (post != null)
            {
                db.Posts.Remove(post);
                await db.SaveChangesAsync();
            }
        }
        public Post GetPostById(Guid Id)
        {
            var post = db.Posts.Include(p => p.Comments).
                FirstOrDefault(p=>p.Id==Id);
            if (post != null) return post;
            return null!;
        }
    }
}
