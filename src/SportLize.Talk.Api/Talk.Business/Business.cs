
using AutoMapper;
using SportLize.Profile.Api.Profile.ClientHttp.Abstraction;
using SportLize.Talk.Api.Talk.Business.Abstraction;
using SportLize.Talk.Api.Talk.Repository.Abstraction;
using SportLize.Talk.Api.Talk.Repository.Model;
using SportLize.Talk.Api.Talk.Shared.Dto;

namespace SportLize.Talk.Api.Talk.Business
{
    public class Business : IBusiness
    {
        private readonly IClientHttp _clientHttp;
        private readonly IMapper _mapper;
        private readonly IRepository _repository;

        public Business(IMapper mapper, IClientHttp clientHttp, IRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
            _clientHttp = clientHttp;
        }

        #region INSERT
        public async Task<ChatReadDto?> InsertChat(int senderId, int receiverId, CancellationToken cancellationToken = default)
        {
            var sender = await _clientHttp.GetUser(senderId, cancellationToken);
            var receiver = await _clientHttp.GetUser(receiverId, cancellationToken);
            if (sender is not null && receiver is not null)
            {
                var result = _mapper.Map<ChatReadDto>(await _repository.InsertChat(new ChatWriteDto() { SenderId = senderId, ReceiverId = receiverId }, cancellationToken));
                await _repository.SaveChanges(cancellationToken);
                return result;
            }
            return null;
        }

        public async Task<MessageReadDto> InsertMessageInChat(int chatId, MessageWriteDto messageWriteDto, CancellationToken cancellationToken = default)
        {
            var result = _mapper.Map<MessageReadDto>(await _repository.InsertMessageInChat(chatId, messageWriteDto, cancellationToken));
            await _repository.SaveChanges(cancellationToken);
            return result;
        }
        #endregion

        #region UPDATE
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
        public async Task<List<ChatReadDto>?> GetAllSentChatOfUser(int userId, CancellationToken cancellationToken = default) =>
            _mapper.Map<List<ChatReadDto>?>(await _repository.GetAllSentChatOfUser(userId, cancellationToken));

        public async Task<List<ChatReadDto>?> GetAllReceivedChatOfUser(int userId, CancellationToken cancellationToken = default) =>
            _mapper.Map<List<ChatReadDto>?>(await _repository.GetAllReceivedChatOfUser(userId, cancellationToken));

        public async Task<List<MessageReadDto>?> GetAllMessagesOfChat(int chatId, CancellationToken cancellationToken = default) =>
            _mapper.Map<List<MessageReadDto>?>(await _repository.GetAllMessagesOfChat(chatId, cancellationToken));

        public async Task<ChatReadDto?> GetChat(int id, CancellationToken cancellationToken = default) =>
            _mapper.Map<ChatReadDto?>(await _repository.GetChat(id, cancellationToken));

        public async Task<MessageReadDto?> GetMessage(int id, CancellationToken cancellationToken = default) =>
            _mapper.Map<MessageReadDto?>(await _repository.GetMessage(id, cancellationToken));
        #endregion

        #region REMOVE
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
