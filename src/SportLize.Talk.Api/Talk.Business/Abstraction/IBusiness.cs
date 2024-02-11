using SportLize.Talk.Api.Talk.Repository.Model;
using SportLize.Talk.Api.Talk.Shared.Dto;

namespace SportLize.Talk.Api.Talk.Business.Abstraction
{
    public interface IBusiness
    {
        #region INSERT
        Task<UserKafka> InsertUserKafka(UserKafka userKafka, CancellationToken cancellationToken = default);
        Task<ChatReadDto> InsertChatForSender(int userId, ChatWriteDto chatWriteDto, CancellationToken cancellationToken = default);
        Task<ChatReadDto> InsertChatForReceiver(int userId, ChatWriteDto chatWriteDto, CancellationToken cancellationToken = default);
        Task<MessageReadDto> InsertMessageInChat(int chatId, MessageWriteDto messageWriteDto, CancellationToken cancellationToken = default);
        #endregion

        #region UPDATE
        Task<UserKafka> UpdateUserKafka(UserKafka userKafka, CancellationToken cancellationToken = default);
        Task<ChatReadDto> UpdateChat(ChatReadDto chatReadDto, CancellationToken cancellationToken = default);
        Task<MessageReadDto> UpdateMessage(MessageReadDto messageReadDto, CancellationToken cancellationToken = default);
        #endregion

        #region GET
        Task<List<UserKafka>?> GetAllUsers(CancellationToken cancellationToken = default);
        Task<List<ChatReadDto>?> GetAllSentChatOfUser(int userId, CancellationToken cancellationToken = default);
        Task<List<ChatReadDto>?> GetAllReceivedChatOfUser(int userId, CancellationToken cancellationToken = default);
        Task<List<MessageReadDto>?> GetAllMessagesOfChat(int chatId, CancellationToken cancellationToken = default);
        Task<UserKafka?> GetUser(int id, CancellationToken cancellationToken = default);
        Task<ChatReadDto?> GetChat(int id, CancellationToken cancellationToken = default);
        Task<MessageReadDto?> GetMessage(int id, CancellationToken cancellationToken = default);
        #endregion

        #region REMOVE
        Task<UserKafka> DeleteUserKafka(UserKafka userKafka, CancellationToken cancellationToken = default);
        Task<ChatReadDto> DeleteChat(ChatReadDto chatReadDto, CancellationToken cancellationToken = default);
        Task<MessageReadDto> DeleteMessage(MessageReadDto messageReadDto, CancellationToken cancellationToken = default);
        #endregion
    }
}
