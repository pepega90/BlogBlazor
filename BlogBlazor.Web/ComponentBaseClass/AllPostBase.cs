using BlogBlazor.Models;
using BlogBlazor.Web.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;

namespace BlogBlazor.Web.ComponentBaseClass
{
    public class AllPostBase : ComponentBase
    {
        [Inject]
        public IPostService postService { get; set; }

        [Inject]
        public IKategoriService kategoriService { get; set; }
        [Inject]
        public NavigationManager navigationManager { get; set; }

        protected HttpResponseMessage httpMsg { get; set; } = new HttpResponseMessage();


        protected IEnumerable<Post> Posts { get; set; }
        protected List<Kategori> listKategori { get; set; } = new List<Kategori>();

        protected string SearchPost { get; set; }

        protected async override Task OnInitializedAsync()
        {
            Posts = await postService.GetAllPost();

            listKategori = (await kategoriService.GetKategoris()).ToList();
        }


        protected async Task CariPost(ChangeEventArgs e)
        {
            try
            {
                SearchPost = e.Value.ToString();

                if (!string.IsNullOrEmpty(SearchPost))
                {
                    Posts = await postService.CariPost(SearchPost);
                }
                else
                {
                    await OnInitializedAsync();
                }
            }

            catch (Exception)
            {
                httpMsg.StatusCode = System.Net.HttpStatusCode.NotFound;
            }
        }

        protected async Task CariByKategori(ChangeEventArgs e)
        {
            if (listKategori.Any(x => x.KategoriName == e.Value.ToString()))
                Posts = await postService.CariPost(e.Value.ToString());
            else
                await OnInitializedAsync();
        }

        protected async Task DeletePost()
        {
            await OnInitializedAsync();
        }
        protected void backHome()
        {
            navigationManager.NavigateTo("/", true);
        }
    }
}
