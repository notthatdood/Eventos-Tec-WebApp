using System.ComponentModel.DataAnnotations;

namespace LayoutTemplateWebApp.Model
{
    public class EventState
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

    }
}
