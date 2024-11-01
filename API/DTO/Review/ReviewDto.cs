using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTO.Review
{
    public class ReviewDto
    {
        public int Id { get; set; }
        public int Rating {get; set; }
        public string Description { get; set; } = string.Empty;
        public int? TshirtId { get; set; }

    }
}