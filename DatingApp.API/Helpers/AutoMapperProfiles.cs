using System.Linq;
using AutoMapper;
using DatingApp.API.DTOs;
using DatingApp.API.Entities;

namespace DatingApp.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<AppUser, UserForListDTO>()
                .ForMember(dest => dest.PhotoUrl, opt => 
                    opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain).Url
                    ))
                .ForMember(dest => dest.Age, opt => 
                    opt.MapFrom(src => src.DateOfBirth.CalculateAge()
                    ));

            CreateMap<AppUser, UserForDetailedDTO>()
                .ForMember(dest => dest.PhotoUrl, opt => 
                    opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain).Url
                    ))
                .ForMember(dest => dest.Age, opt => 
                    opt.MapFrom(src => src.DateOfBirth.CalculateAge()
                    ));

            CreateMap<Photo, PhotosForDetailedDTO>();
            CreateMap<UserForUpdateDTO, AppUser>();
            CreateMap<Photo, PhotoForReturnDTO>();
            CreateMap<PhotoForCreationDTO, Photo>();
            CreateMap<UserForRegisterDTO, AppUser>();
            CreateMap<MessageForCreationDTO, Message>().ReverseMap();
            CreateMap<Message, MessageToReturnDTO>()
                .ForMember(m => m.SenderPhotoUrl, opt => opt
                    .MapFrom(u => u.Sender.Photos.FirstOrDefault(p => p.IsMain).Url))
                .ForMember(m => m.RecipientPhotoUrl, opt => opt
                    .MapFrom(u => u.Recipient.Photos.FirstOrDefault(p => p.IsMain).Url));
        }
    }
}