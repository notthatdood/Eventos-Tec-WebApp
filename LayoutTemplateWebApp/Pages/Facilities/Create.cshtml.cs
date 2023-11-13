using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using LayoutTemplateWebApp.Data;
using LayoutTemplateWebApp.Model;

namespace LayoutTemplateWebApp.EventosTemp
{
    public class CreateModel : PageModel
    {
        private readonly LayoutTemplateWebApp.Data.ApplicationDbContext _context;
        private readonly IHttpClientFactory _clientFactory;
        public string role { get; set; }

        public List<UserAPIModel> PersonList { get; set; }

        public string RawJsonData { get; set; }
        private readonly ApplicationDbContext _db; // Reemplaza "ApplicationDbContext" con el contexto de tu base de datos


        public CreateModel(LayoutTemplateWebApp.Data.ApplicationDbContext context, IHttpClientFactory clientFactory)
        {
            _context = context;
            _clientFactory = clientFactory;
        }

        public IActionResult OnGet()
        {
        ViewData["idFacilityAdministrator"] = new SelectList(_context.FacilityAdministrator, "idFacilityAdministrator", "email");
        ViewData["idFacilityType"] = new SelectList(_context.FacilityType, "idFacilityType", "name");
        //ViewData["idImage"] = new SelectList(_context.Image, "idImage", "alternative_text");
        ViewData["idLocation"] = new SelectList(_context.Location, "idLocation", "description");
            return Page();
        }

        [BindProperty]
        public Facility Facility { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            // Esto es un hack porque cuentan como errores
            // que los objetos no se hayan creado. 
            // Los ids están correctos pero no el objeto asociado.
            if ((ModelState.ErrorCount>5) || _context.Facility == null || Facility == null)
            {
                return Page();
            }

            _context.Facility.Add(Facility);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
