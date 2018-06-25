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

        public DbSet<TraitEntity> Traits { get; set; }
        public DbSet<ParagraphEntity> Paragraphs { get; set; }
    }

    public class TraitEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Id { get; set; }

        public string Text { get; set; }
        public decimal MinVal { get; set; }
        public decimal MaxVal { get; set; }
    }

    public class ParagraphEntity
    {
        public int Id { get; set; }
        public string ParagraphText { get; set; }
        public ParagraphType TypeId { get; set; }
    }

    public enum ParagraphType
    {
        Personal = 1,
        Interpersonal = 2,
        Motivational = 3,
        Leadership = 4,
        Organisational = 5
    }
}
