using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliExpress.Models
{
    public enum RatingType
    {
        Expensive,
        Cheap,
        Medium,
        Bad,
        Good,
        Excellent
    }
    public class Rate : BaseEntity
    {
        // Properties
        public RatingType Type { get; set; } // e.g., expensive, cheap, medium, bad, good, excellent
        public string Comment { get; set; } // Additional feedback from the user

        public int DegreeRate { get; set; }
        // Relationship with the User

        public string UserId { get; set; }
        public int ProductId { get; set; }

        // Navigation properties
        public AppUser User { get; set; }
        public Product Product { get; set; }

        // Constructor
       

    }
}
