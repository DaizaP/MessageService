using AutoMapper;
using MessageService.Models;
using MessageService.Models.Dto;

namespace MessageService.Services
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<MessageModel, SendMessageModelDto>(MemberList.Destination)
                .ReverseMap();
            CreateMap<MessageModel, GetMessageModelDto>(MemberList.Destination)
                .ReverseMap();
        }

    }
}
