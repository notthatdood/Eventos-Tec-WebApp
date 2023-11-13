using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LayoutTemplateWebApp.Model
{
    public class Request
    {
        [Key]
        [DisplayName("Id de Solicitud")]
        public int idRequest { get; set; }



        // Fecha de la solicitud
        [DisplayName("Fecha")]
        public DateTime date { get; set; }

        [DisplayName("Motivo de solicitud")]
        public string subject { get; set; }



        [Required]
        [MaxLength(255)]
        [DisplayName("Correo")]
        public string email { get; set; }


        [Required]
        [MaxLength(255)]
        [DisplayName("Organizador")]
        public string organizerName { get; set; }


        [ForeignKey("idFacility")]
        [DisplayName("Id de Instalación")]
        public int idFacility { get; set; }

        [ForeignKey("idRequestState")]
        [DisplayName("Id de Estado de Solicitud")]
        public int idRequestState { get; set; }

        [ForeignKey("idEvent")]
        [DisplayName("Id de Evento")]
        public int idEvent { get; set; }

        // navigation properties

        [DisplayName("Instalación")]
        public Facility Facility { get; set; }


        [DisplayName("Estado de Solicitud")]
        public Location RequestState { get; set; }



        [DisplayName("Evento")]
        public Event Event { get; set; }

    }
}