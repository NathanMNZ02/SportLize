
using SportLize.Profile.Api.Profile.Shared.Dto;
using SportLize.Team.Api.Team.Repository.Model;
using SportLize.Team.Api.Team.Shared.Dto;

namespace SportLize.Team.Api.Team.Business.Mapper
{
    public class AutoMapperProfiles : AutoMapper.Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<GroupReadDto, Group>();
            CreateMap<Group, GroupReadDto>();
            CreateMap<GroupWriteDto, Group>();
            CreateMap<Group, GroupWriteDto>();
            CreateMap<MessageReadDto, Message>();
            CreateMap<Message, MessageReadDto>();
            CreateMap<MessageWriteDto, Message>();
            CreateMap<Message, MessageWriteDto>();

            CreateMap<UserKafka, UserReadDto>();
            CreateMap<UserReadDto, UserKafka>();
        }
    }
}
