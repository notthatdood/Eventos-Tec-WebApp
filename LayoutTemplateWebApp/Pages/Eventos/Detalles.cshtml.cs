using LayoutTemplateWebApp.Data;
using LayoutTemplateWebApp.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LayoutTemplateWebApp.Data;
using LayoutTemplateWebApp.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Diagnostics;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Linq.Expressions;
using System.Net.Mail;
using System.Net;

namespace LayoutTemplateWebApp.Pages.Eventos
{
    public class DetallesModel : PageModel
    {
        private readonly LayoutTemplateWebApp.Data.ApplicationDbContext _context;
        private readonly IHttpClientFactory _clientFactory;
        public string role { get; set; }
        public List<UserAPIModel> PersonList { get; set; }
        public string RawJsonData { get; set; }
        private readonly ApplicationDbContext _db;

        public Event Event { get; set; } = default!;
        public Comment Comment { get; set; } // Aqui guardo el post de comentario nuevo

		public Event getEvent(int id)
		{
			Event evento = _db.Event.FirstOrDefault(u => u.idEvent == id);
            int idFacilityEvent = evento.idFacility;
            evento.Facility = _db.Facility.FirstOrDefault(u => u.idFacility == idFacilityEvent);

            int idEventTypeEvent = evento.idEventType;
            evento.EventType = _db.EventType.FirstOrDefault(u => u.idEventType == idEventTypeEvent);


            int idEventStateEvent = evento.idEventState;
            evento.EventState = _db.EventState.FirstOrDefault(u => u.idEventState == idEventStateEvent);
            evento.Comments = new List<Comment>();
            evento.Comments = _db.Comment.Where(c => c.idEvent == id).ToList();

			return evento;
        }

        public async Task OnGet(int id)
		{
            Response.Cookies.Append("currentEventId", id.ToString());
            role = HttpContext.Session.GetString("role");
            PersonList = await LoadPersonsData();
            Event = getEvent(id);
            


            //Event = _db.Facility.FirstOrDefault(u => u.idFacility == Event.idFacility);
            //          Event = _db.Facility.FirstOrDefault(u => u.idFacility == Event.idFacility);
            //        Event.Facility = _db.Facility.Find(Event.idFacility);
            //	Event.EventType = _db.EventType.Find(Event.idEventType);

            //Event.EventState = _db.EventState.Find(Event.idEventState);
        }

        public DetallesModel(ApplicationDbContext db, IHttpClientFactory clientFactory, LayoutTemplateWebApp.Data.ApplicationDbContext context)
		{
            _context = context;
            _db = db;
			_clientFactory = clientFactory;
		}

		/*
		public async Task OnGet2()
		{
			role = HttpContext.Session.GetString("role");
			PersonList = await LoadPersonsData();

		}
		*/
		/*
		 * public async Task OnPost(int id)
		{


		}
		*/
        public async Task<IActionResult> OnPostCommentAsync(int id)

        {
            Event = getEvent(id);

            if (!ModelState.IsValid || _db.Event == null || Event == null)
            {
                return RedirectToPage("./Calendario");
                //return Page();
            }

            Comment.idEvent = Event.idEvent;
			Comment.date = DateTime.Now;
			_db.Comment.Add(Comment);
            await _db.SaveChangesAsync();

			return RedirectToPage("./Calendario");
            //return RedirectToPage("/Edit" + Event.idEvent);
        }
        public async Task<List<UserAPIModel>> LoadPersonsData()
		{
			var client = _clientFactory.CreateClient();
			var response = await client.GetAsync("http://sistema-tec.somee.com/api/users");
			List<UserAPIModel> personList = new List<UserAPIModel>();
			if (response.IsSuccessStatusCode)
			{
				try
				{
					var data = await response.Content.ReadAsStringAsync();
					var allPersons = JsonSerializer.Deserialize<List<UserAPIModel>>(data);
					personList = allPersons.Where(p => p.ApplicationRoles.Any(ar =>
						ar.ApplicationId == 8 && ar.ApplicationRoleName != null
					)).ToList();
					RawJsonData = JsonSerializer.Serialize(personList);
				}
				catch (JsonException ex)
				{
					RawJsonData = $"Error deserializing data: {ex.Message}";
				}
			}
			else
			{
				RawJsonData = $"Error: {response.StatusCode}";
			}
			return personList;
		}

        private bool EventExists(int id)
        {
            return (_context.Event?.Any(e => e.idEvent == id)).GetValueOrDefault();
        }

        public async Task<IActionResult> OnPostReservar()
        {
            string id = Request.Cookies["currentEventId"];
            Event = getEvent(Int32.Parse(id));
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Event.capacityNumber = Event.capacityNumber - 1;
            _context.Attach(Event).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventExists(Event.idEvent))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("bibliotecmail@gmail.com", "pubrnylofjmuqmff"),
                EnableSsl = true,
            };
            string email = HttpContext.Session.GetString("email");
            Random rand = new Random();
            int randomAccessCode = rand.Next(111111, 999999);
            string message = "Confirmación de reservación para el evento: " + Event.name + "\n" + "Su código de acceso es: " + randomAccessCode.ToString();
            smtpClient.Send("bibliotecmail@gmail.com", email, "Confirmación de Reservación", message);
            return RedirectToPage("Calendario");
        }
    }
}
