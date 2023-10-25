using LayoutTemplateWebApp.Model;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace LayoutTemplateWebApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Event> Event { get; set; } // DbSet para la entidad Event
        public DbSet<FacilityType> FacilityType { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Model.Constraint> Constraints { get; set; }
        public DbSet<FacilityAdministrator> FacilityAdministrators { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Facility> Facility { get; set; }                                        // Agrega otros DbSet para las demás entidades de tu modelo aquí
        public async Task CreateEventAsync(string name, DateTime date, int idEventState, string description, string organizer, string maxCapacity, string entryCost, int idEventType)
        {
            using (var connection = Database.GetDbConnection() as SqlConnection)
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();

                using (var command = new SqlCommand("CreateEvent", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@name", name));
                    command.Parameters.Add(new SqlParameter("@date", date));
                    command.Parameters.Add(new SqlParameter("@idEventState", idEventState));
                    command.Parameters.Add(new SqlParameter("@description", description));
                    command.Parameters.Add(new SqlParameter("@organizer", organizer));
                    command.Parameters.Add(new SqlParameter("@maxCapacity", maxCapacity));
                    command.Parameters.Add(new SqlParameter("@entryCost", entryCost));
                    command.Parameters.Add(new SqlParameter("@idEventType", idEventType));

                    await command.ExecuteNonQueryAsync();
                }
            }
        }
    }
}
