using SportLize.Talk.Api.Talk.Repository.Model;
using SportLize.Talk.Api.Talk.Shared.Dto;

namespace SportLize.Talk.Api.Talk.Business.Abstraction
{
    public interface IBusiness
    {
        #region INSERT
        Task<ChatReadDto?> InsertChat(int senderId, int receiverId, CancellationToken cancellationToken = default);
        Task<MessageReadDto> InsertMessageInChat(int chatId, MessageWriteDto messageWriteDto, CancellationToken cancellationToken = default);
        #endregion

        #region UPDATE
        Task<ChatReadDto> UpdateChat(ChatReadDto chatReadDto, CancellationToken cancellationToken = default);
        Task<MessageReadDto> UpdateMessage(MessageReadDto messageReadDto, CancellationToken cancellationToken = default);
        #endregion

        #region GET
        Task<List<ChatReadDto>?> GetAllSentChatOfUser(int userId, CancellationToken cancellationToken = default);
        Task<List<ChatReadDto>?> GetAllReceivedChatOfUser(int userId, CancellationToken cancellationToken = default);
        Task<List<MessageReadDto>?> GetAllMessagesOfChat(int chatId, CancellationToken cancellationToken = default);
        Task<ChatReadDto?> GetChat(int id, CancellationToken cancellationToken = default);
        Task<MessageReadDto?> GetMessage(int id, CancellationToken cancellationToken = default);
        #endregion

        #region REMOVE
        Task<ChatReadDto> DeleteChat(ChatReadDto chatReadDto, CancellationToken cancellationToken = default);
        Task<MessageReadDto> DeleteMessage(MessageReadDto messageReadDto, CancellationToken cancellationToken = default);
        #endregion
    }
}
