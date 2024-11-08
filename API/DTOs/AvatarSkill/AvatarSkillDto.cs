using System.ComponentModel.DataAnnotations;

namespace API.DTOs.AvatarSkill
{
    public class AvatarSkillDto
    {
        public int Id { get; set; }

        [Range(0, 100, ErrorMessage = "Speed must be between 0 and 100")]
        public int Speed { get; set; }

        [Range(0, 100, ErrorMessage = "Strength must be between 0 and 100")]
        public int Strength { get; set; }

        [Range(0, 100, ErrorMessage = "Stamina must be between 0 and 100")]
        public int Stamina { get; set; }

        [Range(0, 100, ErrorMessage = "Agility must be between 0 and 100")]
        public int Agility { get; set; }

        [Range(0, 100, ErrorMessage = "Balance must be between 0 and 100")]
        public int Balance { get; set; }

        [Range(0, 100, ErrorMessage = "Attack must be between 0 and 100")]
        public int Attack { get; set; }

        [Range(0, 100, ErrorMessage = "Dribbling must be between 0 and 100")]
        public int Dribbling { get; set; }

        [Range(0, 100, ErrorMessage = "Shooting must be between 0 and 100")]
        public int Shooting { get; set; }

        [Range(0, 100, ErrorMessage = "Ball Control must be between 0 and 100")]
        public int BallControll { get; set; }

        [Range(0, 100, ErrorMessage = "Passing must be between 0 and 100")]
        public int Passing { get; set; }

        public bool BoxToBox { get; set; }

        [Range(0, 100, ErrorMessage = "Defense must be between 0 and 100")]
        public int Defense { get; set; }

        [Range(0, 100, ErrorMessage = "Marking must be between 0 and 100")]
        public int Marking { get; set; }

        [Range(0, 100, ErrorMessage = "Tackling must be between 0 and 100")]
        public int Tackling { get; set; }

        [Range(0, 100, ErrorMessage = "Diving must be between 0 and 100")]
        public int Diving { get; set; }

        [Range(0, 100, ErrorMessage = "Handling must be between 0 and 100")]
        public int Handling { get; set; }

        [Range(0, 100, ErrorMessage = "Reflexes must be between 0 and 100")]
        public int Reflexes { get; set; }
        
        public int? AvatarId { get; set; }
    }
}
