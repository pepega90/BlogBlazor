using BlogBlazor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogBlazor.Api.Models
{
    public interface IPostRepository
    {
        Task<IEnumerable<Post>> GetPosts();
        Task<Post> BuatPost(Post createdPost);
        Task<Post> UpdatePost(Post editedPost);
        Task<Post> FindPostById(int Id);

        Task<Post> DeletePost(int Id);

        Task<IEnumerable<Post>> CariPost(string search);
    }
}
