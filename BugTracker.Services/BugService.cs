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

        public bool CreateBug(BugCreate model)
        {
            var entity = new Bug()
            {

            };
        }
    }
}
