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
                Priority = model.Priority,
                Status = Stage.New
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
                        e => new BugListItem
                        {
                            BugId = e.BugId,
                            BugName = e.BugName,
                            IdentifiedUtc = e.IdentifiedUtc,
                            ProjectId = e.ProjectId,
                            AssignedTo = e.AssignedTo,
                            Status = e.Status
                        }
                    );
                return query.ToArray();
            }
        }
        public IEnumerable<BugListItem> GetBugsByProjectId(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Bugs.Where(e => e.ProjectId == id && e.ActiveProblem).Select
                    (
                        e => new BugListItem
                        {
                            BugId = e.BugId,
                            BugName = e.BugName,
                            IdentifiedUtc = e.IdentifiedUtc,
                            ProjectId = e.ProjectId,
                            AssignedTo = e.AssignedTo,
                            Status = e.Status

                        }
                    );
                return query.ToArray();
            }
        }
        public BugDetail GetBugById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Bugs.Single(e => e.BugId == id && e.ActiveProblem);

                return 
                 new BugDetail 
                {
                    BugId=entity.BugId,
                    BugName=entity.BugName,
                    BugDescription=entity.BugDescription,
                    ProjectId=entity.ProjectId,
                    Status=entity.Status,
                    ActiveProblem=entity.ActiveProblem,
                    Priority=entity.Priority,
                    IdentifiedUtc=entity.IdentifiedUtc,
                    CreatedUTC=entity.CreatedUTC,
                    ModifiedUTC=entity.ModifiedUTC
                };
            }
        }
    }
}