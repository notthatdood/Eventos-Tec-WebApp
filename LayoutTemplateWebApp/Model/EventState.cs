using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LayoutTemplateWebApp.Model
{
    public class EventState
    {
        [Key]
        [DisplayName(nameof(EventState))]
        public int idEventState { get; set; }
        public string Name { get; set; }


		// navigation properties
		public ICollection<Event> events { get; set; }
	}
}
