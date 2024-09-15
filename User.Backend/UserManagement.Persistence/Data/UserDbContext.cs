using Microsoft.EntityFrameworkCore;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Enums;

namespace UserManagement.Persistence.Data
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) 
            : base(options) { }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Конфигурация таблиц и связей
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.UserId);
                entity.Property(e => e.Sex)
                      .HasConversion(
                          v => v.ToString().ToLower(),  // Преобразует enum в строку
                          v => (Gender)Enum.Parse(typeof(Gender), v, true) // Преобразует строку обратно в enum
                      )
                      .HasColumnType("text"); // Соответствие PostgreSQL типу
            });
        }
    }
}
