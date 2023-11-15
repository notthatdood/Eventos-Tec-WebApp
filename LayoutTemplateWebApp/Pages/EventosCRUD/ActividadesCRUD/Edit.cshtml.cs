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
using Microsoft.Extensions.Logging;

namespace LayoutTemplateWebApp.Pages.EventosCRUD.ActividadesCRUD
{
    public class EditModel : PageModel
    {
        private readonly LayoutTemplateWebApp.Data.ApplicationDbContext _context;

        public EditModel(LayoutTemplateWebApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Activity Activity { get; set; } = default!;
        public int EventId { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id, int eventId)
        {
            if (id == null || _context.Activity == null)
            {
                return NotFound();
            }

            var activity =  await _context.Activity.FirstOrDefaultAsync(m => m.idActivity == id);
            if (activity == null)
            {
                return NotFound();
            }
            EventId = eventId;
            Activity = activity;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            /*
            if (!ModelState.IsValid)
            {
                return Page();
            }
            */
            // Imprimir datos en la consola antes de guardar
            Console.WriteLine("Datos a agregar:");
            Console.WriteLine($"Nombre: {Activity.name}");
            Console.WriteLine($"Descripción: {Activity.description}");
            Console.WriteLine($"Capacidad: {Activity.capacity}");
            Console.WriteLine($"Evento: {Activity.idEvent}");
            Console.WriteLine($"Evento: {Activity.Event?.name}"); // Acceder al nombre del evento
            _context.Attach(Activity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ActivityExists(Activity.idActivity))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("../Index");
        }

        private bool ActivityExists(int id)
        {
          return (_context.Activity?.Any(e => e.idActivity == id)).GetValueOrDefault();
        }
    }
}
