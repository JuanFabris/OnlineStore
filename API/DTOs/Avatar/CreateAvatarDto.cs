using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;

namespace API.DTOs.Avatar
{
    public class CreateAvatarDto
    {
        public string Username { get; set; } = string.Empty;
        public string FavouriteFoot { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public bool PlayOtherRoles { get; set; }
        public decimal Height { get; set; }
        public decimal Weight { get; set; }
        public int Experience { get; set; }
    }
}