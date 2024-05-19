using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliExpress.Models
{
    public class Brand
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public string ImagePath_AR { get; set; }
        public ICollection<PrdouctBrand> PrdouctBrands { get; set; }

    }
}
