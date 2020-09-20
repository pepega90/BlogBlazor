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
    public class KategoriController : ControllerBase
    {
        private readonly IKategoriRepository kategoriRepository;

        public KategoriController(IKategoriRepository kategoriRepository)
        {
            this.kategoriRepository = kategoriRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Kategori>>> GetAllKategori()
        {
            try
            {
                return Ok(await kategoriRepository.GetKategoris());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error saat mengambil data");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Kategori>> GetKategori(int id)
        {
            try
            {
                var findKategoriById = await kategoriRepository.GetKategori(id);

                if (findKategoriById == null) return NotFound($"Kategori dengan id = {id} tidak ditemukan");

                return findKategoriById;
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error saat mengambil single kategori");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Kategori>> CreatePost(Kategori kategori)
        {
            try
            {
                if (kategori == null)
                    return NotFound();

                var createdKategori = await kategoriRepository.CreateKategori(kategori);

                return CreatedAtAction(nameof(GetKategori), new { id = createdKategori.Id }, createdKategori);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                   $"Error saat sedang membuat post");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Kategori>> DeleteKategori(int id)
        {
            try
            {
                var deletedKategori = await kategoriRepository.GetKategori(id);

                if (deletedKategori == null)
                    return NotFound($"Kategori dengan id = {id} tidak ditemukan");

                return await kategoriRepository.HapusKategori(deletedKategori.Id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error saat sedang menghapus kategori");
            }
        }
    }
}
