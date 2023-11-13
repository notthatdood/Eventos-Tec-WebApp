using System.ComponentModel.DataAnnotations;

namespace LayoutTemplateWebApp.Model
{
    public class EventType
    {
        [Key]
        public int idEventType { get; set; }
        public string name { get; set; }
        public string description { get; set; }

        // navigation properties
        public ICollection<Event> events { get; set; }

    }
}
