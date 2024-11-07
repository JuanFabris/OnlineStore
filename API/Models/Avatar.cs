using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    // public enum Foot
    // {
    //     Left,
    //     Right,
    //     Both
    // }

    // public enum PlayerRole
    // {
    //     Goalkeeper,
    //     Defender,
    //     Midfielder,
    //     Forward
    // }

    public class Avatar
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string FavouriteFoot { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public bool PlayOtherRoles { get; set; }
        public decimal Height { get; set; }
        public decimal Weight { get; set; }
        public int Experience { get; set; }
        public List<AvatarSkill> Skill { get; set; } = new List<AvatarSkill>();
    }
}
