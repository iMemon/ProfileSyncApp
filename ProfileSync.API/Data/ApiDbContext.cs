using Microsoft.EntityFrameworkCore;
using ProfileSync.API.Models;

namespace ProfileSync.API.Data;

public class ApiDbContext: DbContext
{
    public DbSet<User> Users { get; set; } = null!;

    public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
    {

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //optionsBuilder.UseSqlServer(@"Data Source=localhost\SQLEXPRESS;Initial Catalog=ContosoPizza-Part1;Integrated Security=True;Encrypt=False");
        optionsBuilder.UseNpgsql("User ID=postgres;Password=1234;Host=localhost;Port=5432;Database=ProfileSyncApp;");
    }
}
