using SportLize.Team.Api.Team.Repository.Model;
using SportLize.Team.Api.Team.Shared.Dto;

namespace SportLize.Team.Api.Team.Repository.Abstraction
{
    public interface IRepository
    {
        Task<int> SaveChanges(CancellationToken cancellationToken = default);

        #region INSERT
        Task<Group> InsertGroup(GroupWriteDto groupWriteDto, CancellationToken cancellationToken = default);
        Task<UserKafka> InsertUserToGroup(int groupId, UserKafka userKafka, CancellationToken cancellationToken = default);
        Task<Message> InsertMessageToGroup(int groupId, MessageWriteDto messageWriteDto, CancellationToken cancellationToken = default);
        Task<UserKafka> InsertUserKafka(UserKafka userKafka, CancellationToken cancellationToken = default);
        #endregion

        #region UPDATE
        Task<Group> UpdateGroup(GroupReadDto groupReadDto, CancellationToken cancellationToken = default);
        Task<Message> UpdateMessage(MessageReadDto messageReadDto, CancellationToken cancellationToken = default);
        Task<UserKafka> UpdateUserKafka(UserKafka userKafka, CancellationToken cancellationToken = default);
        #endregion

        #region GET
        Task<List<Group>?> GetAllGroup(CancellationToken cancellationToken = default);
        Task<List<UserKafka>?> GetAllUserKafka(CancellationToken cancellationToken = default);
        Task<List<UserKafka>?> GetAllUserKafkaOfGroup(int groupId, CancellationToken cancellationToken = default);
        Task<List<Message>?> GetAllMessagesOfGroup(int groupId, CancellationToken cancellationToken = default);
        Task<Group?> GetGroup(int id, CancellationToken cancellationToken = default);
        Task<Message?> GetMessage(int id, CancellationToken cancellationToken = default);
        Task<UserKafka?> GetUserKafka(int id, CancellationToken cancellationToken = default);
        #endregion

        #region DELETE
        Task<Group> DeleteGroup(GroupReadDto groupReadDto, CancellationToken cancellationToken = default);
        Task<Message> DeleteMessage(MessageReadDto messageReadDto, CancellationToken cancellationToken = default);
        Task<UserKafka> DeleteUserKafka(UserKafka userKafka, CancellationToken cancellationToken = default);
        #endregion

        #region TRANSACTIONAL OUTBOX
        Task<IEnumerable<TransactionalOutbox>> GetAllTransactionalOutbox(CancellationToken cancellationToken = default);
        Task<TransactionalOutbox?> GetTransactionalOutboxByKey(long id, CancellationToken cancellationToken = default);
        Task DeleteTransactionalOutbox(long id, CancellationToken cancellationToken = default);
        Task InsertTransactionalOutbox(TransactionalOutbox transactionalOutbox, CancellationToken cancellationToken = default);
        #endregion
    }
}
