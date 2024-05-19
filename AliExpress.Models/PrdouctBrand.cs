using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliExpress.Models
{
    public class PrdouctBrand
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string? Name_Ar { get; set; }
        public string? Description_Ar { get; set; }
        public string? Image { get; set; }
        public double Price { get; set; }
        public int BrandId { get; set; }
      
        public Brand Brand { get; set; }
    }
}
