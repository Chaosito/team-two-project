using AutoMapper;
using KartowkaMarkowkaHub.Core.Domain;

namespace KartowkaMarkowkaHub.Services.Account
{
    internal class CreateUserDtoMapper : Profile
    {
        public CreateUserDtoMapper()
        {
            CreateMap<CreateUserDto, User>()
                .ForMember(d => d.Login, o => o.MapFrom(r => r.Login))
                .ForMember(d => d.Email, o => o.MapFrom(r => r.Email))
                .ForMember(d => d.Password, o => o.MapFrom(r => r.Password));
        }
    }
}
