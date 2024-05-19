using AliExpress.Dtos.Product;
using AliExpress.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliExpress.Application.Mapper
{
    public class MappingBrand:Profile
    {
        public MappingBrand()
        {
            CreateMap<Brand,BrandDto>().ReverseMap();
        }
    }
}
