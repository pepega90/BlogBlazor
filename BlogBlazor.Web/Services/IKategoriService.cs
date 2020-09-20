using BlogBlazor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogBlazor.Web.Services
{
    public interface IKategoriService
    {
        Task<IEnumerable<Kategori>> GetKategoris();
        Task<Kategori> CreateKategori(Kategori kategori);
        Task<Kategori> GetKategori(int Id);
        Task HapusKategori(int Id);
    }
}
