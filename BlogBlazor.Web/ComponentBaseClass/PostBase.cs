using BlogBlazor.Models;
using BlogBlazor.Web.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogBlazor.Web.ComponentBaseClass
{
    public class PostBase : ComponentBase
    {
        [Inject]
        public IPostService postService { get; set; }
        [Parameter]
        public Post SinglePost { get; set; }
        [Parameter]
        public EventCallback<int> OnDeletePost { get; set; }

        protected Components.ConfirmBase DeleteConfirmation { get; set; }

        protected void ShowModalDelete()
        {
            DeleteConfirmation.Show();
        }

        protected async Task ConfirmDelete(bool deleteConfirm)
        {
            if (deleteConfirm)
            {
                await postService.DeletePost(SinglePost.Id);
                await OnDeletePost.InvokeAsync(SinglePost.Id);
            }
        }
    }
}
