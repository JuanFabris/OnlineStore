using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTO;
using API.Models;

namespace API.Mappers
{
    public static class TShirtMapper
    {

        public static TShirtDto IntoTShirtDto (this TShirt tShirtModel )
        {
                return new TShirtDto
                {
                    Id = tShirtModel.Id,
                    Brand = tShirtModel.Brand,
                    Color = tShirtModel.Color,
                    Season = tShirtModel.Season,
                    Prize = tShirtModel.Prize,
                    Reviews = tShirtModel.Reviews.Select(x => x.ToReviewDto()).ToList()
                };
        }

        public static TShirt ToUpdateDto (this CreateTShirtDto tShirtDto )
        {
            return new TShirt
            {
                    Brand = tShirtDto.Brand,
                    Color = tShirtDto.Color,
                    Season = tShirtDto.Season,
                    Prize = tShirtDto.Prize,
            };
        }

    
    }
}