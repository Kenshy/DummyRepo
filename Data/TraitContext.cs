using Data.Model;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class TraitContext : DbContext
    {
        public TraitContext(DbContextOptions<TraitContext> options) : base(options)
        {
            
        }

        public DbSet<TraitTextEntity> TraitEntities { get; set; }
    }
}
