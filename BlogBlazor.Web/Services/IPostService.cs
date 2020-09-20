using BlogBlazor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogBlazor.Web.Services
{
    public interface IPostService
    {

        Task<IEnumerable<Post>> GetAllPost();
        Task<Post> CreatePost(Post createdPost);
        Task<Post> UpdatePost(Post editedPost);
        Task<Post> GetPost(int Id);

        Task DeletePost(int Id);

        Task<IEnumerable<Post>> CariPost(string search);
    }
}
