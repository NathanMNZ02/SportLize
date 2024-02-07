using SportLize.Talk.Api.Talk.Repository.Model;
using SportLize.Talk.Api.Talk.Shared.Dto;

namespace SportLize.Talk.Api.Talk.Repository.Abstraction
{
    public interface IRepository
    {
        Task<int> SaveChanges();

        #region INSERT
        Task<UserKafka> InsertUserKafka(UserKafka userKafka, CancellationToken cancellationToken = default);
        Task<Chat> InsertChat(ChatWriteDto chatWriteDto, CancellationToken cancellationToken = default);
        Task<Message> InsertMessage(MessageWriteDto messageWriteDto, CancellationToken cancellationToken = default);
        #endregion

        #region UPDATE
        Task<UserKafka> UpdateUserKafka(UserKafka oldUserKafka, UserKafka newUserKafka, CancellationToken cancellationToken = default);
        Task<Chat> UpdateChat(ChatReadDto oldChatDto, ChatWriteDto newChatDto, CancellationToken cancellationToken = default);
        Task<Message> UpdateMessage(MessageReadDto oldMessageDto, MessageWriteDto newMessageDto, CancellationToken cancellationToken = default);
        #endregion

        #region GET
        Task<List<UserKafka>?> GetAllUsers(CancellationToken cancellationToken = default);
        Task<List<Chat>?> GetAllChatOfUser(UserKafka userKafka, CancellationToken cancellationToken = default);
        Task<List<Message>?> GetAllMessagesOfChat(ChatReadDto chatReadDto, CancellationToken cancellationToken = default);
        Task<UserKafka?> GetUser(int id, CancellationToken cancellationToken = default);
        Task<Chat?> GetChat(int id, CancellationToken cancellationToken = default); 
        Task<Message?> GetMessage(int id, CancellationToken cancellationToken = default);
        #endregion

        #region REMOVE
        Task<UserKafka> DeleteUserKafka(UserKafka userKafka, CancellationToken cancellationToken = default);
        Task<Chat> DeleteChat(ChatReadDto chatReadDto, CancellationToken cancellationToken = default);
        Task<Message> DeleteMessage(MessageReadDto messageReadDto, CancellationToken cancellationToken = default);
        #endregion

        #region TRANSACTIONALOUTBOX
        Task<IEnumerable<TransactionalOutbox>> GetAllTransactionalOutbox(CancellationToken cancellationToken = default);
        Task<TransactionalOutbox?> GetTransactionalOutboxByKey(long id, CancellationToken cancellationToken = default);
        Task DeleteTransactionalOutbox(long id, CancellationToken cancellationToken = default);
        Task InsertTransactionalOutbox(TransactionalOutbox transactionalOutbox, CancellationToken cancellationToken = default);
        #endregion
    }
}
