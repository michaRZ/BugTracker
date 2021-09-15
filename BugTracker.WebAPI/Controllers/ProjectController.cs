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
        public async Task<IHttpActionResult> Post(ProjectCreate project)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateProjectService();

            if (!service.CreateProject(project))
                return InternalServerError();

            return Ok("You created a new project!");
        }


        [HttpGet]
        public async Task<IHttpActionResult> GetAllProjects()
        {
            ProjectService projectService = CreateProjectService();
            var projects = projectService.GetProjects();
            return Ok(projects);
        }


        private ProjectService CreateProjectService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var projectService = new ProjectService(userId);
            return projectService;
        }


    }
}
