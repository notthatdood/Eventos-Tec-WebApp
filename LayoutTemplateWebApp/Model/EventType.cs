using System.ComponentModel.DataAnnotations;

namespace LayoutTemplateWebApp.Model
{
    public class EventType
    {
        [Key]
        public int Id { get; set; }
        public string description { get; set; }
    }
}
