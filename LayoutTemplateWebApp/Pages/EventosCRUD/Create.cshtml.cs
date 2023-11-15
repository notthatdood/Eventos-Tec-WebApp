using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using LayoutTemplateWebApp.Data;
using LayoutTemplateWebApp.Model;

namespace LayoutTemplateWebApp.Pages.EventosCRUD
{
    public class CreateModel : PageModel
    {
        private readonly LayoutTemplateWebApp.Data.ApplicationDbContext _context;

        public CreateModel(LayoutTemplateWebApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["idEventState"] = new SelectList(_context.EventState, "idEventState", "Name");
        ViewData["idEventType"] = new SelectList(_context.EventType, "idEventType", "name");
        ViewData["idFacility"] = new SelectList(_context.Facility, "idFacility", "name");
            return Page();
        }

        [BindProperty]
        public Event Event { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Event == null || Event == null)
            {
                return Page();
            }

            _context.Event.Add(Event);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}
