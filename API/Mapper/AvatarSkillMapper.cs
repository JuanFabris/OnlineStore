using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs.AvatarSkill;
using API.Models;

namespace API.Mapper
{
    public static class AvatarSkillMapper
    {
        public static AvatarSkillDto ToAvatarSkillDto (this AvatarSkill avatarSkill)
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

        public static AvatarSkill ToCreateAvatarSkillDto (this CreateAvatarSkillDto avatarDto, int AvatarId)
        {
            return new AvatarSkill
            {
                Speed = avatarDto.Speed,
                Strength = avatarDto.Strength,
                Stamina = avatarDto.Stamina,
                Agility = avatarDto.Agility,
                Balance = avatarDto.Balance,
                Attack = avatarDto.Attack,
                Dribbling = avatarDto.Dribbling,
                Shooting = avatarDto.Shooting,
                BallControll = avatarDto.BallControll,
                Passing = avatarDto.Passing,
                BoxToBox = avatarDto.BoxToBox,
                Defense = avatarDto.Defense,
                Marking = avatarDto.Marking,
                Tackling = avatarDto.Tackling,
                Diving = avatarDto.Diving,
                Handling = avatarDto.Handling,
                Reflexes = avatarDto.Reflexes,
                AvatarId = AvatarId
            };
        }

    }
}