using AutoMapper;
using BlazorProduct.Models;
using BlazorProduct.Web.Models;
using BlazorProduct.Web.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;

namespace BlazorProduct.Web.Pages
{
    public class EditProductBase : ComponentBase
    {
        [Inject]
        public IProductService ProductService { get; set; }

        public string PageHeaderText { get; set; }

        private Product Product { get; set; } = new Product();

        public EditProductModel  EditProductModel { get; set; } = new EditProductModel();

        [Parameter]
        public string Id { get; set; }

        [Inject]
        public IMapper Mapper { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Guid.TryParse(Id, out Guid productId);

            if(productId != Guid.Empty)
            {
                Product = await ProductService.GetProduct(Guid.Parse(Id));
            }
            else
            {
                Product = new Product
                {
                    DateTimeCaptured= DateTime.Now,
                };
            }



            Mapper.Map(Product, EditProductModel);

            //EditProductModel.Id = Product.Id;
            //EditProductModel.Name = Product.Name;
            //EditProductModel.Model = Product.Model;
            //EditProductModel.PartNumber = Product.PartNumber;
            //EditProductModel.Price = Product.Price;
            //EditProductModel.Quantity = Product.Quantity;
        }


        protected async Task HandleValidSubmit()
        {
            Mapper.Map(EditProductModel,Product);

            Product result = null;

            if (Product.Id != Guid.Empty) 
            {
                PageHeaderText = "Edit Product";
                result = await ProductService.UpdateProduct(Product);
            }
            else
            {
                PageHeaderText = "Create Product";
                result = await ProductService.CreateProduct(Product);
            }



            if(result != null)
            {
                NavigationManager.NavigateTo("/");
            }
        }


        protected async void Delete_Click()
        {
            await ProductService.DeleteProduct(Product.Id);
            NavigationManager.NavigateTo("/");
        }
    }
}
