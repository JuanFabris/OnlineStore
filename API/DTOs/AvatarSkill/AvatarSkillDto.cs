using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs.AvatarSkill
{
    public class AvatarSkillDto
    {
        public int Id { get; set; }
        
        public int Speed { get; set; }
        public int Strength { get; set; }
        public int Stamina { get; set; }
        public int Agility { get; set; }
        public int Balance { get; set; }

        public int Attack { get; set; }
        public int Dribbling { get; set; }
        public int Shooting { get; set; }

        public int BallControll { get; set; }
        public int Passing { get; set; }
        public bool BoxToBox { get; set; }

        public int Defense { get; set; }
        public int Marking { get; set; }
        public int Tackling { get; set; }
        
        public int Diving { get; set; } 
        public int Handling { get; set; }
        public int Reflexes { get; set; }

        public int? AvatarId { get; set; }
    }
}