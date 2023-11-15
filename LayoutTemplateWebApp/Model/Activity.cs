using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LayoutTemplateWebApp.Model
{
    public class Activity
    {
        [Key]
        public int idActivity { get; set; }

        [DisplayName("Nombre")]
        public string name { get; set; }

        [DisplayName("Descripción")]
        public string description { get; set; }


        [DisplayName("Capacidad")]
        public int capacity { get; set; }



        [ForeignKey("idEvent")]
        [DisplayName("Id de Evento")]
        public int idEvent { get; set; }



        // navigation properties

        [DisplayName("Evento")]
        public Event Event { get; set; }


    }
}
