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

namespace LayoutTemplateWebApp.Pages.EventosCRUD
{
    public class EditModel : PageModel
    {
        private readonly LayoutTemplateWebApp.Data.ApplicationDbContext _context;

        public EditModel(LayoutTemplateWebApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Event Event { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Event == null)
            {
                return NotFound();
            }

            var evento =  await _context.Event.FirstOrDefaultAsync(m => m.idEvent == id);
            if (evento == null)
            {
                return NotFound();
            }
            Event = evento;
            ViewData["idEventState"] = new SelectList(_context.EventState, "idEventState", "Name");
            ViewData["idEventType"] = new SelectList(_context.EventType, "idEventType", "name");
            ViewData["idFacility"] = new SelectList(_context.Facility, "idFacility", "name");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

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

            return RedirectToPage("./Index");
        }

        private bool EventExists(int id)
        {
          return (_context.Event?.Any(e => e.idEvent == id)).GetValueOrDefault();
        }
    }
}
