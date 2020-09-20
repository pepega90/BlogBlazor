using BlogBlazor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using Microsoft.AspNetCore.Components;

namespace BlogBlazor.Web.Services
{
    public class KategoriService : IKategoriService
    {
        private readonly HttpClient httpClient;

        public KategoriService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<Kategori> CreateKategori(Kategori kategori)
        {
            return await httpClient.PostJsonAsync<Kategori>("api/kategori", kategori);
        }

        public async Task<Kategori> GetKategori(int Id)
        {
            return await httpClient.GetJsonAsync<Kategori>($"api/kategori/{Id}");
        }

        public async Task<IEnumerable<Kategori>> GetKategoris()
        {
            return await httpClient.GetJsonAsync<Kategori[]>("api/kategori");
        }

        public async Task HapusKategori(int Id)
        {
            await httpClient.DeleteAsync($"api/kategori/{Id}");
        }
    }
}
