using System;
using API.DTOs.AvatarSkill;
using API.Models;

namespace API.Mapper
{
    public static class AvatarSkillMapper
    {
        public static AvatarSkillDto ToSkillDto(this AvatarSkill avatarSkill)
        {
            return new AvatarSkillDto
            {
                Id = avatarSkill.Id,
                Speed = avatarSkill.Speed,
                Strength = avatarSkill.Strength,
                Stamina = avatarSkill.Stamina,
                Agility = avatarSkill.Agility,
                Balance = avatarSkill.Balance,
                Attack = avatarSkill.Attack,
                Dribbling = avatarSkill.Dribbling,
                Shooting = avatarSkill.Shooting,
                BallControll = avatarSkill.BallControll,
                Passing = avatarSkill.Passing,
                BoxToBox = avatarSkill.BoxToBox,
                Defense = avatarSkill.Defense,
                Marking = avatarSkill.Marking,
                Tackling = avatarSkill.Tackling,
                Diving = avatarSkill.Diving,
                Handling = avatarSkill.Handling,
                Reflexes = avatarSkill.Reflexes,
                AvatarId = avatarSkill.AvatarId
            };
        }

        public static AvatarSkill ToCreateSkillDto (this CreateAvatarSkillDto skillDto, int AvatarId)
        {
            return new AvatarSkill
            {
                Speed = skillDto.Speed,
                Strength = skillDto.Strength,
                Stamina = skillDto.Stamina,
                Agility = skillDto.Agility,
                Balance = skillDto.Balance,
                Attack = skillDto.Attack,
                Dribbling = skillDto.Dribbling,
                Shooting = skillDto.Shooting,
                BallControll = skillDto.BallControll,
                Passing = skillDto.Passing,
                BoxToBox = skillDto.BoxToBox,
                Defense = skillDto.Defense,
                Marking = skillDto.Marking,
                Tackling = skillDto.Tackling,
                Diving = skillDto.Diving,
                Handling = skillDto.Handling,
                Reflexes = skillDto.Reflexes,
                AvatarId = AvatarId
            };
        }

        public static AvatarSkill ToUpdateSkillDto (this UpdateAvatarSkillDto skillDto)
        {
            return new AvatarSkill{
                
                Speed = skillDto.Speed,
                Strength = skillDto.Strength,
                Stamina = skillDto.Stamina,
                Agility = skillDto.Agility,
                Balance = skillDto.Balance,
                Attack = skillDto.Attack,
                Dribbling = skillDto.Dribbling,
                Shooting = skillDto.Shooting,
                BallControll = skillDto.BallControll,
                Passing = skillDto.Passing,
                BoxToBox = skillDto.BoxToBox,
                Defense = skillDto.Defense,
                Marking = skillDto.Marking,
                Tackling = skillDto.Tackling,
                Diving = skillDto.Diving,
                Handling = skillDto.Handling,
                Reflexes = skillDto.Reflexes,
            };
        }
    }
}
