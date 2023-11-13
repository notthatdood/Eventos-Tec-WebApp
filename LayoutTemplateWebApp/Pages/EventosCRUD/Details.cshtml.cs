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
    public class DetailsModel : PageModel
    {
        private readonly LayoutTemplateWebApp.Data.ApplicationDbContext _context;

        public DetailsModel(LayoutTemplateWebApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

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
                //evento.EventState

                int idEventState = Event.idEventState;
                // Se genera con nombre context. En otras se llama _db
                Event.EventState = _context.EventState.FirstOrDefault(u => u.idEventState == idEventState);

                int idEventType = Event.idEventType;
                Event.EventType = _context.EventType.FirstOrDefault(u => u.idEventType == idEventType);


                int idFacility = Event.idFacility;
                Event.Facility = _context.Facility.FirstOrDefault(u => u.idFacility == idFacility);
                


               

            }
            return Page();
        }
    }
}
