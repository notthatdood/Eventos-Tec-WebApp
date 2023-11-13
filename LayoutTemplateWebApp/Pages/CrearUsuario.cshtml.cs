using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;

namespace LayoutTemplateWebApp.Pages
{
    public class CrearUsuarioModel : PageModel
    {
        public string email { get; set; }
        public string password { get; set; }
        public string name { get; set; }
        public string firstLastName { get; set; }
        public string secondLastName { get; set; }
        public string id { get; set; }
        public string degreeId { get; set; }
        public string studentId { get; set; }
        public string isExemptFromPrintingCosts { get; set; }


        public bool showErrorMsg = false;
        public bool showIncorrect = false;
        public bool showIdError = false;
        public bool emailError = false;
        public async Task OnGet()
        {
            var url = "http://www.sistema-tec.somee.com/api/degrees";
            using var client = new HttpClient();

            var response = await client.GetAsync(url);
            var result = await response.Content.ReadAsStringAsync();

            Debug.WriteLine(result);
            Debug.WriteLine("get create student");
        }

        public async Task<IActionResult> OnPostStudent(string email, string password, string name, string firstLastName, string secondLastName, string id, string studentId, string degreeId)
        {

            Debug.WriteLine("on post call debuga " + email + " // " + password + " // " + name + " // " + firstLastName + " // " + secondLastName + " // " + id
                            + " // " + studentId + " // " + degreeId);
            if (email == null || password == null || name == null || firstLastName == null || secondLastName == null || id == null || studentId == null )
            {
                showErrorMsg = true;
                Debug.WriteLine("campo nulo");
                return null;
            }
            else if (!email.Contains("@estudiantec.cr"))
            {
                Debug.WriteLine("correo no es estudiantec");
                emailError = true;
                return null;
            }

            else if (!Regex.IsMatch(id, @"^[0-9]") || !Regex.IsMatch(studentId, @"^[0-9]"))
            {
                Debug.WriteLine("No eran n�meros");
                showIdError = true;
                return null;
            }
            else if (int.Parse(id) >= 2147483647 || int.Parse(studentId) >= 2147483647)
            {
                Debug.WriteLine("era mayor");
                showIdError = true;
                return null;
            }

            var json = JsonConvert.SerializeObject(new
            {
                email = email,
                password = password,
                name = name,
                firstLastName = firstLastName,
                secondLastName = secondLastName,
                id = id,
                degreeId = "2",
                studentId = studentId,
                isExemptFromPrintingCosts = isExemptFromPrintingCosts,
                isProfessor = false
            });
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var url = "http://www.sistema-tec.somee.com/api/users/insert";
            using var client = new HttpClient();

            var response = await client.PostAsync(url, data);
            var result = await response.Content.ReadAsStringAsync();

            Debug.WriteLine(result);

            string CurrentPageUrl = $"{Request.Scheme}://{Request.Host}";
            Debug.WriteLine(CurrentPageUrl);
            return Redirect(CurrentPageUrl + "/" + email);

        }
    }
}