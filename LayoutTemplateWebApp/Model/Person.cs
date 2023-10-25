using System.ComponentModel.DataAnnotations;

namespace LayoutTemplateWebApp.Model
{
    public class Person
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string email { get; set; }

        [Required]
        [MaxLength(255)]
        public string personPassword { get; set; }

        public int cardNumber { get; set; }

        [Required]
        [MaxLength(255)]
        public string personName { get; set; }

        [Required]
        [MaxLength(255)]
        public string firstLastName { get; set; }

        [MaxLength(255)]
        public string secondLastName { get; set; }

        public decimal debt { get; set; }
    }
}
