using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Postit.Models;

namespace Postit.PostService
{
    public interface IPostService
    {
        public Task<List<Post>> GetPostsAsync();
        public Task<Post?> GetPostAsync(string id);
        public Task CreatePostAsync(Post newPost);
        public Task UpdatePostAsync(string id, Post updatedPost);
        public Task RemovePostAsync(string Id);
    }
}