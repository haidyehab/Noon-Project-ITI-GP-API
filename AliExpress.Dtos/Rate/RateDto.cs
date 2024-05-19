using AliExpress.Dtos.Cart;
using AliExpress.Dtos.Product;
using AliExpress.Dtos.User;
using AliExpress.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliExpress.Dtos.Rate
{
    public class RateDto
    {
        
       
        public int? Id { get; set; }
        public RatingType Type { get; set; } // e.g., expensive, cheap, medium, bad, good, excellent
        public string Comment { get; set; } // Additional feedback from the user

        public int DegreeRate { get; set; }
        public String UserId { get; set; }
        public int ProductId { get; set; }


        
    }
}
