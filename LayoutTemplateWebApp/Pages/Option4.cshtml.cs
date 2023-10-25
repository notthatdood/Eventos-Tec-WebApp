using LayoutTemplateWebApp.Data;
using LayoutTemplateWebApp.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;


namespace LayoutTemplateWebApp.Pages
{
    public class Option4Model : PageModel
    {
        private readonly IHttpClientFactory _clientFactory;
        public string role { get; set; }

        public List<UserAPIModel> PersonList { get; set; }
        public string RawJsonData { get; set; }
        private readonly ApplicationDbContext _db;

        public Dictionary<int, List<Facility>> GroupedFacilities { get; set; }

        public List<FacilityType> Ftypes { get; set; }

        [BindProperty]
        public IFormFile EventImage { get; set; }

        [BindProperty]
        public Event Events { get; set; }

        public Option4Model(ApplicationDbContext db, IHttpClientFactory clientFactory)
        {
            _db = db;
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
        public void OnGet()
        {
            // Recuperar instalaciones de la base de datos
            role = HttpContext.Session.GetString("role");
            var facilities = _db.Facility.ToList();
            var types = _db.FacilityType.ToList();

            // Agrupar instalaciones por idBuildingType
            GroupedFacilities = facilities
                 .GroupBy(f => f.idBuildingType)
                .ToDictionary(g => g.Key, g => g.ToList());

            Ftypes = types;


        }
        public async Task<IActionResult> OnPost()
        {

            Console.WriteLine($"Fecha del formulario: {Events.date}");

            if (EventImage != null && EventImage.Length > 0)
            {
                // Verifica que se haya cargado una imagen
                using (var stream = new MemoryStream())
                {
                    // Copia la imagen al flujo de memoria
                    await EventImage.CopyToAsync(stream);

                    // Crea una instancia de tu modelo de Image y establece la URL de la imagen
                    var image = new Image
                    {
                        url = "C:\\Users\\Raul\\Desktop\\ProyectoDiseno\\GestionEventos-main\\LayoutTemplateWebApp\\Images\\", // Debes especificar la ubicación de almacenamiento real aquí
                                                                                                                               // Otros campos de la imagen, si los tienes
                    };

                    // Agrega la imagen a la base de datos
                    await _db.Images.AddAsync(image);

                    // Guarda los cambios en la base de datos
                    await _db.SaveChangesAsync();
                }
            }
            await _db.Event.AddAsync(Events);
            await _db.SaveChangesAsync();
            return RedirectToPage("/Option1");
        }
    }
}