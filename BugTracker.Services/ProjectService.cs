using BugTracker.Data;
using BugTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Services
{
    public class ProjectService
    {
        public readonly Guid _createdBy;

        public ProjectService(Guid userId)
        {
            _createdBy = userId;
        }



        public bool CreateProject(ProjectCreate model)
        {
            var entity = new ProjectService()
            {
                ProjectName = model.ProjectName,
                StartDate = model.StartDate,
                DateEndProjected = model.DateEndProjected,
                CreatedUtc = DateTimeOffset.Now
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Projects.Add(entity);
                return ctx.SaveChangesAsync() == 1;
            }
        }


        // Get all projects
        public IEnumerable<ProjectListItem> GetProjects()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Projects
                    .Select(p => new ProjectListItem
                    {
                        ProjectId = p.ProjectId,
                        ProjectName = p.ProjectName,
                    });
            }
        }
    }
}
