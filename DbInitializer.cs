
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace identity.user;

public static class DbInitializer
{
  public static void InjectDbContextAndIdentity(this IServiceCollection services)
  {
    services.AddDbContext<UserDbContext>();

    services.AddIdentity<User, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<UserDbContext>()
    .AddDefaultTokenProviders();

    var db = services.BuildServiceProvider().GetRequiredService<UserDbContext>();
    db.Database.CanConnectAsync().ContinueWith(_ => db.Database.Migrate());
  }

}