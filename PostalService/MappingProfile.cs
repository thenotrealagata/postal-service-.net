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
        }
    }
}
