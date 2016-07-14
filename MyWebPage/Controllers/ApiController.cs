using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using MyWebPage.Helpers;
using MyWebPage.Models;
using Newtonsoft.Json;

namespace MyWebPage.Controllers
{
    public class ApiController : Controller
    {
       
        public async Task<ActionResult> AddUser()
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://justmysiteapi.azurewebsites.net/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var user = new LoginModel() { Password = "222222", Username = "111111" };


                var response = await client.PostAsJsonAsync("api/login/createuser", user);

                return null;
            }
            catch (Exception)
            {
                
                throw;
            }
          

        }






    }
}
