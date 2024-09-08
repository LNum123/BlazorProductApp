using BlazorProduct.Models;
using BlazorProduct.Web.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Threading.Tasks;

namespace BlazorProduct.Web.Pages
{
    public class ProductDetailsBase : ComponentBase
    {
        public Product Product { get; set; } = new Product();

        protected string Coordinates { get; set; }

        protected string HideButton { get; set; } = "Hide Footer";

        protected string CssClass { get; set; } = null;

        [Inject]
        public IProductService ProductService { get; set; }

        [Parameter]
        public string Id { get; set; }

        protected async override Task OnInitializedAsync()
        {
            Id = Id ?? "d9ee4d98-d4ac-410f-ad88-22cfae7227d1";
           Product = await ProductService.GetProduct(Guid.Parse(Id));
        }

        protected void Hide_Footer()
        {
            if(HideButton == "Hide Footer")
            {
                HideButton = "Show Footer";
                CssClass = "hideFooter";
            }
            else
            {
                CssClass = null; 
                HideButton = "Hide Footer";
            }
        }
    }
}
