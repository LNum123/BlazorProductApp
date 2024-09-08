using AutoMapper;
using BlazorProduct.Models;

namespace BlazorProduct.Web.Models
{
    public class ProductProfile :Profile
    {
        public ProductProfile() {
            CreateMap<Product, EditProductModel>();
            CreateMap<EditProductModel, Product>();

            //custom mapping
            //CreateMap<Product, EditProductModel>().ForMember(dest => dest.ConfirmPartNumber, opt => opt.MapFrom(src => src.PartNumber));
        }
    }
}
