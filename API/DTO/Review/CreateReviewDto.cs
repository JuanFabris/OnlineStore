using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTO.Review
{
    public class CreateReviewDto
    {
        public int Rating {get; set; }
        public string Description { get; set; } = string.Empty;
    }
}