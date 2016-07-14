using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using MyWebPage.Helpers;
using MyWebPage.Models;
using Newtonsoft.Json;

namespace MyWebPage.Controllers
{
    public class BusinessController : Controller
    {
       
        public async Task<ActionResult> Index(UserModel user)
        {
            if (user != null)
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://justmysiteapi.azurewebsites.net/");
                //client.BaseAddress = new Uri("http://localhost:50050/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Helpers.CredentialHelper.Credential);


                //var s = $"api/employer/load";
                //var response = await client.PostAsJsonAsync(s,user);

                string id = user.ID.ToString();

                var jsonString = client.GetAsync($"api/employer/load/{id}").Result.Content.ReadAsStringAsync().Result;
                var toPresent = JsonConvert.DeserializeObject<PresentModel>(jsonString);
                toPresent.Employer = Helpers.SortListHelper.SortEmployerListDescending(toPresent.Employer);

                return View(toPresent);
            }
            return null;
        }
    }
}