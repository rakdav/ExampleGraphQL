﻿using ExampleGraphQL.Models;
using HotChocolate.Authorization;
using Microsoft.EntityFrameworkCore;

namespace ExampleGraphQL.Data
{
    public class Mutation
    {
        [Serial]
        public async Task<Post?> UpdatePost([Service]
        BlogDbContext context,Post model)
        {
            var post = await context.Posts.Where(p => p.Id == model.Id).FirstOrDefaultAsync();
            if (post != null)
            {
                if (!string.IsNullOrEmpty(model.Title))
                    post.Title = model.Title;
                if (!string.IsNullOrEmpty(model.Content))
                    post.Content = model.Content;
                if (!string.IsNullOrEmpty(model.Author))
                    post.Author = model.Author;
                post.CreateAt = DateTime.Now;
                context.Posts.Update(post);
                await context.SaveChangesAsync();
            }
            return post;
        }
        [Serial]
        public async Task DeletePost(
            [Service]
        BlogDbContext context, Guid id)
        {
            var post = await context.Posts.Where(p => p.Id ==id).FirstOrDefaultAsync();
            if (post != null)
            {
                context.Posts.Remove(post);
                await context.SaveChangesAsync();
            }
        }
        [Serial]
        public async Task<Post?> InsertPost(
           [Service]
        BlogDbContext context, string author, string content,string title)
        {
            Post post = new Post()
            {
                Author=author,
                Content=content,
                Title=title
            };
            context.Posts.Add(post);
            await context.SaveChangesAsync();
            return post;
        }
    }
}
