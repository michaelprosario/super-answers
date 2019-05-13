using Microsoft.EntityFrameworkCore;
using App.Core.Entities;

namespace App.Infrastructure
{
    public class EfContext : DbContext
    {
        public EfContext(DbContextOptions<EfContext> options)
            : base(options)
        {
            
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Core.DbEntities.Question> Questions { get; set; }
        public DbSet<Core.DbEntities.QuestionTag> QuestionTags { get; set; }
    }
}