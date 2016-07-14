using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.UI.WebControls;
using API.Entities;
using API.Models;

namespace API.Controllers
{
    public class BackgroundController : ApiController
    {
        [Authorize]
        [HttpGet]
        [Route("api/background/getbackground/{userid}")]
        public BackGroundModel GetBackground(string userID)
        {
            try
            {
                var bm = new BackGroundModel();
                bm.UserID = new Guid(userID);
                using (var context = new JustMySiteDB())
                {
                    var background = context.Background.FirstOrDefault(x => x.UserID == bm.UserID);
                    if (background != null)
                    {
                        bm.ID =  background.ID;
                        bm.UserID = background.UserID;
                        bm.ImageAdress = background.BackGroundAdress;
                    }
                }
                return bm;
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        [Authorize]
        [HttpPut]
        [Route("api/background/addbackground")]
        public HttpResponseMessage AddBackground(BackGroundModel backGroundModel)
        {
            try
            {
                using (var context = new JustMySiteDB())
                {
                    var background = new Background()
                    {
                        ID = Guid.NewGuid(),
                        BackGroundAdress = backGroundModel.ImageAdress,
                        UserID = backGroundModel.UserID
                    };
                    context.Background.Add(background);
                    context.SaveChanges();
                }
                return new HttpResponseMessage(HttpStatusCode.Created);
            }
            catch (Exception)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
                throw;
            }
           
        }

        [Authorize]
        [HttpPost]
        [Route("api/background/updatebackground")]
        public HttpResponseMessage UpdateBackground(BackGroundModel backGroundModel)
        {
            try
            {
                using (var context = new JustMySiteDB())
                {

                    var tobeupdated = context.Background.Find(backGroundModel.ID);

                    tobeupdated.BackGroundAdress = backGroundModel.ImageAdress;

                    context.Entry(tobeupdated).CurrentValues.SetValues(tobeupdated);
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
