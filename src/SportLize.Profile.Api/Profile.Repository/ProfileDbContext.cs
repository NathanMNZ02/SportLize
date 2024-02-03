using System;
using System.Net.Sockets;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using SportLize.Profile.Api.Profile.Repository.Model;

namespace SportLize.Profile.Api.Profile.Repository
{
	public class ProfileDbContext : DbContext
	{
        public ProfileDbContext(DbContextOptions<ProfileDbContext> options) : base(options)
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
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<Post>().ToTable("Post");
            modelBuilder.Entity<Comment>().ToTable("Comment");
            modelBuilder.Entity<UserInterest>().ToTable("UserInterest");
            modelBuilder.Entity<PostInterest>().ToTable("PostInterest");

            modelBuilder.Entity<User>().HasKey(s => s.Id);
            modelBuilder.Entity<Post>().HasKey(s => s.Id );
            modelBuilder.Entity<Comment>().HasKey(s => s.Id);
            modelBuilder.Entity<UserInterest>().HasKey(s => s.Id);
            modelBuilder.Entity<PostInterest>().HasKey(s => s.Id);

            //Relation one to one
            modelBuilder.Entity<User>().HasOne(s => s.UserInterest).WithOne(s => s.User).HasForeignKey<UserInterest>(s => s.UserId);

            modelBuilder.Entity<Post>().HasOne(s => s.PostInterest).WithOne(s => s.Post).HasForeignKey<PostInterest>(s => s.PostId);

            //Many to many
            modelBuilder.Entity<User>().HasMany(u => u.Followers).WithMany();
            modelBuilder.Entity<User>().HasMany(u => u.Following).WithMany();


            base.OnModelCreating(modelBuilder);
        }

        public DbSet<User> User { get; set; }
		public DbSet<Post> Post { get; set; }
		public DbSet<Comment> Comment { get; set; }

        //Interest
        public DbSet<UserInterest> UserInterest { get; set; }
        public DbSet<PostInterest> PostInterest { get; set; }
	}
}

