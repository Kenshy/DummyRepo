using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Data1
{
    public class PersonalityContext : DbContext
    {
        public PersonalityContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<TraitEntity>().HasKey(x => new {x.Id, x.MinVal, x.MaxVal});
        }

        public DbSet<TraitEntity> Traits{get;set;}
    }

    public class TraitEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Id { get; set; }
        public string Text{ get; set; }
        public decimal MinVal { get; set; }
        public decimal MaxVal { get; set; }
    }
}
