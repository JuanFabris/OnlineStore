using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTO.Account
{
    public class NewUSerDto
    {
        public string? Username { get; set; }
        
        [EmailAddress]
        public string? Email { get; set; }
        
        public string? Token { get; set; }

    }
}