using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTO.Review
{
    public class ReviewDto
    {
        public int Id { get; set; }

        [Range(1,10)]
        public int Rating {get; set; }
        
        [Required]
        public string Description { get; set; } = string.Empty;
        
        public int? TshirtId { get; set; }

    }
}