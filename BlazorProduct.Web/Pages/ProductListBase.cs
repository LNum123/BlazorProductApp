
using BlazorProduct.Models;
using BlazorProduct.Web.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorProduct.Web.Pages
{
    public class ProductListBase : ComponentBase
    {
        [Inject]
        public IProductService ProductService { get; set; }

        public bool ShowFooter { get; set; } = true;
        public IEnumerable<Product> Products { get; set; }

        protected override async Task OnInitializedAsync()
        {
            /*await Task.Run(LoadProducts);*/

            Products =(await ProductService.GetProducts()).ToList();
        }

        protected async Task ProductDelete()
        {
            Products = (await ProductService.GetProducts()).ToList();
        }

        //private void LoadProducts()
        //{
        //    System.Threading.Thread.Sleep(2000);
        //    Product p1 = new Product
        //    {
        //        Id = Guid.NewGuid(),
        //        Name = "Wireless Mouse",
        //        Model = "MX1000",
        //        PartNumber = "WMX1000-123",
        //        Quantity = 50,
        //        Price = 29.99M,
        //        DateTimeCaptured = DateTime.UtcNow,
        //    };
        //    Product p2 = new Product
        //    {
        //        Id = Guid.NewGuid(),
        //        Name = "Mechanical Keyboard",
        //        Model = "MK450",
        //        PartNumber = "MK450-456",
        //        Quantity = 30,
        //        Price = 89.99M,
        //        DateTimeCaptured = DateTime.UtcNow,
        //    };
        //    Product p3 = new Product
        //    {
        //        Id = Guid.NewGuid(),
        //        Name = "Gaming Headset",
        //        Model = "GH200",
        //        PartNumber = "GH200-789",
        //        Quantity = 25,
        //        Price = 59.99M,
        //        DateTimeCaptured = DateTime.UtcNow,
        //    };
        //    Product p4 = new Product
        //    {
        //        Id = Guid.NewGuid(),
        //        Name = "4K Monitor",
        //        Model = "UHD27",
        //        PartNumber = "UHD27-101",
        //        Quantity = 10,
        //        Price = 299.99M,
        //        DateTimeCaptured = DateTime.UtcNow,
        //    };
        //    Product p5 = new Product
        //    {
        //        Id = Guid.NewGuid(),
        //        Name = "External Hard Drive",
        //        Model = "XH1TB",
        //        PartNumber = "XH1TB-102",
        //        Quantity = 75,
        //        Price = 59.99M,
        //        DateTimeCaptured = DateTime.UtcNow,
        //    };

        //    Products = new List<Product> { p1, p2, p3, p4, p5 };

        //}
    }
}
