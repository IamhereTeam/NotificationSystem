using AutoMapper;
using NS.Core.Entities;
using NS.DTO.Acount;

namespace NS.Api.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserModel>();
        }
    }
}
