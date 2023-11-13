using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;

namespace LayoutTemplateWebApp.Model
{
    public class Event
    {
        [Key]
        public int idEvent { get; set; }



        [DisplayName("Nombre")]

        public string name { get; set; }

        [DisplayName("Fecha y hora de inicio")]
        public DateTime date { get; set; }

        [DisplayName("Descripción")]
        public string description { get; set; }

        [DisplayName("Organizado por")]
        public string organizer { get; set; }

        [DisplayName("Capacidad máxima")]
        public int capacityNumber { get; set; }

        [DisplayName("Costo de entrada")]
        public string entryCost { get; set; }

        [ForeignKey("EventType")]
        [DisplayName("Tipo de Evento")]
        public int idEventType { get; set; }

		[ForeignKey("Facility")]
        [DisplayName("Instalación")]
        public int idFacility { get; set; }

        [DisplayName("Imagen")]
        public string idImage { get; set; }

        [ForeignKey("EventState")]
        [DisplayName("Estado del Evento")]
        public int idEventState { get; set; }

        // navigation properties
        [DisplayName("Estado del Evento")]
        public EventState? EventState { get; set; }
        [DisplayName("Tipo de Evento")]
        public EventType? EventType { get; set; }
        [DisplayName("Instalación")]
        public Facility? Facility { get; set; }


        public ICollection<Comment>? Comments { get; set; }

        // IMAGE

        //public string EventType { get; set; }
        //public string EventState { get; set; }
    }
}
