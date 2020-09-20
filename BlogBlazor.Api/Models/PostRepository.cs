using BlogBlazor.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogBlazor.Api.Models
{
    public class PostRepository : IPostRepository
    {
        private readonly AppDbContext context;

        public PostRepository(AppDbContext context)
        {
            this.context = context;
        }
        public async Task<Post> BuatPost(Post createdPost)
        {
            var result = await context.Posts.AddAsync(createdPost);
            await context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<IEnumerable<Post>> CariPost(string search)
        {
            IQueryable<Post> query = context.Posts;

            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(e => e.Title.Contains(search) ||
                                         e.Author.Contains(search) ||
                                         e.Kategori.KategoriName.Contains(search));
            }

            return await query.Include(e => e.Kategori).ToListAsync();
        }

        public async Task<Post> DeletePost(int Id)
        {
            var deletedPost = await context.Posts.FirstOrDefaultAsync(e => e.Id == Id);

            if (deletedPost != null)
            {
                context.Posts.Remove(deletedPost);
                await context.SaveChangesAsync();
                return deletedPost;
            }

            return null;

        }

        public async Task<Post> UpdatePost(Post editedPost)
        {
            var findPost = await context.Posts.FirstOrDefaultAsync(e => e.Id == editedPost.Id);

            if (findPost != null)
            {
                findPost.Title = editedPost.Title;
                findPost.Author = editedPost.Author;
                findPost.Body = editedPost.Body;
                findPost.KategoriId = editedPost.KategoriId;
                findPost.Summary = editedPost.Summary;

                await context.SaveChangesAsync();

                return findPost;
            }
            return null;
        }

        public async Task<Post> FindPostById(int Id)
        {
            return await context.Posts.FirstOrDefaultAsync(e => e.Id == Id);
        }

        public async Task<IEnumerable<Post>> GetPosts()
        {
            return await context.Posts.Include(e => e.Kategori).ToListAsync();
        }
    }
}
