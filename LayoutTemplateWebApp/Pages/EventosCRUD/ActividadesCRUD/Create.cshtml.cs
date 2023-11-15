using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using LayoutTemplateWebApp.Data;
using LayoutTemplateWebApp.Model;

namespace LayoutTemplateWebApp.Pages.EventosCRUD.ActividadesCRUD
{
    public class CreateModel : PageModel
    {
        private readonly LayoutTemplateWebApp.Data.ApplicationDbContext _context;

        public CreateModel(LayoutTemplateWebApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }


        [BindProperty]
        public Activity Activity { get; set; } = default!;
        public int EventId { get; set; }

        public IActionResult OnGet(int id)
        {
            // Lógica para cargar la página y establecer EventId
            EventId = id;
            return Page();
        }
        /*
        public async Task<IActionResult> OnGetAsync(int? eventId)
        {
            if (eventId == null)
            {
                return NotFound();
            }

            EventId = eventId.Value;

            // Aquí puedes cargar cualquier otro dato que necesites antes de mostrar el formulario

            return Page();
        }
        */

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            try
            {

                /* Verificar ModelState
                if (!ModelState.IsValid)
                {
                    Console.WriteLine("ModelState no es válido. Errores:");

                    foreach (var modelStateKey in ModelState.Keys)
                    {
                        var modelStateVal = ModelState[modelStateKey];
                        foreach (var error in modelStateVal.Errors)
                        {
                            Console.WriteLine($"ModelState Error - Key: {modelStateKey}, Error: {error.ErrorMessage}");
                        }
                    }

                    return Page();
                }
                */


                // Verificar _context.Activity
                if (_context.Activity == null)
                {
                    Console.WriteLine("_context.Activity es nulo.");
                    return Page();
                }

                // Verificar si Activity es nulo
                if (Activity == null)
                {
                    Console.WriteLine("Activity es nulo.");
                    return Page();
                }

                // Asignar la propiedad de navegación Event utilizando el EventId
                Activity.Event = _context.Event.FirstOrDefault(e => e.idEvent == EventId);
                _context.Activity.Add(Activity);
                // Imprimir datos en la consola antes de guardar
                Console.WriteLine("Datos a agregar:");
                Console.WriteLine($"Nombre: {Activity.name}");
                Console.WriteLine($"Descripción: {Activity.description}");
                Console.WriteLine($"Capacidad: {Activity.capacity}");
                Console.WriteLine($"Evento: {Activity.idEvent}");
                Console.WriteLine($"Evento: {Activity.Event?.name}"); // Acceder al nombre del evento

                await _context.SaveChangesAsync();

                return RedirectToPage("../Index");
            }
            catch (Exception ex)
            {
                // Imprimir la excepción en la consola
                Console.WriteLine($"Error al guardar en la base de datos: {ex.Message}");
                throw; // Puedes decidir manejar la excepción de otra manera si lo prefieres
            }
        }

    }
}
