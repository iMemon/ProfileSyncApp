using Microsoft.EntityFrameworkCore;
using ProfileSync.API.Models;

namespace ProfileSync.API.Data;

public class ApiDbContext: DbContext
{
    public DbSet<User> Users { get; set; } = null!;

    public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
    {

    }
}
