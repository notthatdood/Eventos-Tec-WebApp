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
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Diagnostics;
using Newtonsoft.Json;

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
            Debug.WriteLine("kachika");
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
            
            using var client = new HttpClient();
            var response = await client.GetAsync("http://sistema-tec.somee.com/api/users");
            var result = await response.Content.ReadAsStringAsync();
            List<UserAPIModel> personList = JsonConvert.DeserializeObject<List<UserAPIModel>>(result); //new List<UserAPIModel>();
            Random rand = new Random();
            string email;
            string message;
            List<string> ignoreMailList = new List<string>
            {
                "chacalerks@estudiantec.cr",
                "curio@estudiantec.cr",
                "dagger@estudiantec.cr",
                "dani.alvarado@estudiantec.cr",
                "fermurillo04@estudiantec.cr",
                "gromero0907@estudiantec.cr",
                "jenniferespinach104@estudiantec.cr",
                "jhonnsc@estudiantec.cr",
                "ldfozamis@estudiantec.cr",
                "lorcacris13@estudiantec.cr",
                "machacon@itcr.ac.cr",
                "machobg08@estudiantec.cr",
                "mariolara.21@estudiantec.cr",
                "svega106@estudiantec.cr",
                "thecsarbeat@estudiantec.cr"
            };

            
            foreach (UserAPIModel user in personList) {
                if (!ignoreMailList.Contains(user.Email)){
                    var smtpClient = new SmtpClient("smtp.gmail.com")
                    {
                        Port = 587,
                        Credentials = new NetworkCredential("bibliotecmail@gmail.com", "pubrnylofjmuqmff"),
                        EnableSsl = true,
                    };
                    //email = HttpContext.Session.GetString("email");

                    message = "Se ha modificado el evento: " + Event.name;
                    try
                    {
                        smtpClient.Send("bibliotecmail@gmail.com", user.Email, "Modificación de evento", message);
                    }
                    catch
                    {
                        Debug.WriteLine("no existe el correo");
                    }
                    
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
