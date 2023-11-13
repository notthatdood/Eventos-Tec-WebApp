using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LayoutTemplateWebApp.Model
{
    public class Comment
    {
        [Key]
        public int idComment { get; set; }

        [DisplayName("Correo")]
        public string email { get; set; }

        [DisplayName("Fecha")]
        public DateTime date { get; set; }


        [DisplayName("Comentario")]
        [Required]
        [MaxLength(500)]
        public string text { get; set; }



        [ForeignKey("idEvent")]
        [DisplayName("Id de Evento")]
        public int idEvent { get; set; }



        // navigation properties

        [DisplayName("Evento")]
        public Event Event { get; set; }


    }
}
