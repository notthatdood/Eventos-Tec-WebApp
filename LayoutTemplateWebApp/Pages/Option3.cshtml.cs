using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LayoutTemplateWebApp.Model;
using LayoutTemplateWebApp.Data;
using System.Text.Json;
using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;


namespace LayoutTemplateWebApp.Pages
{
    public class Option3Model : PageModel

    {
        private readonly IHttpClientFactory _clientFactory;
        public string role { get; set; }

        public List<UserAPIModel> PersonList { get; set; }
        public string RawJsonData { get; set; }
        private readonly ApplicationDbContext _db; // Reemplaza "ApplicationDbContext" con el contexto de tu base de datos


        public Option3Model(ApplicationDbContext db, IHttpClientFactory clientFactory)

        {
            _db = db;
            _clientFactory = clientFactory;
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



        public async Task role_setup()
        {
            var events = _db.Event.ToList();
            var facilities = _db.Facility.ToList();
            role = HttpContext.Session.GetString("role");
            PersonList = await LoadPersonsData();
            Console.WriteLine($"Role: {role}");
        }
        public async Task OnGet()
        {
            role_setup();
            // Recuperar eventos de la base de datos


        }
    }
}