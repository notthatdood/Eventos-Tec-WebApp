using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LayoutTemplateWebApp.Model
{
    public class Facility
    {
        [Key]
        public int idFacility { get; set; }

        [DisplayName("Nombre")]
        public string name { get; set; }


        [DisplayName("Capacidad")]
        public int capacity { get; set; }

        
        [ForeignKey("idFacilityType")]
        [DisplayName("Tipo de Instalación")]
        public int idFacilityType { get; set; }

        [DisplayName("URL de imagen")]
        public string idImage { get; set; }

        [ForeignKey("idLocation")]
        [DisplayName("Ubicación")]
        public int idLocation { get; set; }

        


        
        [ForeignKey("idFacilityAdministrator")]
        [DisplayName("Administrador")]
        public int idFacilityAdministrator { get; set; }

        // navigation properties

        [DisplayName("Tipo de Instalación")]
        public FacilityType FacilityType { get; set; }


        [DisplayName("Ubicación")]
        public Location Location { get; set; }



        [DisplayName("Administrador")]
        public FacilityAdministrator FacilityAdministrator { get; set; }

        public ICollection<Event> events { get; set; }

    }
}
