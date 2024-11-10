using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

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
        
        //public int Experience { get; set; }
        public int Rating
        {
            get
            {
                if (Skill == null || !Skill.Any())
                {
                    return 0;
                }

                var Skills = Skill.SelectMany(s => new int []
                {
                    s.Speed, s.Strength, s.Stamina, s.Agility, s.Balance,
                    s.Attack, s.Dribbling, s.Shooting, s.BallControll,
                    s.Passing, s.Defense, s.Marking, s.Tackling,
                    // s.Diving, s.Handling, s.Reflexes
                });

                return (int)Skills.Average();
            }
        }
        public List<AvatarSkill> Skill { get; set; } = new List<AvatarSkill>();
    }
}
