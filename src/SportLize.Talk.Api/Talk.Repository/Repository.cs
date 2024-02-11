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
            _talkDbContext.Database.Migrate();
        }

        public async Task<int> SaveChanges(CancellationToken cancellationToken = default)
        {
            return await _talkDbContext.SaveChangesAsync();
        }

        #region INSERT
        public async Task<UserKafka> InsertUserKafka(UserKafka userKafka, CancellationToken cancellationToken = default)
        {
            await _talkDbContext.UserKafka.AddAsync(userKafka);
            return userKafka;
        }

        public async Task<Chat> InsertChatForSender(int userId, ChatWriteDto chatWriteDto, CancellationToken cancellationToken = default)
        {
            var chat = _mapper.Map<Chat>(chatWriteDto);

            var user = await GetUser(userId, cancellationToken);
            if (user is not null)
            {
                chat.SenderId = user.Id;
                chat.Sender = user;
                user.SentChats.Add(chat);
            }

            return chat;
        }

        public async Task<Chat> InsertChatForReceiver(int userId, ChatWriteDto chatWriteDto, CancellationToken cancellationToken = default)
        {
            var chat = _mapper.Map<Chat>(chatWriteDto);

            var user = await GetUser(userId, cancellationToken);
            if(user is not null)
            {
                chat.ReceiverId = user.Id;
                chat.Receiver = user;
                user.ReceivedChats.Add(chat);
            }

            return chat;
        }

        public async Task<Message> InsertMessageInChat(int chatId, MessageWriteDto messageWriteDto, CancellationToken cancellationToken = default)
        {
            var message = _mapper.Map<Message>(messageWriteDto);

            var chat = await GetChat(chatId, cancellationToken);
            if (chat is not null)
            {
                message.ChatId = chat.Id;
                message.Chat = chat;
                chat.Messages.Add(message);
            }

            return message;
        }
        #endregion

        #region UPDATE
        public async Task<UserKafka> UpdateUserKafka(UserKafka userKafka, CancellationToken cancellationToken = default)
        {
            _talkDbContext.UserKafka.Update(userKafka);
            return userKafka;
        }

        public async Task<Chat> UpdateChat(ChatReadDto chatReadDto, CancellationToken cancellationToken = default)
        {
            var chat = _mapper.Map<Chat>(chatReadDto);
            _talkDbContext.Chat.Update(chat);
            return chat;
        }

        public async Task<Message> UpdateMessage(MessageReadDto messageReadDto, CancellationToken cancellationToken = default)
        {
            var message = _mapper.Map<Message>(messageReadDto);
            _talkDbContext.Message.Update(message);
            return message;
        }
        #endregion

        #region GET
        public async Task<List<UserKafka>?> GetAllUsers(CancellationToken cancellationToken = default) => await _talkDbContext.UserKafka.ToListAsync(cancellationToken);

        public async Task<List<Chat>?> GetAllSentChatOfUser(int userId, CancellationToken cancellationToken = default)
        {
            var user = await _talkDbContext.UserKafka.Include(u => u.ReceivedChats).FirstOrDefaultAsync(u => u.Id == userId, cancellationToken);
            return user?.SentChats;
        }
        public async Task<List<Chat>?> GetAllReceivedChatOfUser(int userId, CancellationToken cancellationToken = default)
        {
            var user = await _talkDbContext.UserKafka.Include(u => u.ReceivedChats).FirstOrDefaultAsync(u => u.Id == userId, cancellationToken);
            return user?.ReceivedChats;
        }

        public async Task<List<Message>?> GetAllMessagesOfChat(int chatId, CancellationToken cancellationToken = default)
        {
            var chat = await _talkDbContext.Chat.Include(u => u.Messages).FirstOrDefaultAsync(u => u.Id == chatId, cancellationToken);
            return chat?.Messages;
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
