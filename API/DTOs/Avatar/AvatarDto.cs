using API.DTOs.AvatarSkill;
using API.Models;

public class AvatarDto
{
    public int Id { get; set; }
    public string Username { get; set; } = string.Empty;
    public string FavouriteFoot { get; set; } = string.Empty;
    public string Role { get; set; } = string.Empty;
    public bool PlayOtherRoles { get; set; }
    public decimal Height { get; set; }
    public decimal Weight { get; set; }
    public int Experience { get; set; }
    public List<AvatarSkillDto> Skills { get; set; } = new List<AvatarSkillDto>();
}
