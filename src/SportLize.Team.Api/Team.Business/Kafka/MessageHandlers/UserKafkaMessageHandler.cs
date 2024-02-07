using AutoMapper;
using SportLize.Profile.Api.Profile.Shared.Dto;
using SportLize.Team.Api.Team.Repository.Abstraction;
using SportLize.Team.Api.Team.Repository.Model;

namespace SportLize.Team.Api.Team.Business.Kafka.MessageHandlers
{
    public class UserKafkaMessageHandler : AbstractMessageHandler<UserReadDto, UserKafka>
    {
        public UserKafkaMessageHandler(ILogger<UserKafkaMessageHandler> logger, IRepository repository, IMapper map) : base(logger, repository, map) { }

        protected override async Task InsertDtoAsync(UserKafka domainDto, CancellationToken cancellationToken = default)
        {
            await Repository.InsertUserKafka(domainDto, cancellationToken);
        }

        protected override Task UpdateDtoAsync(UserKafka domainDto, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        protected override async Task DeleteDtoAsync(UserKafka domainDto, CancellationToken cancellationToken = default)
        {
            await Repository.DeleteUserKafka(domainDto);
        }
    }
}
