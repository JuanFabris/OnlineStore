using System;
using System.Collections.Generic;

namespace API.Models
{
    public class AvatarSkill
    //L'idea è che i giocatori abbiano tutti i parametri indifferentemenete dal ruolo preferito, ma verranno messe in 'evidenza' quelle corrispettive alla posizione scelta.
    {
        public int Id { get; set; }
        
        // Physical Skills (Indifferente per tutti)
        public int Speed { get; set; }
        public int Strength { get; set; }
        public int Stamina { get; set; }
        public int Agility { get; set; }
        public int Balance { get; set; }

        
        // Offensive Skills
        public int Attack { get; set; }
        public int Dribbling { get; set; }
        public int Shooting { get; set; }

        //Midfilder Skills
        public int BallControll { get; set; }
        public int Passing { get; set; }
        public bool BoxToBox { get; set; } // Corre su e giù

        // Defensive Skills
        public int Defense { get; set; }
        public int Marking { get; set; }
        public int Tackling { get; set; }
        
        // Goalkeeper Skills
        public int Diving { get; set; } 
        public int Handling { get; set; } //Rinvio
        public int Reflexes { get; set; }

        
        // Relazioni <3
        public int? AvatarId { get; set; }
        public Avatar? Avatar { get; set; }

        // Associo ruolo con skills
        // public List<string> GetRelevantSkills(PlayerRole role)
        // {
        //     var relevantSkills = new List<string>();

        //     switch (role)
        //     {
        //         case PlayerRole.Forward:
        //             relevantSkills.Add(nameof(Attack));
        //             relevantSkills.Add(nameof(Dribbling));
        //             relevantSkills.Add(nameof(Shooting));
        //             break;

        //         case PlayerRole.Midfielder:
        //             relevantSkills.Add(nameof(Passing));
        //             relevantSkills.Add(nameof(BallControll));
        //             relevantSkills.Add(nameof(BoxToBox));
        //             break;

        //         case PlayerRole.Defender:
        //             relevantSkills.Add(nameof(Defense));
        //             relevantSkills.Add(nameof(Tackling));
        //             relevantSkills.Add(nameof(Marking));
        //             break;

        //         case PlayerRole.Goalkeeper:
        //             relevantSkills.Add(nameof(Diving));
        //             relevantSkills.Add(nameof(Handling));
        //             relevantSkills.Add(nameof(Reflexes));
        //             break;
        //     }

        //     return relevantSkills;
        // }
    }
}
