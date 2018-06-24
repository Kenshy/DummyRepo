using System.ComponentModel.DataAnnotations;

namespace Data.Model
{
    public class TraitTextEntity
    {
        [Key]
        public int Id { get; set; }
        public string TraitId { get; set; }
        public decimal MinVal { get; set; }
        public decimal MaxVal { get; set; }
        public string Text { get; set; }
    }
}
