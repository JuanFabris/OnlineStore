using API.Models;

public class AvatarDto
{
    public int Id { get; set; }
    public Foot PreferredFoot { get; set; }
    public PlayerRole Role { get; set; }
    public bool PlayOtherRoles { get; set; }
    public decimal Height { get; set; }
    public decimal Weight { get; set; }
    public string Experience { get; set; } = string.Empty;
    
    //public List<AvatarSkillDto> Skills { get; set; } = new List<AvatarSkillDto>();
}
