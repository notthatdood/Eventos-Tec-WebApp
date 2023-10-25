using System.ComponentModel.DataAnnotations;

namespace LayoutTemplateWebApp.Model
{
    public class Constraint
    {
        [Key]
        public int idConstraint { get; set; }

        [Required]
        [MaxLength(255)]
        public string name { get; set; }

        [Required]
        [MaxLength(500)]
        public string description { get; set; }
    }

}
