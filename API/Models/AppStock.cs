using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    [Table("AppStock")]
    public class AppStock
    {
        public string AppUserId { get; set; }
        public int TShirtId { get; set; }
        public AppUser AppUser { get; set; }
        public TShirt TShirt { get; set; }
    }
}