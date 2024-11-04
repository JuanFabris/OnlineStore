using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    [Table("Reviews")]
    public class Review
    {
        public int Id { get; set; }
        public int Rating {get; set; }
        public string Description { get; set; } = string.Empty;
        public int? TshirtId { get; set; }
        public TShirt? TShirt { get; set; }
        public string AppUserId { get;  set; } = string.Empty;
        public AppUser AppUser { get; set; }
    }
}