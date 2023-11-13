using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LayoutTemplateWebApp.Model
{
    public class RequestState
    {
        [Key]
        public int idRequestState { get; set; }

        [DisplayName("Nombre")]
        public string name { get; set; }

        // navigation properties
        public ICollection<Request> requests { get; set; }
    }
}
