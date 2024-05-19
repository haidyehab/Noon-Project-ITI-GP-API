using AliExpress.Dtos.Product;
using AliExpress.Dtos.Rate;
using AliExpress.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliExpress.Application.Mapper
{
    public class MappingRate:Profile
    {
        public MappingRate()
        {
            CreateMap<Rate, RateDto>().ReverseMap();
        }

    }
}
