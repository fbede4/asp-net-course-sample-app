using ChatApp.Model;
using Microsoft.EntityFrameworkCore;

namespace ChatApp.Api.Dal
{
    public class ChatAppDbContext : DbContext
    {
        public ChatAppDbContext(DbContextOptions<ChatAppDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Message> Messages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(u => u.MessagesSent)
                .WithOne(m => m.SenderUser)
                .HasForeignKey(m => m.SenderUserId);

            modelBuilder.Entity<User>()
                .HasMany(u => u.MessagesRecieved)
                .WithOne(m => m.RecipientUser)
                .HasForeignKey(m => m.RecipientUserId);
        }
    }
}
