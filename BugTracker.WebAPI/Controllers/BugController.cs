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

        [HttpGet]
        public IHttpActionResult Get()
        {
            var bugService = CreateBugService();
            var bugs = bugService.GetBugs();

            return Ok(bugs);
        }

    }
}
