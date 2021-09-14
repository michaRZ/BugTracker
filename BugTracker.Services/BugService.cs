using BugTracker.Data;
using BugTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Services
{
    public class BugService
    {
        private readonly Guid _userId;

        public BugService(Guid userId)
        {
            _userId = userId;
        }
        //create a new bug
        public bool CreateBug(BugCreate model)
        {
            var entity = new Bug()
            {
                BugName = model.BugName,
                BugDescription = model.BugDescription,
                IdentifiedUtc = model.IdentifiedUtc,
                ProjectId = model.ProjectId,
                AssignedTo = model.AssignedTo,
                Priority = model.Priority
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Bugs.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        //get all unarchived bugs
        public IEnumerable<BugListItem> GetBugs()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Bugs.Where(e => e.ActiveProblem)
                    .Select
                    (
                        e=>new BugListItem
                        {
                            BugId=e.BugId,
                            BugName=e.BugName,
                            IdentifiedUtc=e.IdentifiedUtc,
                            ProjectId=e.ProjectId,
                            AssignedTo=e.AssignedTo,
                            Status=e.Status
                        }
                    );
                return query.ToArray();
            }
        }
    }
}
