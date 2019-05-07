using Microsoft.EntityFrameworkCore;
using App.Core.Entities;

namespace App.Infrastructure
{
    public class GZContext : DbContext
    {
        public GZContext(DbContextOptions<GZContext> options)
            : base(options)
        {
            
        }

        public DbSet<User> Users { get; set; }
    }
}