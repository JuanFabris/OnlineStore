using System;
using System.Collections.Generic;

namespace API.Models
{
    public enum Foot
    {
        Left,
        Right,
        Both
    }

    public enum PlayerRole
    {
        Goalkeeper,
        Defender,
        Midfielder,
        Forward
    }

    public class Avatar
    {
        public int Id { get; set; }
        public Foot PreferredFoot { get; set; }
        public PlayerRole Role { get; set; }
        public bool PlayOtherRoles { get; set; }
        public decimal Height { get; set; }
        public decimal Weight { get; set; }
        public string Experience { get; set; } = string.Empty;
        public List<AvatarSkill> Skill { get; set; } = new List<AvatarSkill>();
    }
}
