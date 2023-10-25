using System.ComponentModel.DataAnnotations;

namespace LayoutTemplateWebApp.Model
{
    public class Facility
    {
        [Key]
        public int idFacility { get; set; }

        public string name { get; set; }

        public int idBuildingType { get; set; }

        public int capacity { get; set; }

        public int idLocation { get; set; }

        public int idFacilityAdministrator { get; set; }
    }
}
