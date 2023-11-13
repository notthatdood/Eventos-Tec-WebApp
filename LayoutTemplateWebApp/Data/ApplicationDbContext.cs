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
        public DbSet<Comment> Comment { get; set; } // DbSet para la entidad Event

        public DbSet<EventType> EventType { get; set; }

        public DbSet<EventState> EventState { get; set; }

        public DbSet<Facility> Facility { get; set; }

        public DbSet<FacilityType> FacilityType { get; set; }
        public DbSet<Location> Location { get; set; }
        public DbSet<Model.Constraint> Constraint { get; set; }
        public DbSet<FacilityAdministrator> FacilityAdministrator { get; set; }
        public DbSet<Person> Person { get; set; }
		public DbSet<Image> Image { get; set; }
		                                        // Agrega otros DbSet para las demás entidades de tu modelo aquí
        /*public async Task CreateEventAsync(string name, DateTime date, int idEventState, string description, string organizer, string maxCapacity, string entryCost, int idEventType)
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
        }*/
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{

            // RELACIONES FACILITY
            modelBuilder.Entity<Facility>().HasOne(fa => fa.FacilityType).
                WithMany(ft => ft.facilities).HasForeignKey(k => k.idFacilityType);
			
            modelBuilder.Entity<Facility>().HasOne(fa => fa.Location).
			   WithMany(lc => lc.facilities).HasForeignKey(k => k.idLocation);

			modelBuilder.Entity<Facility>().HasOne(fa => fa.FacilityAdministrator).
			   WithMany(fa => fa.facilities).HasForeignKey(k => k.idFacilityAdministrator);

            modelBuilder.Entity<Facility>().HasOne(fa => fa.FacilityAdministrator).
               WithMany(fa => fa.facilities).HasForeignKey(k => k.idFacilityAdministrator);


            // RELACIONES EVENT
            modelBuilder.Entity<Event>().HasOne(e => e.EventState).
               WithMany(es => es.events).HasForeignKey(k => k.idEventState);

             modelBuilder.Entity<Event>().HasOne(e => e.EventType).
             WithMany(et => et.events).HasForeignKey(k => k.idEventType);

            modelBuilder.Entity<Event>().HasOne(e => e.Facility).
            WithMany(fa => fa.events).HasForeignKey(k => k.idFacility);


            modelBuilder.Entity<Comment>().HasOne(c => c.Event).
                WithMany(e=> e.Comments).HasForeignKey(k => k.idEvent);


        }

	}
}
