using System.ComponentModel.DataAnnotations;

namespace LayoutTemplateWebApp.Model
{
    public class Image
    {
        [Key]
        public int idImage { get; set; }
        public string url { get; set; }
    }
}
