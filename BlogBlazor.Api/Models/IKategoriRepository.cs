using BlogBlazor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogBlazor.Api.Models
{
    public interface IKategoriRepository
    {
        Task<IEnumerable<Kategori>> GetKategoris();
        Task<Kategori> CreateKategori(Kategori kategori);
        Task<Kategori> GetKategori(int Id);
        Task<Kategori> HapusKategori(int Id);
    }
}
