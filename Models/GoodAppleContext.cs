using Microsoft.EntityFrameworkCore;

namespace GoodApple.Models {
    public class GoodAppleContext : DbContext {
        public GoodAppleContext(DbContextOptions options): base(options) {}
        public DbSet<User> users {get;set;}
        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.Entity<User>()
            .Property("Discriminator")
            .HasMaxLength(200);
        }
        public DbSet<Connection> connections {get;set;}
        public DbSet<Project> projects {get;set;}
        public DbSet<Donation> donations {get;set;}
        public DbSet<Comment> comments {get;set;}
    }
}