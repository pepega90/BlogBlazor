using BlogBlazor.Models;
using BlogBlazor.Web.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogBlazor.Web.ComponentBaseClass
{
    public class EditBase : ComponentBase
    {
        [Inject]
        public IPostService postService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Inject]
        public IKategoriService kategoriService { get; set; }


        [Parameter]
        public string Id { get; set; }

        protected List<Kategori> Kategoris { get; set; } = new List<Kategori>();

        public Post Post { get; set; } = new Post();

        protected async override Task OnInitializedAsync()
        {
            Id = Id ?? "1";
            Post = await postService.GetPost(int.Parse(Id));
            Kategoris = (await kategoriService.GetKategoris()).ToList();
        }

        protected async Task EditPost()
        {
            await postService.UpdatePost(Post);

            NavigationManager.NavigateTo($"/postdetails/{Post.Id}");
        }
    }
}
