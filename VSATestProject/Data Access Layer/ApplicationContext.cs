using Microsoft.EntityFrameworkCore;
using VSATestProject.Entities;

namespace VSATestProject.Data_Access_Layer;

public class ApplicationContext : DbContext
{
    
    public DbSet<Book> Books { get; set; }

    public DbSet<BookProduct> BookProducts { get; set; }

    public DbSet<Purchase> Purchases { get; set; }
    
    public DbSet<Account> Accounts { get; set; }
    
    public DbSet<User> Users { get; set; }
    
    public DbSet<Administrator> Administrators { get; set; }
    
    public DbSet<UserSession> UserSessions { get; set; }
    
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
       modelBuilder.Entity<Administrator>().HasData(new List<Administrator>
           { new Administrator { Id = Guid.NewGuid(), Login = "admin", PasswordHash = "ISMvKXpXpadDiUoOSoAfww==", Sessions = new()} });

       modelBuilder.Entity<UserSession>().HasOne<User>().WithMany(x => x.Sessions).OnDelete(DeleteBehavior.Cascade);
    
       base.OnModelCreating(modelBuilder);
    }
}