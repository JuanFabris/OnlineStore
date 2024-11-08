using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs.Avatar;
using API.Models;

namespace API.Mapper
{
    public static class AvatarMapper
    {
        public static AvatarDto ToAvatarDto (this Avatar avatarModel)
        {
            return new AvatarDto
            {
                Id = avatarModel.Id,
                Username = avatarModel.Username,
                FavouriteFoot = avatarModel.FavouriteFoot,
                Role = avatarModel.Role,
                PlayOtherRoles = avatarModel.PlayOtherRoles,
                Height = avatarModel.Height,
                Weight = avatarModel.Weight,
                Experience = avatarModel.Experience,
                Skills = avatarModel.Skill.Select(x => x.ToSkillDto()).ToList()
            };
        }

        public static Avatar ToCreateDto (this CreateAvatarDto avatarDto)
        {
            return new Avatar
            {
                FavouriteFoot = avatarDto.FavouriteFoot,
                Username = avatarDto.Username,
                Role = avatarDto.Role,
                PlayOtherRoles = avatarDto.PlayOtherRoles,
                Height = avatarDto.Height,
                Weight = avatarDto.Weight,
                Experience = avatarDto.Experience,
            };
        }

        public static Avatar ToUpdateDto (this UpdateAvatarDto updateAvatarDto)
        {
            return new Avatar
            {
                Role = updateAvatarDto.Role,
                PlayOtherRoles = updateAvatarDto.PlayOtherRoles,
                Height = updateAvatarDto.Height,
                Weight = updateAvatarDto.Weight,
                Experience = updateAvatarDto.Experience,
            };
        }
    }
}