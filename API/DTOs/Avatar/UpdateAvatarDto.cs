using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using API.Models;

namespace API.DTOs.Avatar
{
    public class UpdateAvatarDto
    {
    public string Role { get; set; } = string.Empty;
    public bool PlayOtherRoles { get; set; }

    [Range(1.0, 2.5, ErrorMessage = "If you are lower than 1.0m or taller than 2.5m you can't play")]
    public decimal Height { get; set; }

    [Range(30.0, 200.0, ErrorMessage = "Oh dear..")]
    public decimal Weight { get; set; }

    // [Range(0, 50, ErrorMessage = "Experience must be between 0 and 50 years")]
    // public int Experience { get; set; }
    }
}