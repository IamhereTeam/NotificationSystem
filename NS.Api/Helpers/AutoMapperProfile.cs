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
            CreateMap<UserSettings, UserSettingsModel>();
            CreateMap<UserNotification, UserNotificationModel>()
                .ForMember(x => x.Subject, opt => opt.MapFrom(source => source.Notification.Subject))
                .ForMember(x => x.Message, opt => opt.MapFrom(source => source.Notification.Message))
                .ForMember(x => x.Sender, opt => opt.MapFrom(source => source.Notification.User));


            // DTO to Entities
            CreateMap<RequestUserModel, User>();
            CreateMap<UpdateUserModel, User>();
            CreateMap<UserModel, User>();
            CreateMap<UserSettingsModel, UserSettings>();
            CreateMap<NotificationModel, Notification>();
        }
    }
}
