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
    [RoutePrefix("api/Bug")]
    public class BugController : ApiController
    {
        private BugService CreateBugService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var bugService = new BugService(userId);

            return bugService;
        }

        [Route("")]
        [HttpPost]
        public IHttpActionResult PostBug(BugCreate model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var bugService = CreateBugService();

            if (!bugService.CreateBug(model))
                return InternalServerError();

            return Ok();
        }
        [Route("")]
        [HttpGet]
        public IHttpActionResult GetBugs()
        {
            var bugService = CreateBugService();
            var bugs = bugService.GetBugs();

            return Ok(bugs);
        }
        [Route("{id:int}")]
        [HttpGet]
        public IHttpActionResult GetById([FromUri]int id)
        {
            var bugService = CreateBugService();
            var bug = bugService.GetBugById(id);

            return Ok(bug);
        }

        [Route("proj/{id:int}")]
        [HttpGet]
        public IHttpActionResult GetProjectBugs([FromUri]int id)
        {
            var bugService = CreateBugService();
            var bug = bugService.GetBugsByProjectId(id);

            return Ok(bug);
        }
        [HttpGet]
        public IHttpActionResult GetbyDesc(string search)
        {
            var bugService = CreateBugService();
            var bug = bugService.GetBySearch(search);

            return Ok(bug);

        }
        [Route("")]
        [HttpPut]
        public IHttpActionResult EditBug(BugEdit model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var bugService = CreateBugService();

            if (!bugService.EditBug(model))
                return InternalServerError();

            return Ok();
        }

        [Route("stage")]
        [HttpPut]
        public IHttpActionResult RestageBug(BugStageEdit model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var bugService = CreateBugService();

            if (!bugService.UpdateBug(model))
                return InternalServerError();

            return Ok();
        }

        [Route("assign")]
        [HttpPut]
        public IHttpActionResult AssignBug(BugAssign model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var bugService = CreateBugService();

            if (!bugService.AssignBug(model))
                return InternalServerError();

            return Ok();

        }

        [Route("res")]
        [HttpPut] 
        public IHttpActionResult ResolveBug(BugResolve model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var bugService = CreateBugService();

            if (!bugService.BugResolve(model))
                return InternalServerError();

            return Ok();
        }

        [Route("archive/{id:int}")]
        [HttpPut]
        public IHttpActionResult ArchiveBug([FromUri]int id,[FromBody]BugArchive model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var bugService = CreateBugService();

            if (!bugService.ArchiveBug(model))
                return InternalServerError();

            return Ok();
        }

        [Route("")]
        [HttpDelete]
        public IHttpActionResult DeleteBug(int id)
        {
            var bugService = CreateBugService();

            if (!bugService.DeleteBug(id))
                return InternalServerError();

            return Ok();

        }
    }
}
