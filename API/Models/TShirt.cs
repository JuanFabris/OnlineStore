using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class TShirt
    {
        public int Id { get; set; }
        public string Brand { get; set; } = string.Empty;
        public string Color { get; set; } = string.Empty;
        public string Season { get; set; } = string.Empty;
        
        [Column(TypeName = "decimal(18,2)")]
        public decimal Prize { get; set; }
        
        public List <Review> Reviews = new List<Review>();
    }
}