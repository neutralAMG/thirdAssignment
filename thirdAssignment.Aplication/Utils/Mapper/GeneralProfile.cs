using AutoMapper;
using thirdAssignment.Aplication.Models;
using thirdAssignment.Domain.Entities;


namespace thirdAssignment.Aplication.Utils.Mapper
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<User, UserModel>()
                .ForMember(dest => dest.UserRol, opt => opt.MapFrom(src => src.UserRol));
             
        }
    }
}
