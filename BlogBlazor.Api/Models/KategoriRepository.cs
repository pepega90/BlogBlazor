using BlogBlazor.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogBlazor.Api.Models
{
    public class KategoriRepository : IKategoriRepository
    {
        private readonly AppDbContext context;

        public KategoriRepository(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<Kategori> CreateKategori(Kategori kategori)
        {
            var createdKategori = await context.Kategoris.AddAsync(kategori);
            await context.SaveChangesAsync();
            return createdKategori.Entity;
        }

        public async Task<Kategori> GetKategori(int Id)
        {
            return await context.Kategoris.FirstOrDefaultAsync(e => e.Id == Id);
        }

        public async Task<IEnumerable<Kategori>> GetKategoris()
        {
            return await context.Kategoris.ToListAsync();
        }

        public async Task<Kategori> HapusKategori(int Id)
        {
            var deletedKategori = await context.Kategoris.FindAsync(Id);

            if (deletedKategori != null)
            {
                context.Kategoris.Remove(deletedKategori);

                await context.SaveChangesAsync();

                return deletedKategori;
            }

            return null;
        }
    }
}
