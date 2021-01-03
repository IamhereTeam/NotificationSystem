using AutoMapper;
using NS.Core.Entities;
using NS.DTO.Acount;

namespace NS.Api.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // Entities to DTO
            CreateMap<User, UserModel>();
            CreateMap<Department, DepartmentModel>();

            // DTO to Entities
            CreateMap<RequestUserModel, User>();
            CreateMap<UserModel, User>();
        }
    }
}
