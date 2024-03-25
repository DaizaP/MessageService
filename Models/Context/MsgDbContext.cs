using Microsoft.EntityFrameworkCore;

namespace MessageService.Models.Context
{
    public partial class MsgDbContext(DbContextOptions<MsgDbContext> dbc) : DbContext(dbc)
    {
        public DbSet<MessageModel> Messages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MessageModel>(entity =>
            {
                entity.HasKey(e => e.MessageId).HasName("MessageId");

                entity.Property(e => e.SenderId).HasColumnName("SenderId");
                entity.Property(e => e.RecipientId).HasColumnName("RecipientId");

                entity.Property(e => e.Content).HasColumnName("Content");
                entity.Property(e => e.MsgStatus).HasColumnName("Status").HasConversion<string>();

                

            });
            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
