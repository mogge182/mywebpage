using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using API.Entities;
using API.Helpers;
using API.Models;

namespace API.Controllers
{
    
    public class LoginController : ApiController
    {

        private JustMySiteDB context = new JustMySiteDB();

        [Authorize]
        [HttpGet]
        [Route("api/login/getaccesslevel")]
        public UserModel GetAccessLevel()
        {
            try
            {
                var username = ClaimsPrincipal.Current.Identity.Name;
                var user = context.User.FirstOrDefault(x => x.Username == username);
                if (user != null)
                    return new UserModel
                    {
                        ID = user.ID,
                        Username = user.Username
                    };
                return new UserModel();
            }
            catch (Exception)
            {
                
                throw;
            }
           
           
        }

        
        [HttpGet]
        [Route("api/login/createuser")]
        public IHttpActionResult CreateUser(LoginModel newuser)
        {
            try
            {
                using (var context = new JustMySiteDB())
                {
                    var newUser = new User()
                    {
                        ID = Guid.NewGuid(),
                        Username = newuser.Username,
                        Password = PasswordStorage.CreateHash(newuser.Password)
                    };
                    context.User.Add(newUser);
                    context.SaveChanges();
                }
                return null;
            }
            catch (Exception)
            {
                
                throw;
            }
        
        }

    }
}
