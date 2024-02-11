using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using SportLize.Team.Api.Team.Repository.Model;

namespace SportLize.Team.Api.Team.Repository
{
    public class TeamDbContext : DbContext
    {
        public TeamDbContext(DbContextOptions<TeamDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Group>().ToTable("Group");
            modelBuilder.Entity<Message>().ToTable("Message");
            modelBuilder.Entity<UserKafka>().ToTable("UserKafka");
            modelBuilder.Entity<TransactionalOutbox>().ToTable("TransactionalOutbox");

            modelBuilder.Entity<Group>().HasKey(s => s.Id);
            modelBuilder.Entity<Message>().HasKey(s => s.Id);
            modelBuilder.Entity<UserKafka>().HasKey(s => s.Id);
            modelBuilder.Entity<TransactionalOutbox>().HasKey(s=> s.Id);

            modelBuilder.Entity<Group>().Property(s => s.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Message>().Property(s => s.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<UserKafka>().Property(s => s.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<TransactionalOutbox>().Property(s => s.Id).ValueGeneratedOnAdd();

            modelBuilder.Entity<Group>().HasMany(s => s.UsersKafka).WithOne(s => s.Group).HasForeignKey(s => s.GroupId).IsRequired();
            modelBuilder.Entity<Group>().HasMany(s => s.Messages).WithOne(s => s.Group).HasForeignKey(s => s.GroupId).IsRequired();

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Group> Group { get; set; }
        public DbSet<Message> Message { get; set; }

        //TRANSACTIONAL
        public DbSet<TransactionalOutbox> TransactionalOutboxe { get; set; }

        //KAFKA
        public DbSet<UserKafka> UserKafka { get; set; }
    }
}
