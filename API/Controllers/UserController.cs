using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using API.Entities;
using API.Models;
using Novacode;

namespace API.Controllers
{
    public class UserController : ApiController
    {
        [Authorize]
        [HttpGet]
        [Route("api/user/getall")]
        public List<UserModel> GetAll()
        {
            try
            {
                var list = new List<UserModel>();

                using (var context = new JustMySiteDB())
                {
                    foreach (var user in context.User)
                    {
                        var userToAdd = new UserModel()
                        {
                            ID = user.ID,
                            Username = user.Username
                        };
                        list.Add(userToAdd);
                    }
                }
                return list;
            }
            catch (Exception)
            {
                
                throw;
            }
          
        }

        [Authorize]
        [HttpPut]
        [Route("api/user/adduser")]
        public IHttpActionResult AddUser(LoginModel newUser)
        {
            try
            {
                using (var context = new JustMySiteDB())
                {
                    context.User.Add(new User()
                    {
                        ID = Guid.NewGuid(),
                        Username = newUser.Username,
                        Password = Helpers.PasswordStorage.CreateHash(newUser.Password)
                    });

                    context.SaveChanges();
                }
                return Ok();
            }
            catch (Exception)
            {

                throw;
            }

        }


    }
}
