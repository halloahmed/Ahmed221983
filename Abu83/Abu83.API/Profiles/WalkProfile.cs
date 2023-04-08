using AutoMapper;

namespace Abu83.API.Profiles
{
    public class WalkProfile:Profile
    {
        public WalkProfile()
        {
            CreateMap<Models.Domain.Walk, Models.DTO.Walk>()
               .ReverseMap();

            CreateMap<Models.Domain.WalkDifficulty, Models.DTO.WalkDifficulty>()
              .ReverseMap();

        }
    }
}
