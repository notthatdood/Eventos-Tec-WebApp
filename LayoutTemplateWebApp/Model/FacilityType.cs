using System.ComponentModel.DataAnnotations;

namespace LayoutTemplateWebApp.Model
{
    public class FacilityType
    {
        [Key]
        public int idFacilityType { get; set; }
        public string name { get; set; }
    }
}
