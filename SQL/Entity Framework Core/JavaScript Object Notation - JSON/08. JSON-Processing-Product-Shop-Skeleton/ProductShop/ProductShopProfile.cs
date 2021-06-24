using AutoMapper;
using ProductShop.DataTransferObjects;
using ProductShop.Models;
using System.Linq;

namespace ProductShop
{
    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            this.CreateMap<UserInputModel, User>();
            this.CreateMap<ProductInputModel, Product>();
            this.CreateMap<CategoryInputModel, Category>();
            this.CreateMap<CategoryProductInputModel, CategoryProduct>();

            //this.CreateMap<Category, CategoriesByProductsCountModel>()
            //    .ForMember(x => x.Category , y => y.MapFrom(s => s.Name))
            //    .ForMember(x => x.ProductsCount , y => y.MapFrom(s => s.CategoryProducts.Select(cp => cp.Product).Count()))
            //    .ForMember(x => x.ProductsCount , y => y.MapFrom(s => s.CategoryProducts.Select(cp => cp.Product.Price).Average().ToString("f2")))
            //    .ForMember(x => x.ProductsCount , y => y.MapFrom(s => s.CategoryProducts.Select(cp=> cp.Product.Price).Sum().ToString("f2")));
        }
    }
}
