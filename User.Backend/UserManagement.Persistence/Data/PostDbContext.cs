using Microsoft.EntityFrameworkCore;

using UserManagement.Domain.Entities;

namespace UserManagement.Persistence.Data
{
    public class PostDbContext : DbContext
    {
        public PostDbContext(DbContextOptions<PostDbContext> options) : base(options)
        {
        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Like> Likes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Настройка таблицы Post
            modelBuilder.Entity<Post>(entity =>
            {
                entity.HasKey(p => p.PostId);

                entity.Property(p => p.Content)
                    .IsRequired()
                    .HasMaxLength(1000);  // Ограничение на длину контента поста

                entity.Property(p => p.CreatedAt)
                    .HasConversion(
                    v => v.ToUniversalTime(),
                    v => DateTime.SpecifyKind(v, DateTimeKind.Utc));

                entity.Property(p => p.UpdatedAt)
                    .IsRequired()
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                // Связь "многие к одному" с пользователем (автор поста)
                entity.HasOne(p => p.User)
                    .WithMany(u => u.Posts)
                    .HasForeignKey(p => p.UserName)
                    .HasPrincipalKey(u => u.UserName)  // Указание поля связи
                    .OnDelete(DeleteBehavior.Cascade);

                // Связь "один ко многим" с комментариями
                entity.HasMany(p => p.Comments)
                    .WithOne(c => c.Post)
                    .HasForeignKey(c => c.PostId)
                    .OnDelete(DeleteBehavior.Cascade);

                // Связь "один ко многим" с лайками
                entity.HasMany(p => p.Likes)
                    .WithOne(l => l.Post)
                    .HasForeignKey(l => l.PostId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            // Пример настройки других сущностей (Users, Comments, Likes)
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(u => u.UserName);
                entity.Property(u => u.UserName).IsRequired().HasMaxLength(100);
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.HasKey(c => c.CommentId);
                entity.Property(c => c.Content).IsRequired().HasMaxLength(250);

                // Связь с пользователем
                entity.HasOne(c => c.User)
                    .WithMany(u => u.Comments)
                    .HasForeignKey(c => c.UserName)  // Указание внешнего ключа
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Like>(entity =>
            {
                entity.HasKey(l => l.LikeId);

                entity.HasOne(l => l.User)
                    .WithMany(u => u.Likes)
                    .HasForeignKey(l => l.UserName) // Здесь используем UserName
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}
