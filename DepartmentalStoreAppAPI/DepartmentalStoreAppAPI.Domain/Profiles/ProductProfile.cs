using AutoMapper;
using DepartmentalStoreAppAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartmentalStoreAppAPI.Domain.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            this.CreateMap<Product, ProductModel>().ReverseMap();
            this.CreateMap<Inventory, InventoryModel>().ReverseMap();
            this.CreateMap<ProductDetail, ProductDetailModel>().ReverseMap();
        }
    }
}
