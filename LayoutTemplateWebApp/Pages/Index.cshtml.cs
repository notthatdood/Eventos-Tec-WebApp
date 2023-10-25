using LayoutTemplateWebApp.Model;
using LayoutTemplateWebApp.Data;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace LayoutTemplateWebApp.Pages
{
    public class IndexModel : PageModel

    {
        [BindProperty(SupportsGet = true)]
        public string Email { get; set; }

        private readonly IHttpClientFactory _clientFactory;

        public UserAPIModel User { get; set; }

        public string RawJsonData { get; set; }


        public IndexModel(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }


        public async Task OnGetAsync(string email)
        {

            string id = HttpContext.Session.GetString("email");

            if (string.IsNullOrEmpty(email))
            {
                //check for session
                if (string.IsNullOrEmpty(id))
                {
                    Email = "Default or Anonymous User";
                    Response.Redirect("/ErrorPage");
                }
                // Now make the asynchronous call to the external API
                else if (HttpContext.Session.GetString("role") == "1616")
                {
                    Response.Redirect("/Estudiante/BienvenidaEstudiante");
                }
                else if (HttpContext.Session.GetString("role") == "1717")
                {
                    Response.Redirect("/Profesor/BienvenidaProfesor");
                }
                else
                {
                    Response.Redirect("/Organizador/BienvenidaOrganizador");
                }


            }
            else
            {
                Email = email;
                var client = _clientFactory.CreateClient();
                var response = await client.GetAsync("http://sistema-tec.somee.com/api/users/" + Email);

                if (response.IsSuccessStatusCode)
                {

                    // Attempt to deserialize the data
                    try
                    {
                        var data = await response.Content.ReadAsStringAsync();
                        RawJsonData = data; // Use a logging framework or another method to inspect 'data'
                        User = JsonSerializer.Deserialize<UserAPIModel>(data);

                        HttpContext.Session.SetString("SessionKey", Guid.NewGuid().ToString());
                        HttpContext.Session.SetString("id", User.Id.ToString());
                        HttpContext.Session.SetString("email", User.Email.ToString());
                        HttpContext.Session.SetString("name", User.FirstLastName.ToString());
                        HttpContext.Session.SetString("lastName", User.FirstLastName.ToString());
                        HttpContext.Session.SetString("lastName2", User.SecondLastName.ToString());


                        for (int i = 0; i < User.ApplicationRoles.Count; i++)
                        {
                            if (User.ApplicationRoles[i].ApplicationId == 8) //this is the id of the application Gestor de eventos in the database
                            {
                                if (User.ApplicationRoles[i].Id == 16)
                                {
                                    HttpContext.Session.SetString("role", "1616"); //Estudiante
                                    break;
                                }
                                else if (User.ApplicationRoles[i].Id == 17)
                                {
                                    HttpContext.Session.SetString("role", "1717"); //Profesor
                                }
                                else if (User.ApplicationRoles[i].Id == 19)
                                {
                                    HttpContext.Session.SetString("role", "1919"); //Organizador
                                }

                            }
                        }


                    }
                    catch (JsonException ex)
                    {
                        // Log or output the deserialization error
                        RawJsonData = $"Error deserializing data: {ex.Message}";
                    }

                }
                else
                {
                    // Log or output the unsuccessful status code
                    RawJsonData = $"Error: {response.StatusCode}";
                }

            }

            // Now make the asynchronous call to the external API
            if (HttpContext.Session.GetString("role") == "1616")
            {
                Response.Redirect("/Estudiante/BienvenidaEstudiante");
            }
            else if (HttpContext.Session.GetString("role") == "1717")
            {
                Response.Redirect("/Profesor/BienvenidaProfesor");
            }
            else
            {
                Response.Redirect("/Organizador/BienvenidaOrganizador");
            }

        }
    }
}