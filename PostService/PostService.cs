using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Postit.Models;
using MongoDB.Driver;
using Microsoft.Extensions.Options;

namespace Postit.PostService
{
    public class PostService : IPostService
    {
        private readonly IMongoCollection<Post> _postsCollection;
        public PostService(IOptions<PostDatabaseSettings> postDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                postDatabaseSettings.Value.ConnectionString
            );

            var mongoDatabase = mongoClient.GetDatabase(
                postDatabaseSettings.Value.DatabaseName
            );

            _postsCollection = mongoDatabase.GetCollection<Post>(
                postDatabaseSettings.Value.PostCollectionName
            );
        }

        public async Task CreatePostAsync(Post newPost)
        {
            await _postsCollection.InsertOneAsync(newPost);
        }

        public async Task<Post?> GetPostAsync(string id)
        {
            var post = await _postsCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
            return (Post?)post;
        }

        public async Task<List<Post>> GetPostsAsync()
        {
            var posts = await _postsCollection.Find(_ => true).ToListAsync();
            return posts;
        }

        public Task RemovePostAsync(string Id)
        {
            throw new NotImplementedException();
        }

        public Task UpdatePostAsync(string id, Post updatedPost)
        {
            throw new NotImplementedException();
        }
    }
}