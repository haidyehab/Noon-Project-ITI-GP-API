using AliExpress.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliExpress.Dtos.Rate
{
    public class RateUpdateDto
    {

        
        public RatingType Type { get; set; } // e.g., expensive, cheap, medium, bad, good, excellent
        public string Comment { get; set; } // Additional feedback from the user

        public int DegreeRate { get; set; }
      
    }
}
