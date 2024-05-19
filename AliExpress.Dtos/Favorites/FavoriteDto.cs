
using AliExpress.Dtos.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliExpress.Dtos.Favorites
{
    public class FavoriteDto
    {
        public string AppUserId { get; set; }
        public int ProductId { get; set; }
        public List<ProductViewDto> Products { get; set; }
    }
}
