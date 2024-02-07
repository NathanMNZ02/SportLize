using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using SportLize.Talk.Api.Talk.Repository.Model;

namespace SportLize.Talk.Api.Talk.Repository
{
    public class TalkDbContext : DbContext
    {
        public TalkDbContext(DbContextOptions<TalkDbContext> options) : base(options)
        {
            try
            {
                if (Database.GetService<IDatabaseCreator>() is RelationalDatabaseCreator databaseCreator)
                {
                    if (!databaseCreator.CanConnect())
                        databaseCreator.Create();

                    if (!databaseCreator.HasTables())
                        databaseCreator.CreateTables();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserKafka>().ToTable("UserKafka");
            modelBuilder.Entity<Chat>().ToTable("Chat");
            modelBuilder.Entity<Message>().ToTable("Message");
            modelBuilder.Entity<TransactionalOutbox>().ToTable("TransactionalOutbox");

            modelBuilder.Entity<UserKafka>().HasKey(s=> s.Id);
            modelBuilder.Entity<Chat>().HasKey(s=> s.Id);
            modelBuilder.Entity<Message>().HasKey(s => s.Id);
            modelBuilder.Entity<TransactionalOutbox>().HasKey(s => s.Id);

            modelBuilder.Entity<UserKafka>().Property(s => s.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Chat>().Property(s => s.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Message>().Property(s => s.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<TransactionalOutbox>().Property(s => s.Id).ValueGeneratedOnAdd();

            modelBuilder.Entity<Chat>().HasMany(s=> s.Messages).WithOne(s=> s.Chat).HasForeignKey(s=> s.ChatId).IsRequired();
            modelBuilder.Entity<UserKafka>().HasMany(s=> s.Chats).WithOne(s=> s.From).HasForeignKey(s=> s.FromId).IsRequired();
            modelBuilder.Entity<UserKafka>().HasMany(s => s.Chats).WithOne(s => s.To).HasForeignKey(s => s.ToId).IsRequired();
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Chat> Chat { get; set; }
        public DbSet<Message> Message { get; set; }
        public DbSet<UserKafka> UserKafka { get; set; }

        //Transactional
        public DbSet<TransactionalOutbox> TransactionalOutboxe { get; set; }
    }
}
