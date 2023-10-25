using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
namespace LayoutTemplateWebApp.Model
{
    public class Employee
    {
        [Key]
        [JsonPropertyName("id")]
        public long Id { get; set; }
        [JsonPropertyName("email")]
        public string Email { get; set; }
        [JsonPropertyName("isProfessor")]
        public bool IsProfessor { get; set; }
        [NotMapped]
        [JsonPropertyName("emailNavigation")]
        public object EmailNavigation { get; set; }
    }
}