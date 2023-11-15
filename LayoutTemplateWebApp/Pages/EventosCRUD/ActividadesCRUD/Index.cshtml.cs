using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LayoutTemplateWebApp.Data;
using LayoutTemplateWebApp.Model;

namespace LayoutTemplateWebApp.Pages.EventosCRUD.ActividadesCRUD
{
    public class IndexModel : PageModel
    {
        private readonly LayoutTemplateWebApp.Data.ApplicationDbContext _context;

        public IndexModel(LayoutTemplateWebApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }
        public IList<Activity> Activity { get;set; } = default!;
        public int EventId { get; private set; }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                // Si el id no está presente, puedes manejarlo de alguna manera o devolver un error
                return NotFound();
            }

            // Lógica para cargar la página y establecer EventId
            EventId = id.Value;

            if (_context.Activity != null)
            {
                Activity = await _context.Activity
                    .Where(a => a.idEvent == EventId)
                    .ToListAsync();
            }

            return Page();
        }
    }
}
