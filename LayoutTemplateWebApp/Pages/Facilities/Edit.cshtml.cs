using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LayoutTemplateWebApp.Data;
using LayoutTemplateWebApp.Model;
using System.Text.Json;

namespace LayoutTemplateWebApp.EventosTemp
{
    public class EditModel : PageModel
    {
        private readonly LayoutTemplateWebApp.Data.ApplicationDbContext _context;
        private readonly IHttpClientFactory _clientFactory;
        public string role { get; set; }

        public List<UserAPIModel> PersonList { get; set; }

        public string RawJsonData { get; set; }
        private readonly ApplicationDbContext _db;

        public EditModel(LayoutTemplateWebApp.Data.ApplicationDbContext context, IHttpClientFactory clientFactory)
        {
            _context = context;
            _clientFactory = clientFactory;
        }

        [BindProperty]
        public Facility Facility { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            role = HttpContext.Session.GetString("role");
            PersonList = await LoadPersonsData();
            Console.WriteLine($"Role: {role}");
            if (id == null || _context.Facility == null)
            {
                return NotFound();
            }

            var facility =  await _context.Facility.FirstOrDefaultAsync(m => m.idFacility == id);
            if (facility == null)
            {
                return NotFound();
            }
            Facility = facility;
           ViewData["idFacilityAdministrator"] = new SelectList(_context.FacilityAdministrator, "idFacilityAdministrator", "email");
           ViewData["idFacilityType"] = new SelectList(_context.FacilityType, "idFacilityType", "name");
           //ViewData["idImage"] = new SelectList(_context.Image, "idImage", "alternative_text");
           ViewData["idLocation"] = new SelectList(_context.Location, "idLocation", "description");
            return Page();
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.ErrorCount>=5)
            {
                return Page();
            }

            _context.Attach(Facility).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FacilityExists(Facility.idFacility))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool FacilityExists(int id)
        {
          return (_context.Facility?.Any(e => e.idFacility == id)).GetValueOrDefault();
        }
    }
}
