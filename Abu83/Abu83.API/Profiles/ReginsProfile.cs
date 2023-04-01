using AutoMapper;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Abu83.API.Profiles
{
    public class ReginsProfile: Profile
    {
        public ReginsProfile()
        {
            CreateMap<Models.Domain.Region, Models.DTO.Region>()
                .ReverseMap();
        }  
    }
}
