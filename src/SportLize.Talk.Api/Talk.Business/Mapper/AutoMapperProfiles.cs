using SportLize.Talk.Api.Talk.Repository.Model;
using SportLize.Talk.Api.Talk.Shared.Dto;

namespace SportLize.Talk.Api.Talk.Business.Mapper
{
    public class AutoMapperProfiles : AutoMapper.Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<ChatReadDto, Chat>();
            CreateMap<Chat, ChatReadDto>();
            CreateMap<ChatWriteDto, Chat>();
            CreateMap<Chat, ChatWriteDto>();
            CreateMap<MessageReadDto, Message>();
            CreateMap<Message, MessageReadDto>();
            CreateMap<MessageWriteDto, Message>();
            CreateMap<Message, MessageWriteDto>();
        }
    }
}
