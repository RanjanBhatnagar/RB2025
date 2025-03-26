using BasicAuthWithDB.Models;
using Microsoft.EntityFrameworkCore;

namespace BasicAuthWithDB.Data
{
    public class UsersDBContext : DbContext
    {
        public UsersDBContext(DbContextOptions<UsersDBContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
    }
}
