using BlogBlazor.Models;
using BlogBlazor.Web.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogBlazor.Web.ComponentBaseClass
{
    public class PostDetailsBase : ComponentBase
    {
        [Inject]
        public IPostService postService { get; set; }
        [Parameter]
        public string Id { get; set; }

        public Post Post { get; set; } = new Post();

        protected async override Task OnInitializedAsync()
        {
            Id = Id ?? "1";
            Post = await postService.GetPost(int.Parse(Id));
        }
    }
}
