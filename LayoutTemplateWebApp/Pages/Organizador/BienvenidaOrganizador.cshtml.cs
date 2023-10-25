using LayoutTemplateWebApp.Data;
using LayoutTemplateWebApp.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace LayoutTemplateWebApp.Pages.Organizador
{
    public class BienvenidaOrganizadorModel : PageModel
    {
        public List<Event> Solicitudes { get; set; }
        private readonly IHttpClientFactory _clientFactory;
        public string role { get; set; }

        public List<UserAPIModel> PersonList { get; set; }
        public string RawJsonData { get; set; }

        public BienvenidaOrganizadorModel(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task OnGet2()
        {
            role = HttpContext.Session.GetString("role");
            PersonList = await LoadPersonsData();

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

        public async Task OnGet()
        {
            // Aquí debes cargar las solicitudes de eventos desde la base de datos
            //Solicitudes = _db.Event.Where(e => e.EsSolicitud).ToList();
            role = HttpContext.Session.GetString("role");
            PersonList = await LoadPersonsData();
            Console.WriteLine($"Role: {role}");
        }
    }
}
