using BugTracker.Data;
using BugTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Services
{
    public class PersonService
    {
        private readonly Guid _userId;
        public PersonService(Guid userId)
        {
            _userId = userId;
        }
        
        public bool CreatePerson(PersonCreate model)
        {
            var entity =
                new Person()
                {
                    Name = model.Name,
                    Email = model.Email,
                    Role = model.Role
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.People.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<PersonListItem> GetPeople()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx.People
                    //.Where 
                    .Select(e => new PersonListItem
                    {
                        PersonId = e.PersonId,
                        Name = e.Name
                    }
                    );
                return query.ToArray();
            }
        }

        public PersonDetail GetPersonById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .People
                    .Single(e => e.PersonId == id);
                return
                    new PersonDetail
                    {
                    PersonId = entity.PersonId,
                    Name = entity.Name,
                    Email = entity.Email,
                    Role = entity.Role,
                    IsActive = entity.IsActive
                    };
            }
        }
        public bool UpdatePerson(PersonEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .People
                    .Single(e => e.PersonId == model.PersonId);
                entity.Name = model.Name;
                entity.Email = model.Email;
                entity.Role = model.Role;
                return ctx.SaveChanges() == 1;

            }
        }

        public bool DeletePerson(int personId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = 
                    ctx
                        .People
                        .Single(e => e.PersonId == personId);
                ctx.People.Remove(entity);
                return ctx.SaveChanges() == 1;

            }
        }
    }
}
