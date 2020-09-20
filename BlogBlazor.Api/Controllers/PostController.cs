using BlogBlazor.Api.Models;
using BlogBlazor.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogBlazor.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostRepository postRepository;

        public PostController(IPostRepository postRepository)
        {
            this.postRepository = postRepository;
        }

        [HttpGet] // Get All Post
        public async Task<ActionResult> GetAllPost()
        {
            try
            {
                return Ok(await postRepository.GetPosts());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error saat mengambil seluruh post");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> GetPost(int id)
        {
            try
            {
                var post = await postRepository.FindPostById(id);

                if (post == null)
                    return NotFound();

                return Ok(post);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                   $"Error saat mengambil post dengan id = {id}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Post>> CreatePost(Post post)
        {
            try
            {
                if (post == null)
                    return NotFound();

                var createdPost = await postRepository.BuatPost(post);

                return CreatedAtAction(nameof(GetPost), new { id = createdPost.Id }, createdPost);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                   $"Error saat sedang membuat post");
            }
        }

        [HttpPut]
        public async Task<ActionResult<Post>> UpdatePost(Post post)
        {
            try
            {
                var updatePost = await postRepository.FindPostById(post.Id);

                if (updatePost == null)
                    return NotFound($"Post dengan id = {updatePost.Id} tidak ditemukan");

                return await postRepository.UpdatePost(post);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                                  $"Error saat sedang meng-update post");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Post>> DeletePost(int id)
        {
            try
            {
                var deletedPost = await postRepository.FindPostById(id);

                if (deletedPost == null)
                    return NotFound($"Post dengan id = {deletedPost.Id} tidak ditemukan");

                return await postRepository.DeletePost(deletedPost.Id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                                 $"Error saat sedang meng-hapus post");
            }
        }

        [HttpGet("{search}")]
        public async Task<ActionResult<IEnumerable<Post>>> SearchPost(string title)
        {
            try
            {

                var searchingPost = await postRepository.CariPost(title);

                if (searchingPost.Any())
                    return Ok(searchingPost);

                return NotFound();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                                $"Error saat sedang mencari post");
            }
        }
    }
}
