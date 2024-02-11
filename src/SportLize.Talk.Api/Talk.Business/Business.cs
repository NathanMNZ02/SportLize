
using AutoMapper;
using SportLize.Talk.Api.Talk.Business.Abstraction;
using SportLize.Talk.Api.Talk.Repository.Abstraction;
using SportLize.Talk.Api.Talk.Repository.Model;
using SportLize.Talk.Api.Talk.Shared.Dto;

namespace SportLize.Talk.Api.Talk.Business
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
        public async Task<UserKafka> InsertUserKafka(UserKafka userKafka, CancellationToken cancellationToken = default)
        {
            var result = _mapper.Map<UserKafka>(await _repository.InsertUserKafka(userKafka, cancellationToken));
            await _repository.SaveChanges(cancellationToken);
            return result;
        }

        public async Task<ChatReadDto> InsertChatForSender(int userId, ChatWriteDto chatWriteDto, CancellationToken cancellationToken = default)
        {
            var result = _mapper.Map<ChatReadDto>(await _repository.InsertChatForSender(userId, chatWriteDto, cancellationToken));
            await _repository.SaveChanges(cancellationToken);
            return result;
        }

        public async Task<ChatReadDto> InsertChatForReceiver(int userId, ChatWriteDto chatWriteDto, CancellationToken cancellationToken = default)
        {
            var result = _mapper.Map<ChatReadDto>(await _repository.InsertChatForReceiver(userId, chatWriteDto, cancellationToken));
            await _repository.SaveChanges(cancellationToken);
            return result;
        }

        public async Task<MessageReadDto> InsertMessageInChat(int chatId, MessageWriteDto messageWriteDto, CancellationToken cancellationToken = default)
        {
            var result = _mapper.Map<MessageReadDto>(await _repository.InsertMessageInChat(chatId, messageWriteDto, cancellationToken));
            await _repository.SaveChanges(cancellationToken);
            return result;
        }
        #endregion

        #region UPDATE
        public async Task<UserKafka> UpdateUserKafka(UserKafka userKafka, CancellationToken cancellationToken = default)
        {
            var result = await _repository.UpdateUserKafka(userKafka, cancellationToken);
            await _repository.SaveChanges(cancellationToken);
            return result;
        }
        public async Task<ChatReadDto> UpdateChat(ChatReadDto chatReadDto, CancellationToken cancellationToken = default)
        {
            var result = _mapper.Map<ChatReadDto>(await _repository.UpdateChat(chatReadDto, cancellationToken));
            await _repository.SaveChanges(cancellationToken);
            return result;
        }

        public async Task<MessageReadDto> UpdateMessage(MessageReadDto messageReadDto, CancellationToken cancellationToken = default)
        {
            var result = _mapper.Map<MessageReadDto>(await _repository.UpdateMessage(messageReadDto, cancellationToken));
            await _repository.SaveChanges(cancellationToken);
            return result;
        }
        #endregion

        #region GET
        public async Task<List<UserKafka>?> GetAllUsers(CancellationToken cancellationToken = default) =>
            await _repository.GetAllUsers(cancellationToken);

        public async Task<List<ChatReadDto>?> GetAllSentChatOfUser(int userId, CancellationToken cancellationToken = default) =>
            _mapper.Map<List<ChatReadDto>?>(await _repository.GetAllSentChatOfUser(userId, cancellationToken));

        public async Task<List<ChatReadDto>?> GetAllReceivedChatOfUser(int userId, CancellationToken cancellationToken = default) =>
            _mapper.Map<List<ChatReadDto>?>(await _repository.GetAllReceivedChatOfUser(userId, cancellationToken));

        public async Task<List<MessageReadDto>?> GetAllMessagesOfChat(int chatId, CancellationToken cancellationToken = default) =>
            _mapper.Map<List<MessageReadDto>?>(await _repository.GetAllMessagesOfChat(chatId, cancellationToken));

        public async Task<UserKafka?> GetUser(int id, CancellationToken cancellationToken = default) =>
            await _repository.GetUser(id, cancellationToken);

        public async Task<ChatReadDto?> GetChat(int id, CancellationToken cancellationToken = default) =>
            _mapper.Map<ChatReadDto?>(await _repository.GetChat(id, cancellationToken));

        public async Task<MessageReadDto?> GetMessage(int id, CancellationToken cancellationToken = default) =>
            _mapper.Map<MessageReadDto?>(await _repository.GetMessage(id, cancellationToken));
        #endregion

        #region REMOVE
        public async Task<UserKafka> DeleteUserKafka(UserKafka userKafka, CancellationToken cancellationToken = default)
        {
            var result = await _repository.DeleteUserKafka(userKafka, cancellationToken);
            await _repository.SaveChanges(cancellationToken);
            return result;
        }

        public async Task<ChatReadDto> DeleteChat(ChatReadDto chatReadDto, CancellationToken cancellationToken = default) {
            var result = _mapper.Map<ChatReadDto>(await _repository.DeleteChat(chatReadDto, cancellationToken));
            await _repository.SaveChanges(cancellationToken);
            return result;
        }

        public async Task<MessageReadDto> DeleteMessage(MessageReadDto messageReadDto, CancellationToken cancellationToken = default) 
        {
            var result = _mapper.Map<MessageReadDto>(await _repository.DeleteMessage(messageReadDto, cancellationToken));
            await _repository.SaveChanges(cancellationToken);
            return result;
        }
        #endregion
    }
}
