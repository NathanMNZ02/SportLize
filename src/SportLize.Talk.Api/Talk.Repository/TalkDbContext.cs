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
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Chat>().ToTable("Chat");
            modelBuilder.Entity<Message>().ToTable("Message");

            modelBuilder.Entity<Chat>().HasKey(s=> s.Id);
            modelBuilder.Entity<Message>().HasKey(s => s.Id);

            modelBuilder.Entity<Chat>().Property(s => s.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Message>().Property(s => s.Id).ValueGeneratedOnAdd();

            modelBuilder.Entity<Chat>().HasMany(s=> s.Messages).WithOne(s=> s.Chat).HasForeignKey(s=> s.ChatId).IsRequired();
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Chat> Chat { get; set; }
        public DbSet<Message> Message { get; set; }

    }
}
