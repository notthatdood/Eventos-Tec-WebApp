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
    public class DetailsModel : PageModel
    {
        private readonly LayoutTemplateWebApp.Data.ApplicationDbContext _context;

        public DetailsModel(LayoutTemplateWebApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

      public Activity Activity { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Activity == null)
            {
                return NotFound();
            }

            var activity = await _context.Activity.FirstOrDefaultAsync(m => m.idActivity == id);
            if (activity == null)
            {
                return NotFound();
            }
            else 
            {
                Activity = activity;
            }
            return Page();
        }
    }
}
