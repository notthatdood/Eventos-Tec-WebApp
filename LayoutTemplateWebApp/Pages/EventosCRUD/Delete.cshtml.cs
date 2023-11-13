using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LayoutTemplateWebApp.Data;
using LayoutTemplateWebApp.Model;

namespace LayoutTemplateWebApp.Pages.EventosCRUD
{
    public class DeleteModel : PageModel
    {
        private readonly LayoutTemplateWebApp.Data.ApplicationDbContext _context;

        public DeleteModel(LayoutTemplateWebApp.Data.ApplicationDbContext context)
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

            var evento = await _context.Event.FirstOrDefaultAsync(m => m.idEvent == id);

            if (evento == null)
            {
                return NotFound();
            }
            else 
            {
                Event = evento;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Event == null)
            {
                return NotFound();
            }
            var evento = await _context.Event.FindAsync(id);

            if (evento != null)
            {
                Event = evento;
                _context.Event.Remove(Event);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
