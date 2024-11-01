using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTO
{
    public class UpdateTshirtDto
    {
        public string Brand { get; set; } = string.Empty;
        public string Color { get; set; } = string.Empty;
        public string Season { get; set; } = string.Empty;
        
        [Column(TypeName = "decimal(18,2)")]
        public decimal Prize { get; set; }
    }
}