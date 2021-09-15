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
                Status = Stage.New,
                CreatedUTC = DateTimeOffset.Now
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
                     BugId = entity.BugId,
                     BugName = entity.BugName,
                     BugDescription = entity.BugDescription,
                     ProjectId = entity.ProjectId,
                     Status = entity.Status,
                     ActiveProblem = entity.ActiveProblem,
                     Priority = entity.Priority,
                     IdentifiedUtc = entity.IdentifiedUtc,
                     CreatedUTC = entity.CreatedUTC,
                     ModifiedUTC = entity.ModifiedUTC
                 };
            }
        }
        public bool EditBug(BugEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                ctx.Bugs.Single(e => e.BugId == model.BugId);

                entity.BugName = model.BugName;
                entity.BugDescription = model.BugDescription;
                entity.IdentifiedUtc = model.IdentifiedUtc;
                entity.ProjectId = model.ProjectId;
                entity.AssignedTo = model.AssignedTo;
                entity.Status = model.Status;
                entity.Priority = model.Priority;
                entity.ExpectedResolutionUTC = model.ExpectedResolutionUTC;
                entity.ActualResolutionUTC = model.ActualResolutionUTC;
                entity.ResolutionSummary = model.ResolutionSummary;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool RestageBug(BugStageEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Bugs.Single(e => e.BugId == model.BugId);

                entity.Status = model.Status;
                entity.ActiveProblem = model.ActiveProblem;
                entity.Priority = model.Priority;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool AssignBug(BugAssign model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Bugs.Single(e => e.BugId == model.BugId);

                entity.AssignedTo = model.AssignedTo;
                entity.Status = Stage.Assign;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool BugResolve(BugResolve model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Bugs.Single(e => e.BugId == model.BugId);

                entity.BugDescription = model.BugDescription;
                entity.Priority = Priority.None;
                entity.Status = Stage.Closed;
                entity.ActiveProblem = false;
                entity.ResolutionSummary = model.ResolutionSummary;
                entity.ActualResolutionUTC = DateTimeOffset.Now;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool ArchiveBug(BugArchive model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                ctx.Bugs.Single(e => e.BugId == model.BugId);

                entity.ActiveProblem = model.ActiveProblem;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteBug(int BugId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Bugs.Single(e => e.BugId == BugId);

                ctx.Bugs.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}