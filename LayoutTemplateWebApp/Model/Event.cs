using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;

namespace LayoutTemplateWebApp.Model
{
    public class Event
    {
        [Key]
        public int idEvent { get; set; }
        public string name { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime date { get; set; }
        public int idEventState { get; set; }
        public string description { get; set; }
        public string organizer { get; set; }
        public int capacityNumber { get; set; }
        public int idCapacityType { get; set; }
        public string entryCost { get; set; }
        public int idEventType { get; set; }
        public int idFacility { get; set; }
        public int idImage { get; set; }
        //public string EventType { get; set; }
        //public string EventState { get; set; }
    }
}
