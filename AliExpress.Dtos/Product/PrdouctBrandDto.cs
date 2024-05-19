using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliExpress.Dtos.Product
{
    public class PrdouctBrandDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Image { get; set; }
        public string Description { get; set; }
        public string? Name_Ar {  get; set; }
        public int Price { get; set; }
        public string? Description_Ar { get; set; }
        //public int BrandId { get; set; }
        public int BrandId { get; set; }
        public BrandDto? BrandDto { get; set; }
    }
}
