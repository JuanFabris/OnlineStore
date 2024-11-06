using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;

namespace API.Mapper
{
    public static class AvatarMapper
    {
        public static AvatarDto toAvatarDto (this Avatar avatarModel)
        {
            return new AvatarDto
            {
                Id = avatarModel.Id,
                PreferredFoot = avatarModel.PreferredFoot,
                Role = avatarModel.Role,
                PlayOtherRoles = avatarModel.PlayOtherRoles,
                Height = avatarModel.Height,
                Weight = avatarModel.Weight,
                Experience = avatarModel.Experience,
                //Skills = avatarModel.Skill.Select(x => x.toSkillDto())
            };
        }
    }
}