using AutoMapper;
using NS.DTO.Acount;
using NS.Core.Entities;
using NS.DTO.Notification;

namespace NS.Api.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // Entities to DTO
            CreateMap<User, UserModel>();
            CreateMap<Department, DepartmentModel>();
            CreateMap<Notification, NotificationModel>();

            // DTO to Entities
            CreateMap<RequestUserModel, User>();
            CreateMap<UserModel, User>();
            CreateMap<UserSettingsModel, UserSettings>();
            CreateMap<NotificationModel, Notification>();
        }
    }
}
