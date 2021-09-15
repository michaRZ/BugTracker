using BugTracker.Models;
using BugTracker.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BugTracker.WebAPI.Controllers
{
    [Authorize]
    public class PersonController : ApiController
    {
        
        private PersonService CreatePersonService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var personService = new PersonService(userId);
            return personService;
        }

        public IHttpActionResult Post(PersonCreate person)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreatePersonService();
            if (!service.CreatePerson(person))
                return InternalServerError();
            return Ok();
        }

        public IHttpActionResult Get()
        {
            PersonService personService = CreatePersonService();
            var people = personService.GetPeople();
            return Ok(people);
        }

        public IHttpActionResult Get(int id)
        {
            PersonService personService = CreatePersonService();
            var person = personService.GetPersonById(id);
            return Ok(person);
        }

        public IHttpActionResult Put(PersonEdit person)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreatePersonService();
            if (!service.UpdatePerson(person))
                return InternalServerError();
            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreatePersonService();
            if (!service.DeletePerson(id))
                return InternalServerError();
            return Ok();
        }
        
    }
}
