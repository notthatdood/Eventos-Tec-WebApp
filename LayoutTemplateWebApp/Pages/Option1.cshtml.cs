using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LayoutTemplateWebApp.Model;
using LayoutTemplateWebApp.Data;

namespace LayoutTemplateWebApp.Pages
{
    public class Option1Model : PageModel

    {
        private readonly ApplicationDbContext _db; // Reemplaza "ApplicationDbContext" con el contexto de tu base de datos

        public Dictionary<DateTime, List<Event>> GroupedEvents { get; set; }

        public Option1Model(ApplicationDbContext db)
        {
            _db = db;
        }

        public void OnGet()
        {
            // Recuperar eventos de la base de datos
            var events = _db.Event.ToList();

            // Agrupar eventos por fecha
            GroupedEvents = events
                .GroupBy(e => e.date.Date)
                .ToDictionary(g => g.Key, g => g.ToList());
        }
    }
}