using BlogBlazor.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlogBlazor.Web.Services
{
    public class PostService : IPostService
    {
        private readonly HttpClient httpClient;

        public PostService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<Post>> CariPost(string search)
        {
            return await httpClient.GetJsonAsync<Post[]>($"api/post/search?title={search}");
        }

        public async Task<Post> CreatePost(Post createdPost)
        {
            return await httpClient.PostJsonAsync<Post>("api/post", createdPost);
        }

        public async Task DeletePost(int Id)
        {
            await httpClient.DeleteAsync($"api/post/{Id}");
        }

        public async Task<Post> GetPost(int Id)
        {
            return await httpClient.GetJsonAsync<Post>($"api/post/{Id}");
        }

        public async Task<IEnumerable<Post>> GetAllPost()
        {
            return await httpClient.GetJsonAsync<Post[]>("api/post");
        }

        public async Task<Post> UpdatePost(Post editedPost)
        {
            return await httpClient.PutJsonAsync<Post>($"api/post", editedPost);
        }
    }
}
