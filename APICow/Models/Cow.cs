using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APICow.Model
{
    public class Cow
    {
        [Key]

        public int CowID { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string Breed { get; set; }

        [Range(0, 50)]
        public int Age { get; set; }

        [Column(TypeName = "decimal(5,2")]
        [Range(0,100)]
        public decimal MilkProduction { get; set; }

        [Required]
        public bool IsPregnant { get; set; }

        [Required]
        public DateTime LastVetCheck { get; set; }


    }
}
