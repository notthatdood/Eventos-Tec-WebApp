using System.ComponentModel.DataAnnotations;

namespace LayoutTemplateWebApp.Model
{

    public class Location
    {
        [Key]
        public int idLocation { get; set; }

        [Required]
        [MaxLength(255)]
        public string description { get; set; }

        public string coordinates { get; set; }

        public bool inCampus { get; set; }
    }

}
