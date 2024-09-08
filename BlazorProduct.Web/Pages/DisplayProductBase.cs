using BlazorProduct.Models;
using BlazorProduct.Web.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.ComponentModel;
using System.Threading.Tasks;

namespace BlazorProduct.Web.Pages
{
    public class DisplayProductBase : ComponentBase
    {
        [Parameter]
        public Product Product { get; set; }
        [Parameter]
        public bool ShowFooter { get; set; }

        [Parameter]
        public EventCallback<Guid> OnProductDelete { get; set; }

        [Inject]
        public IProductService ProductService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        protected PComponents.ConfirmBase DeleteConfirmation { get; set; }


        //protected void Delete_Click()
        //{
        //    DeleteConfirmation.Show();
        //}

        //protected async Task ConfirmDelete_Click(bool deleteConfirmed)
        //{
        //    if (deleteConfirmed)
        //    {
        //        await ProductService.DeleteProduct(Product.Id);
        //        await OnProductDelete.InvokeAsync(Product.Id);
        //    }
        //}
        protected async Task Delete_Click()
        {
            await ProductService.DeleteProduct(Product.Id);
            await OnProductDelete.InvokeAsync(Product.Id);
            //NavigationManager.NavigateTo("/",true);
        }
    }
}
