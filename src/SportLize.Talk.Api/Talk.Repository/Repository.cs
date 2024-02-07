using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SportLize.Talk.Api.Talk.Repository.Abstraction;
using SportLize.Talk.Api.Talk.Repository.Model;
using SportLize.Talk.Api.Talk.Shared.Dto;

namespace SportLize.Talk.Api.Talk.Repository
{
    public class Repository : IRepository
    {
        private IMapper _mapper;
        private TalkDbContext _talkDbContext;
        public Repository(TalkDbContext talkDbContext, IMapper mapper) 
        {
            _mapper = mapper;
            _talkDbContext = talkDbContext;
        }

        public async Task<int> SaveChanges()
        {
            return await _talkDbContext.SaveChangesAsync();
        }

        #region INSERT
        public async Task<UserKafka> InsertUserKafka(UserKafka userKafka, CancellationToken cancellationToken = default)
        {
            await _talkDbContext.UserKafka.AddAsync(userKafka);
            return userKafka;
        }

        public async Task<Chat> InsertChat(ChatWriteDto chatWriteDto, CancellationToken cancellationToken = default)
        {
            var chat = _mapper.Map<Chat>(chatWriteDto);
            await _talkDbContext.Chat.AddAsync(chat);
            return chat;
        }

        public async Task<Message> InsertMessage(MessageWriteDto messageWriteDto, CancellationToken cancellationToken = default)
        {
            var message = _mapper.Map<Message>(messageWriteDto);
            await _talkDbContext.Message.AddAsync(message);
            return message;
        }
        #endregion

        #region UPDATE
        public async Task<UserKafka> UpdateUserKafka(UserKafka oldUserKafka, UserKafka newUserKafka, CancellationToken cancellationToken = default)
        {
            var user = await _talkDbContext.UserKafka.FirstOrDefaultAsync(s => s.Id == oldUserKafka.Id, cancellationToken);

            if (user is not null)
                await DeleteUserKafka(oldUserKafka, cancellationToken);

            await _talkDbContext.UserKafka.AddAsync(newUserKafka, cancellationToken);
            return newUserKafka;
        }

        public async Task<Chat> UpdateChat(ChatReadDto oldChatDto, ChatWriteDto newChatDto, CancellationToken cancellationToken = default)
        {
            var chat = await _talkDbContext.Chat.FirstOrDefaultAsync(s => s.Id == oldChatDto.Id, cancellationToken);

            if (chat is not null)
                await DeleteChat(oldChatDto, cancellationToken);

            var newChat = _mapper.Map<Chat>(newChatDto);
            await _talkDbContext.Chat.AddAsync(newChat, cancellationToken);
            return newChat;
        }

        public async Task<Message> UpdateMessage(MessageReadDto oldMessageDto, MessageWriteDto newMessageDto, CancellationToken cancellationToken = default)
        {
            var message = await _talkDbContext.UserKafka.FirstOrDefaultAsync(s => s.Id == oldMessageDto.Id, cancellationToken);

            if (message is not null)
                await DeleteMessage(oldMessageDto, cancellationToken);

            var newMessage = _mapper.Map<Message>(newMessageDto);
            await _talkDbContext.Message.AddAsync(newMessage, cancellationToken);
            return newMessage;
        }
        #endregion

        #region GET
        public async Task<List<UserKafka>?> GetAllUsers(CancellationToken cancellationToken = default) => await _talkDbContext.UserKafka.ToListAsync(cancellationToken);

        public async Task<List<Chat>?> GetAllChatOfUser(UserKafka userKafka, CancellationToken cancellationToken = default)
        {
            var user = await GetUser(userKafka.Id, cancellationToken);
            if (user is null)
                return null;
            return user.Chats;
        }

        public async Task<List<Message>?> GetAllMessagesOfChat(ChatReadDto chatReadDto, CancellationToken cancellationToken = default)
        {
            var chat = await GetChat(chatReadDto.Id, cancellationToken);
            if (chat is null)
                return null;
            return chat.Messages;
        }

        public async Task<UserKafka?> GetUser(int id, CancellationToken cancellationToken = default) => 
            await _talkDbContext.UserKafka.FirstOrDefaultAsync(s=> s.Id == id, cancellationToken);

        public async Task<Chat?> GetChat(int id, CancellationToken cancellationToken = default) =>
            await _talkDbContext.Chat.FirstOrDefaultAsync(s => s.Id == id, cancellationToken);


        public async Task<Message?> GetMessage(int id, CancellationToken cancellationToken = default) =>
            await _talkDbContext.Message.FirstOrDefaultAsync(s => s.Id == id, cancellationToken);
        #endregion

        #region DELETE
        public async Task<UserKafka> DeleteUserKafka(UserKafka userKafka, CancellationToken cancellationToken = default)
        {
            _talkDbContext.UserKafka.Remove(userKafka);
            return userKafka;
        }

        public async Task<Chat> DeleteChat(ChatReadDto chatReadDto, CancellationToken cancellationToken = default)
        {
            var chat = _mapper.Map<Chat>(chatReadDto);
            _talkDbContext.Chat.Remove(chat);
            return chat;
        }

        public async Task<Message> DeleteMessage(MessageReadDto messageReadDto, CancellationToken cancellationToken = default)
        {
            var message = _mapper.Map<Message>(messageReadDto);
            _talkDbContext.Message.Remove(message);
            return message;
        }
        #endregion

        #region TRANSACTIONAL OUTBOX
        public async Task<IEnumerable<TransactionalOutbox>> GetAllTransactionalOutbox(CancellationToken cancellationToken = default) =>
            await _talkDbContext.TransactionalOutboxe.ToListAsync(cancellationToken);

        public async Task<TransactionalOutbox?> GetTransactionalOutboxByKey(long id, CancellationToken cancellationToken = default) =>
            await _talkDbContext.TransactionalOutboxe.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        public async Task DeleteTransactionalOutbox(long id, CancellationToken cancellationToken = default) =>
            _talkDbContext.TransactionalOutboxe.Remove((await GetTransactionalOutboxByKey(id, cancellationToken)) ?? throw new ArgumentException($"TransactionalOutbox con id {id} non trovato", nameof(id)));

        public async Task InsertTransactionalOutbox(TransactionalOutbox transactionalOutbox, CancellationToken cancellationToken = default) =>
            await _talkDbContext.TransactionalOutboxe.AddAsync(transactionalOutbox);
        #endregion

    }
}
