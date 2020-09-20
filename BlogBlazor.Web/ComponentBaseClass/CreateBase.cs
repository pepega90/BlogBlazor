using BlogBlazor.Models;
using BlogBlazor.Web.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogBlazor.Web.ComponentBaseClass
{
    public class CreateBase : ComponentBase
    {
        [Inject]
        public IPostService postService { get; set; }
        [Inject]
        public IKategoriService kategoriService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        protected Post Post { get; set; } = new Post();
        protected List<Kategori> Kategoris { get; set; } = new List<Kategori>();

        protected async Task CreatePost()
        {
            var createdPost = await postService.CreatePost(Post);

            if (createdPost != null)
                NavigationManager.NavigateTo("/");
        }

        protected async override Task OnInitializedAsync()
        {
            Kategoris = (await kategoriService.GetKategoris()).ToList();
        }
    }
}
