using ExampleGraphQL.DAO;
using ExampleGraphQL.Models;
using HotChocolate.Authorization;
using HotChocolate.Subscriptions;
using Microsoft.EntityFrameworkCore;

namespace ExampleGraphQL.Data
{
    public class Mutation
    {

        public async Task<Post?> UpdatePost([Service] IPostRepository postRepository, Post model)
        {
           return await postRepository.UpdatePost(model);
        }

        public async Task<bool> DeletePost([Service] IPostRepository postRepository, int id)
        {
            return await postRepository.DeletePost(id);
        }

        public async Task<Post?> CreatePost(
           [Service]IPostRepository postRepository, 
           string author,
           string content,string title)
        {
            Post newPost = new Post
            {
                Author=author,
                Content=content,
                Title=title
            };
            var createdPost = await postRepository.AddPost(newPost);
            return createdPost;
        }
    }
}
