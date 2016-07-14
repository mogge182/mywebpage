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
    public class StartController : Controller
    {
        // GET: Start
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> GetAccessLevel(LoginModel login)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://justmysiteapi.azurewebsites.net/");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            CredentialHelper.Credential = Convert.ToBase64String(Encoding.UTF8.GetBytes(login.Username + ":" + login.Password));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Helpers.CredentialHelper.Credential);


            var response = await client.GetAsync("api/login/getaccesslevel");

            if (response.IsSuccessStatusCode)
            {
                var jsonString = client.GetAsync("api/login/getaccesslevel").Result.Content.ReadAsStringAsync().Result;
                var user = JsonConvert.DeserializeObject<UserModel>(jsonString);

                if (user != null)
                {
                    return RedirectToAction("Index", "Business", user);
                }
                else
                {
                    return new EmptyResult();
                }
            }
            else
            {
                return RedirectToAction("Index", "Start");
            }
            return null;
        }
    }
}