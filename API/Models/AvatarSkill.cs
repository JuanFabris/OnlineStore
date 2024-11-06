using System;
using System.Collections.Generic;

namespace API.Models
{
    public class AvatarSkill
    {
        // Physical Skills
        public int Speed { get; set; }
        public int Strength { get; set; }
        public int Stamina { get; set; }
        public int Agility { get; set; }
        public int Balance { get; set; }

        // Offensive Skills
        public int Attack { get; set; }
        public int Dribbling { get; set; }
        public int Passing { get; set; }
        public int Shooting { get; set; }
        public int Finishing { get; set; }

        // Defensive Skills
        public int Defense { get; set; }
        public int Interceptions { get; set; }
        public int Marking { get; set; }
        public int Tackling { get; set; }
        public int Heading { get; set; }

        // Goalkeeper Skills
        public int Diving { get; set; } 
        public int Handling { get; set; }
        public int Kicking { get; set; }
        public int Reflexes { get; set; }

        // Relationships
        public int AvatarId { get; set; }
        public Avatar? Avatar { get; set; }
    }
}
