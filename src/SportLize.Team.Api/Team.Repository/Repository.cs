using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SportLize.Team.Api.Team.Repository;
using SportLize.Team.Api.Team.Repository.Abstraction;
using SportLize.Team.Api.Team.Repository.Model;
using SportLize.Team.Api.Team.Shared.Dto;

public class Repository : IRepository
{
    private readonly IMapper _mapper;
    private readonly TeamDbContext _teamDbContext;

    public Repository(TeamDbContext teamDbContext, IMapper mapper)
    {
        _mapper = mapper;
        _teamDbContext = teamDbContext;
    }

    public async Task<int> SaveChanges(CancellationToken cancellationToken = default) => await _teamDbContext.SaveChangesAsync(cancellationToken);

    #region INSERT
    public async Task<Group> InsertGroup(GroupWriteDto groupWriteDto, CancellationToken cancellationToken = default)
    {
        var group = _mapper.Map<Group>(groupWriteDto);
        await _teamDbContext.Group.AddAsync(group);
        return group;
    }

    public async Task<Message> InsertMessage(MessageWriteDto messageWriteDto, CancellationToken cancellationToken = default)
    {
        var message = _mapper.Map<Message>(messageWriteDto);
        await _teamDbContext.Message.AddAsync(message);
        return message;
    }

    public async Task<UserKafka> InsertUserKafka(UserKafkaWriteDto userKafkaWriteDto, CancellationToken cancellationToken = default)
    {
        var userKafka = _mapper.Map<UserKafka>(userKafkaWriteDto);
        await _teamDbContext.UserKafka.AddAsync(userKafka);
        return userKafka;
    }
    #endregion

    #region UPDATE
    public async Task<Group> UpdateGroup(GroupReadDto oldGroupReadDto, GroupWriteDto newGroupWriteDto, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task<Message> UpdateMessage(MessageReadDto oldMessageReadDto, MessageWriteDto newMessageWriteDto, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task<UserKafka> UpdateUserKafka(UserKafkaReadDto oldUserKafkaReadDto, UserKafkaWriteDto newUserKafkaWriteDto, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
    #endregion

    #region GET
    public async Task<List<Group>?> GetAllGroup(CancellationToken cancellationToken = default) => await _teamDbContext.Group.ToListAsync();

    public async Task<List<Message>?> GetAllMessagesOfGroup(GroupReadDto groupReadDto, CancellationToken cancellationToken = default)
    {
        var group = await GetGroup(groupReadDto.Id, cancellationToken);
        if(group is null)
            return null;

        return group.Messages;
    }

    public async Task<List<UserKafka>?> GetAllUserKafkaOfGroup(GroupReadDto groupReadDto, CancellationToken cancellationToken = default)
    {
        var group = await GetGroup(groupReadDto.Id, cancellationToken);
        if (group is null)
            return null;

        return group.UsersKafka;
    }

    public async Task<Group?> GetGroup(int id, CancellationToken cancellationToken = default) =>
        await _teamDbContext.Group.FirstOrDefaultAsync(s=> s.Id == id, cancellationToken);  
    public async Task<Message?> GetMessage(int id, CancellationToken cancellationToken = default) =>
        await _teamDbContext.Message.FirstOrDefaultAsync(s => s.Id == id, cancellationToken);

    public async Task<UserKafka?> GetUserKafka(int id, CancellationToken cancellationToken = default) =>
        await _teamDbContext.UserKafka.FirstOrDefaultAsync(s => s.Id == id, cancellationToken);
    #endregion

    #region DELETE
    public async Task<Group> DeleteGroup(GroupReadDto groupReadDto, CancellationToken cancellationToken = default)
    {
        var group = _mapper.Map<Group>(groupReadDto);
        _teamDbContext.Group.Remove(group);
        return group;
    }

    public async Task<Message> DeleteMessage(MessageReadDto messageReadDto, CancellationToken cancellationToken = default)
    {
        var message = _mapper.Map<Message>(messageReadDto);
        _teamDbContext.Message.Remove(message);
        return message;
    }

    public async Task<UserKafka> DeleteUserKafka(UserKafkaReadDto userKafkaReadDto, CancellationToken cancellationToken = default)
    {
        var userKafka = _mapper.Map<UserKafka>(userKafkaReadDto);
        _teamDbContext.UserKafka.Remove(userKafka);
        return userKafka;
    }
    #endregion

    #region TRANSACTIONAL OUTBOX
    public async Task<IEnumerable<TransactionalOutbox>> GetAllTransactionalOutbox(CancellationToken cancellationToken = default) =>
        await _teamDbContext.TransactionalOutboxe.ToListAsync(cancellationToken);

    public async Task<TransactionalOutbox?> GetTransactionalOutboxByKey(long id, CancellationToken cancellationToken = default) =>
        await _teamDbContext.TransactionalOutboxe.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

    public async Task DeleteTransactionalOutbox(long id, CancellationToken cancellationToken = default) =>
        _teamDbContext.TransactionalOutboxe.Remove((await GetTransactionalOutboxByKey(id, cancellationToken)) ?? throw new ArgumentException($"TransactionalOutbox con id {id} non trovato", nameof(id)));

    public async Task InsertTransactionalOutbox(TransactionalOutbox transactionalOutbox, CancellationToken cancellationToken = default) =>
        await _teamDbContext.TransactionalOutboxe.AddAsync(transactionalOutbox);
    #endregion

}
