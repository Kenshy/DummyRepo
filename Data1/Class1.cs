using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
            modelBuilder.Entity<TraitEntity>().HasKey(x => new { x.Id, x.MinVal, x.MaxVal });
        }

        public DbSet<TraitEntity> Traits { get; set; }
        public DbSet<ParagraphEntity> Paragraphs { get; set; }
        public DbSet<CompanyEntity> Companies { get; set; }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<ProfileEntity> Profiles { get; set; }
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

    public class CompanyEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string ShortDescription { get; set; }
    }

    public class UserEntity
    {
        [Key]
        public string Email { get; set; }
        public string Name { get; set; }
        public List<ProfileEntity> Profiles { get; set; }
    }

    public class ProfileEntity
    {
        public string UserId { get; set; }
        public string CompanyId { get; set; }
        public string Analysis { get; set; }
        public UserEntity User { get; set; }
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
