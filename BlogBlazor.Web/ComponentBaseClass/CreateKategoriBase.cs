using BlogBlazor.Models;
using BlogBlazor.Web.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogBlazor.Web.ComponentBaseClass
{
    public class CreateKategoriBase : ComponentBase
    {
        [Inject]
        public IKategoriService kategoriService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        protected Kategori Kategori { get; set; } = new Kategori();
        protected List<Kategori> listKategori { get; set; } = new List<Kategori>();

        protected async override Task OnInitializedAsync()
        {
            listKategori = (await kategoriService.GetKategoris()).ToList();
        }

        protected async Task AddKategori()
        {
            await kategoriService.CreateKategori(Kategori);
            await OnInitializedAsync();
            Kategori.KategoriName = string.Empty;
        }

        protected async Task DeleteKategori(int id)
        {
            var deletedKategori = await kategoriService.GetKategori(id);

            if (deletedKategori != null)
            {
                await kategoriService.HapusKategori(id);

                await OnInitializedAsync();
            }
        }
    }
}
