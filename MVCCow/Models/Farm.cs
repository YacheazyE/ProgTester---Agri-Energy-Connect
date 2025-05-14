using System.ComponentModel.DataAnnotations;

namespace MVCCow.Models
{
    public class Farm
    {
        [Key]

        public int FarmID { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }


    }
}
