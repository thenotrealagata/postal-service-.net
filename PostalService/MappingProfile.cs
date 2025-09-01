using AutoMapper;
using PostalService.DTO;
using PostalService.Model;

namespace PostalService
{
    public class MappingProfile : Profile
    {
        public MappingProfile() {
            CreateMap<ParcelRequestDto, Parcel>(MemberList.Source);
            CreateMap<Parcel, ParcelResponseDto>(MemberList.Destination);

            CreateMap<UserRequestDto, User>(MemberList.Source)
                .ForSourceMember(src => src.Password, opt => opt.DoNotValidate())
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Email));
            CreateMap<User, UserResponseDto>(MemberList.Destination);
        }
    }
}
