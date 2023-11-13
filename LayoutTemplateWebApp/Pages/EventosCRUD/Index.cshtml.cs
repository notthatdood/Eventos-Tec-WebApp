using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LayoutTemplateWebApp.Data;
using LayoutTemplateWebApp.Model;
using System.Data;
using System.Text.Json;

namespace LayoutTemplateWebApp.Pages.EventosCRUD
{
    public class IndexModel : PageModel
    {
        private readonly LayoutTemplateWebApp.Data.ApplicationDbContext _context;
        private readonly IHttpClientFactory _clientFactory;
        public string role { get; set; }

        public List<UserAPIModel> PersonList { get; set; }
        public string RawJsonData { get; set; }
        private readonly ApplicationDbContext _db; // Reemplaza "ApplicationDbContext" con el contexto de tu base de datos
        public IndexModel(LayoutTemplateWebApp.Data.ApplicationDbContext context, IHttpClientFactory clientFactory)
        {
            _context = context;
            _clientFactory = clientFactory;
        }

        public IList<Event> Event { get;set; } = default!;


        public async Task role_setup()
        {
            //var events = _db.Event.ToList();
            //var facilities = _db.Facility.ToList();
            role = HttpContext.Session.GetString("role");
            PersonList = await LoadPersonsData();
            Console.WriteLine($"Role: {role}");
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
        public async Task OnGetAsync()
        {
            if (_context.Event != null)
            {
                await role_setup();
                Event = await _context.Event
                .Include(e => e.EventState)
                .Include(e => e.EventType)
                .Include(e => e.Facility).ToListAsync();
            }
        }
    }
}
