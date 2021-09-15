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
    public class BugController : ApiController
    {
        private BugService CreateBugService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var bugService = new BugService(userId);

            return bugService;
        }

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

        [HttpGet]
        public IHttpActionResult GetBugs()
        {
            var bugService = CreateBugService();
            var bugs = bugService.GetBugs();

            return Ok(bugs);
        }

        [HttpGet]
        public IHttpActionResult GetById(int id)
        {
            var bugService = CreateBugService();
            var bug = bugService.GetBugById(id);

            return Ok(bug);
        }

        [HttpGet]
        public IHttpActionResult GetProjectBugs(int id)
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
        [HttpPut]
        public IHttpActionResult ArchiveBug(BugArchive model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var bugService = CreateBugService();

            if (!bugService.ArchiveBug(model))
                return InternalServerError();

            return Ok();
        }

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
