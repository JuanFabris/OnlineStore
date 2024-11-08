using System.ComponentModel.DataAnnotations;
using API.DTOs.AvatarSkill;
using API.Models;

public class AvatarDto
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Username is required")]
    [StringLength(50, ErrorMessage = "Username can't be longer than 50 characters")]
    public string Username { get; set; } = string.Empty;

    [Required(ErrorMessage = "Favourite Foot is required")]
    [RegularExpression("^(Left|Right|Ambidextrous)$", ErrorMessage = "Favourite Foot must be 'Left', 'Right', or 'Ambidextrous'")]
    public string FavouriteFoot { get; set; } = string.Empty;

    [Required(ErrorMessage = "Role is required")]
    [StringLength(50, ErrorMessage = "Role can't be longer than 50 characters")]
    public string Role { get; set; } = string.Empty;

    public bool PlayOtherRoles { get; set; }

    [Range(1.0, 2.5, ErrorMessage = "If you are lower than 1.0m or taller than 2.5m you can't play")]
    public decimal Height { get; set; }

    [Range(30.0, 200.0, ErrorMessage = "Oh dear..")]
    public decimal Weight { get; set; }

    [Range(0, 50, ErrorMessage = "Experience must be between 0 and 50 years")]
    public int Experience { get; set; }
    public List<AvatarSkillDto> Skills { get; set; } = new List<AvatarSkillDto>();
}
