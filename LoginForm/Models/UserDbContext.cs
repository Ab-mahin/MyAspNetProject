using Microsoft.EntityFrameworkCore;

namespace LoginForm.Models;

public class UserDbContext : DbContext
{
    public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
    {
        
    }
    public virtual DbSet<UseTbls> Users{ get; set; }
}