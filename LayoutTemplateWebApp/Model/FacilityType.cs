using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LayoutTemplateWebApp.Model
{
    public class FacilityType
    {
        [Key]
        public int idFacilityType { get; set; }

        [DisplayName("Nombre")]
        public string name { get; set; }

		// navigation properties
		public ICollection<Facility> facilities { get; set; }
	}
}
