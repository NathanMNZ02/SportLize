using AutoMapper;
using SportLize.Team.Api.Team.Business.Abstraction;
using SportLize.Team.Api.Team.Repository.Abstraction;
using SportLize.Team.Api.Team.Repository.Model;
using SportLize.Team.Api.Team.Shared.Dto;

namespace SportLize.Team.Api.Team.Business
{
    public class Business : IBusiness
    {
        private readonly IMapper _mapper;
        private readonly IRepository _repository;

        public Business(IMapper mapper, IRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        #region INSERT
        public async Task<GroupReadDto> InsertGroup(GroupWriteDto groupWriteDto, CancellationToken cancellationToken = default)
        {
            var result = _mapper.Map<GroupReadDto>(await _repository.InsertGroup(groupWriteDto, cancellationToken));
            await _repository.SaveChanges(cancellationToken);
            return result;
        }

        public async Task<UserKafka> InsertUserToGroup(int groupId, UserKafka userKafka, CancellationToken cancellationToken = default)
        {
            var result = await _repository.InsertUserToGroup(groupId, userKafka, cancellationToken);
            await _repository.SaveChanges(cancellationToken);
            return result;
        }

        public async Task<MessageReadDto> InsertMessageToGroup(int groupId, MessageWriteDto messageWriteDto, CancellationToken cancellationToken = default)
        {
            var result = _mapper.Map<MessageReadDto>(await _repository.InsertMessageToGroup(groupId, messageWriteDto, cancellationToken));
            await _repository.SaveChanges(cancellationToken);
            return result;
        }

        public async Task<UserKafka> InsertUserKafka(UserKafka userKafka, CancellationToken cancellationToken = default)
        {
            var result = await _repository.InsertUserKafka(userKafka, cancellationToken);
            await _repository.SaveChanges(cancellationToken);
            return result;
        }
        #endregion

        #region UPDATE
        public async Task<GroupReadDto> UpdateGroup(GroupReadDto groupReadDto, CancellationToken cancellationToken = default)
        {
            var result = _mapper.Map<GroupReadDto>(await _repository.UpdateGroup(groupReadDto, cancellationToken));
            await _repository.SaveChanges(cancellationToken);
            return result;
        }

        public async Task<MessageReadDto> UpdateMessage(MessageReadDto messageReadDto, CancellationToken cancellationToken = default)
        {
            var result = _mapper.Map<MessageReadDto>(await _repository.UpdateMessage(messageReadDto, cancellationToken));
            await _repository.SaveChanges(cancellationToken);
            return result;
        }

        public async Task<UserKafka> UpdateUserKafka(UserKafka userKafka, CancellationToken cancellationToken = default)
        {
            var result = await _repository.UpdateUserKafka(userKafka, cancellationToken);
            await _repository.SaveChanges(cancellationToken);
            return result;
        }
        #endregion

        #region GET
        public async Task<List<GroupReadDto>?> GetAllGroup(CancellationToken cancellationToken = default) =>
            _mapper.Map<List<GroupReadDto>?>(await _repository.GetAllGroup(cancellationToken));

        public async Task<List<UserKafka>?> GetAllUserKafka(CancellationToken cancellationToken = default) =>
            await _repository.GetAllUserKafka(cancellationToken);

        public async Task<List<MessageReadDto>?> GetAllMessagesOfGroup(int groupId, CancellationToken cancellationToken = default) =>
            _mapper.Map<List<MessageReadDto>?>(await _repository.GetAllMessagesOfGroup(groupId, cancellationToken));

        public async Task<List<UserKafka>?> GetAllUserKafkaOfGroup(int groupId, CancellationToken cancellationToken = default) =>
            await _repository.GetAllUserKafkaOfGroup(groupId, cancellationToken);

        public async Task<GroupReadDto?> GetGroup(int id, CancellationToken cancellationToken = default) =>
            _mapper.Map<GroupReadDto?>(await _repository.GetGroup(id, cancellationToken));

        public async Task<MessageReadDto?> GetMessage(int id, CancellationToken cancellationToken = default) =>
            _mapper.Map<MessageReadDto?>(await _repository.GetMessage(id, cancellationToken));

        public async Task<UserKafka?> GetUserKafka(int id, CancellationToken cancellationToken = default) =>
            await _repository.GetUserKafka(id, cancellationToken);
        #endregion

        #region DELETE
        public async Task<GroupReadDto> DeleteGroup(GroupReadDto groupId, CancellationToken cancellationToken = default)
        {
            var result = _mapper.Map<GroupReadDto>(await _repository.DeleteGroup(groupId, cancellationToken));
            await _repository.SaveChanges(cancellationToken);
            return result;
        }

        public async Task<MessageReadDto> DeleteMessage(MessageReadDto messageReadDto, CancellationToken cancellationToken = default)
        {
            var result = _mapper.Map<MessageReadDto>(await _repository.DeleteMessage(messageReadDto, cancellationToken));
            await _repository.SaveChanges(cancellationToken);
            return result;
        }

        public async Task<UserKafka> DeleteUserKafka(UserKafka userKafka, CancellationToken cancellationToken = default)
        {
            var result = await _repository.DeleteUserKafka(userKafka, cancellationToken);
            await _repository.SaveChanges(cancellationToken);
            return result;
        }
        #endregion

    }
}
