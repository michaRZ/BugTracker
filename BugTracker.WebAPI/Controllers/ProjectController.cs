using BugTracker.Models;
using BugTracker.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace BugTracker.WebAPI.Controllers
{
    [Authorize]
    [RoutePrefix("api/Project")]
    public class ProjectController : ApiController
    {
        [Route("")]
        [HttpPost]
        public IHttpActionResult Post(ProjectCreate project)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateProjectService();

            if (!service.CreateProject(project))
                return InternalServerError();

            return Ok("You created a new project!");
        }

        [Route("")]
        [HttpGet]
        public IHttpActionResult GetAllProjects()
        {
            ProjectService projectService = CreateProjectService();
            var projects = projectService.GetProjects();
            return Ok(projects);
        }

        [Route("")]
        [HttpGet]
        public IHttpActionResult GetProjectsByStatus([FromUri] bool status)
        {
            ProjectService projectService = CreateProjectService();
            var projects = projectService.GetProjectsByStatus(status);
            return Ok(projects);
        }


        [Route("{id:int}")]
        [HttpGet]
        public IHttpActionResult GetProjectById([FromUri] int id)
        {
            ProjectService projectService = CreateProjectService();
            var project = projectService.GetProjectById(id);
            return Ok(project);
        }

        [Route("")]
        [HttpPut]
        public IHttpActionResult Put(ProjectEdit model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            /*if (model.IsActive != true)
                return StatusCode(HttpStatusCode.MethodNotAllowed);*/

            var service = CreateProjectService();

            if (!service.EditProject(model))
                return InternalServerError();

            return Ok("Project details updated!");
        }

        [Route("status")]
        [HttpPut]
        public IHttpActionResult PutStatus(ProjectStatus model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateProjectService();

            if (!service.UpdateProjectStatus(model))
                return InternalServerError();

            return Ok("Project status updated!");
        }

        [Route("{id:int}")]
        [HttpDelete]
        public IHttpActionResult Delete([FromUri] int id)
        {
            var service = CreateProjectService();

            if (!service.DeleteProject(id))
                return InternalServerError();

            return Ok("Project deleted!");
        }


        private ProjectService CreateProjectService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var projectService = new ProjectService(userId);
            return projectService;
        }


    }
}
