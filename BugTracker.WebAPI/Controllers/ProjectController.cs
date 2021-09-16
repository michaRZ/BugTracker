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

    public class ProjectController : ApiController
    {
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


        [HttpGet]
        public IHttpActionResult GetAllProjects()
        {
            ProjectService projectService = CreateProjectService();
            var projects = projectService.GetProjects();
            return Ok(projects);
        }


        [HttpGet]
        public IHttpActionResult GetActiveProjcts()
        {
            ProjectService projectService = CreateProjectService();
            var activeProjects = projectService.GetActiveProjects();
            return Ok(activeProjects);
        }


        [HttpGet]
        public IHttpActionResult GetInactiveProjects()
        {
            ProjectService projectService = CreateProjectService();
            var inactiveProjects = projectService.GetInactiveProjects();
            return Ok(inactiveProjects);
        }


        [HttpGet]
        public IHttpActionResult GetProjectById(int id)
        {
            ProjectService projectService = CreateProjectService();
            var project = projectService.GetProjectById(id);
            return Ok(project);
        }


        [HttpPut]
        public IHttpActionResult Put(ProjectEdit project)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateProjectService();

            if (!service.UpdateProject(project))
                return InternalServerError();

            return Ok("Project details updated!");
        }


        [HttpPut]
        public IHttpActionResult PutStatus(ProjectStatus project)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateProjectService();

            if (!service.UpdateProjectStatus(project))
                return InternalServerError();

            return Ok("Project status updated!");
        }


        [HttpDelete]
        public IHttpActionResult Delete(int id)
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
