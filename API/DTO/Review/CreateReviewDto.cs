using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTO.Review
{
    public class CreateReviewDto
    {
        [Required]
        public int Rating {get; set; }
        
        [Required]
        public string Description { get; set; } = string.Empty;
    }
}