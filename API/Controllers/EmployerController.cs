using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web.Http;
using API.Entities;
using API.Models;

namespace API.Controllers
{
    public class EmployerController : ApiController
    {
        [Authorize]
        [HttpGet]
        [Route("api/employer/load/{id}")]
        public PresentModel EmployerSite(string ID)
        {
            var userID = new Guid(ID);
            try
            {
                var present = new PresentModel();
                var list = new List<EmployerModel>();
                using (var context = new JustMySiteDB())
                {
                    var background = context.Background.FirstOrDefault(x => x.UserID == userID);
                    var user = context.User.FirstOrDefault(x => x.ID == userID);

                    if (background != null) present.Background = background.BackGroundAdress;
                    if (user != null) present.Username = user.Username;
                    if (user != null) Helpers.SendMailHelper.SendMail(user.Username);

                    foreach (var employer in context.Employer)
                    {
                        var employerToList = new EmployerModel()
                        {
                            ID = employer.ID,
                            EmployerName = employer.Name,
                            Description = employer.Description,
                            StartDate = employer.StartDate.Value,
                            EndDate = employer.EndDate.Value,
                            PictureUrl = employer.PictureUrl
                        };
                       list.Add(employerToList);
                    }
                    present.Employer = list;
                }
                return present;
            }
            catch (Exception exception)
            {
                exception.ToString();
                throw;
            }
        }
        [Authorize]
        [HttpGet]
        [Route("api/employer/getall")]
        public List<EmployerModel> GetAll()
        {
            try
            {
                var employers = new List<EmployerModel>();
                using (var context = new JustMySiteDB())
                {
                    foreach (var employer in context.Employer)
                    {
                        var employerToAdd = new EmployerModel()
                        {
                            ID = employer.ID,
                            EmployerName = employer.Name,
                            Description = employer.Description,
                            StartDate = (DateTime)employer.StartDate,
                            EndDate = (DateTime)employer.EndDate,
                            PictureUrl = employer.PictureUrl
                        };


                        employers.Add(employerToAdd);
                    }
                }
                return employers;
            }
            catch (Exception)
            {
                
                throw;
            }
           
           
        }
        [Authorize]
        [HttpPost]
        [Route("api/employer/add")]
        public IHttpActionResult AddEmployer(EmployerModel employer)
        {
            try
            {
                using (var context = new JustMySiteDB())
                {
                    var newEmployer = new Employer()
                    {
                        ID = Guid.NewGuid(),
                        Name = employer.EmployerName,
                        Description = employer.Description,
                        StartDate = employer.StartDate,
                        EndDate = employer.EndDate,
                        PictureUrl = employer.PictureUrl
                    };

                    context.Employer.Add(newEmployer);
                    context.SaveChanges();
                }
                return Ok();
            }
            catch (Exception)
            {
                
                throw;
            }
           
        }

        [Authorize]
        [HttpPost]
        [Route("api/employer/delete")]
        public IHttpActionResult DeleteEmployer(EmployerModel employer)
        {
            try
            {
                using (var context = new JustMySiteDB())
                {

                    context.Employer.Remove(context.Employer.FirstOrDefault(x => x.ID == employer.ID));
                    

                    
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
