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

    }
}
