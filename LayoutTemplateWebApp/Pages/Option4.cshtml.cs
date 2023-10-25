using LayoutTemplateWebApp.Data;
using LayoutTemplateWebApp.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LayoutTemplateWebApp.Pages
{
    public class Option4Model : PageModel
    {
        private readonly ApplicationDbContext _db;

        public Dictionary<int, List<Facility>> GroupedFacilities { get; set; }

        public List<FacilityType> Ftypes { get; set; }

        public Option4Model(ApplicationDbContext db)
        {
            _db = db;
        }

        public void OnGet()
        {
            // Recuperar instalaciones de la base de datos
            var facilities = _db.Facility.ToList();
            var types = _db.FacilityType.ToList();

            // Agrupar instalaciones por idBuildingType
           GroupedFacilities = facilities
                .GroupBy(f => f.idBuildingType)
               .ToDictionary(g => g.Key, g => g.ToList());

            Ftypes = types;

        }
    }
}