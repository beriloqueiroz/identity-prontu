namespace identity.user;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

public class UserDbContext : IdentityDbContext<User>
{
  public static string UrlConnection = "Host=localhost;Database=prontu_db;Username=teste;Password=teste";
  public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
  {
    AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);//para solucionar datetime error Pgsql
  }
  protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseNpgsql(UrlConnection);
  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);
  }
}