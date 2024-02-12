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
        _teamDbContext.Database.Migrate();
    }

    public async Task<int> SaveChanges(CancellationToken cancellationToken = default) => await _teamDbContext.SaveChangesAsync(cancellationToken);

    #region INSERT
    public async Task<Group> InsertGroup(GroupWriteDto groupWriteDto, CancellationToken cancellationToken = default)
    {
        var group = _mapper.Map<Group>(groupWriteDto);
        await _teamDbContext.Group.AddAsync(group);
        return group;
    }

    public async Task<UserKafka> InsertUserToGroup(int groupId, UserKafka userKafka, CancellationToken cancellationToken = default)
    {
        var group = await GetGroup(groupId, cancellationToken);

        if(group is not null)
            group.UsersKafka.Add(userKafka);

        return userKafka;
    }

    public async Task<Message> InsertMessageToGroup(int groupId, MessageWriteDto messageWriteDto, CancellationToken cancellationToken = default)
    {
        var message = _mapper.Map<Message>(messageWriteDto);
        var group = await GetGroup(groupId, cancellationToken);

        if(group is not null)
            group.Messages.Add(message);

        return message;
    }

    public async Task<UserKafka> InsertUserKafka(UserKafka userKafka, CancellationToken cancellationToken = default)
    {
        await _teamDbContext.UserKafka.AddAsync(userKafka);
        return userKafka;
    }
    #endregion

    #region UPDATE
    public async Task<Group> UpdateGroup(GroupReadDto groupReadDto, CancellationToken cancellationToken = default)
    {
        var newGroup = _mapper.Map<Group>(groupReadDto);
        var oldGroup = await _teamDbContext.Group.Include(s => s.UsersKafka).Include(s => s.Messages).FirstOrDefaultAsync(s => s.Id == newGroup.Id);
        if(oldGroup is not null)
        {
            oldGroup.Name = newGroup.Name;
            oldGroup.GroupState = newGroup.GroupState;
        }
        return newGroup;
    }

    public async Task<Message> UpdateMessage(MessageReadDto messageReadDto, CancellationToken cancellationToken = default)
    {
        var newMessage = _mapper.Map<Message>(messageReadDto);
        var oldMessage = await _teamDbContext.Message.FirstOrDefaultAsync(m => m.Id == newMessage.Id, cancellationToken);
        if (oldMessage is not null)
        {
            oldMessage.Text = newMessage.Text;
            oldMessage.DateTime = newMessage.DateTime;
        }
        return newMessage;
    }

    public async Task<UserKafka> UpdateUserKafka(UserKafka userKafka, CancellationToken cancellationToken = default)
    {
        var newUserKafka = _mapper.Map<UserKafka>(userKafka);
        var oldUserKafka = await _teamDbContext.UserKafka.FirstOrDefaultAsync(u => u.Id == newUserKafka.Id, cancellationToken);
        if (oldUserKafka is not null)
        {
            oldUserKafka.Actor = newUserKafka.Actor;
            oldUserKafka.Nickname = newUserKafka.Nickname;
            oldUserKafka.Name = newUserKafka.Name;
            oldUserKafka.Surname = newUserKafka.Surname;
            oldUserKafka.Password = newUserKafka.Password;
            oldUserKafka.Description = newUserKafka.Description;
            oldUserKafka.DateOfBorn = newUserKafka.DateOfBorn;
        }
        return newUserKafka;
    }
    #endregion


    #region GET
    public async Task<List<Group>?> GetAllGroup(CancellationToken cancellationToken = default) => await _teamDbContext.Group.ToListAsync();

    public async Task<List<UserKafka>?> GetAllUserKafka(CancellationToken cancellationToken = default) => await _teamDbContext.UserKafka.ToListAsync();

    public async Task<List<UserKafka>?> GetAllUserKafkaOfGroup(int groupId, CancellationToken cancellationToken = default)
    {
        var group = await _teamDbContext.Group.Include(s => s.UsersKafka).FirstOrDefaultAsync(cancellationToken);
        return group?.UsersKafka;
    }
    public async Task<List<Message>?> GetAllMessagesOfGroup(int groupId, CancellationToken cancellationToken = default)
    {
        var group = await _teamDbContext.Group.Include(s => s.Messages).FirstOrDefaultAsync(cancellationToken);
        return group?.Messages;
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

    public async Task<UserKafka> DeleteUserKafka(UserKafka userKafka, CancellationToken cancellationToken = default)
    {
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
