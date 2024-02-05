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
            modelBuilder.Entity<Chat>().ToTable("Chat");
            modelBuilder.Entity<Message>().ToTable("Message");

            modelBuilder.Entity<Chat>().HasKey(s=> new {s.From, s.To});
            modelBuilder.Entity<Message>().HasKey(s => s.Id);

            modelBuilder.Entity<Chat>().HasMany(s=> s.Messages).WithOne(s=> s.Chat).HasForeignKey(s=> s.ChatId).IsRequired();
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Chat> Chat { get; set; }
        public DbSet<Message> Message { get; set; }
    }
}
