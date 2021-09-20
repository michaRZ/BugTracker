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
        private readonly Guid _userId;

        public ProjectService(Guid userId)
        {
            _userId = userId;
        }


        // Create a project
        public bool CreateProject(ProjectCreate model)
        {
            var entity = new Project()
            {
                ProjectName = model.ProjectName,
                StartDate = model.StartDate,
                DateEndProjected = model.DateEndProjected
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Projects.Add(entity);
                return ctx.SaveChanges() == 1;
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
                        IsActive = p.IsActive,
                        StartDate = p.StartDate,
                        DateEndProjected = p.DateEndProjected,
                        DateEndActual = p.DateEndActual
                    });
                return query.ToArray();
            }
        }


        // Get project by IsActive status
        public IEnumerable<ProjectListItem> GetProjectsByStatus(bool status)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx
                    .Projects
                    .Where(p => p.IsActive == status)
                    .Select(p => new ProjectListItem
                    {
                        ProjectId = p.ProjectId,
                        ProjectName = p.ProjectName,
                        StartDate = p.StartDate,
                        DateEndProjected = p.DateEndProjected,
                        DateEndActual = p.DateEndActual
                    });

                return query.ToArray();
            }
        }


        // Get project by Id
        public ProjectDetail GetProjectById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Projects
                    .Single(p => p.ProjectId == id);
                return
                    new ProjectDetail
                    {
                        ProjectId = entity.ProjectId,
                        ProjectName = entity.ProjectName,
                        IsActive = entity.IsActive,
                        StartDate = entity.StartDate,
                        DateEndProjected = entity.DateEndProjected,
                        DateEndActual = entity.DateEndActual,
                        ModifiedUtc = entity.ModifiedUtc
                    };
            }
        }


        // Update a Project (not incl. active status or actual end date)
        public bool EditProject(ProjectEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Projects
                    .Single(p => p.ProjectId == model.ProjectId /*&& p.IsActive == true*/);

                entity.ProjectName = model.ProjectName;
                entity.StartDate = model.StartDate;
                entity.DateEndProjected = model.DateEndProjected;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }


        // Update project active status and actual end date - SOFT DELETE
        public bool UpdateProjectStatus(ProjectStatus model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Projects
                    .Single(p => p.ProjectId == model.ProjectId);

                entity.IsActive = model.IsActive;
                entity.DateEndActual = model.DateEndActual;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }


        // Delete project   // ideally only accessible by user with admin priveleges
        public bool DeleteProject(int projectId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Projects
                    .Single(p => p.ProjectId == projectId /*&& _userId == Admin Role*/);
                ctx.Projects.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }

    }
}
