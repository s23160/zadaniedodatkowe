using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using zadaniedodatkowe.Entities;

namespace zadaniedodatkowe.Services
{
    public class DatabaseService : IDatabaseService
    {
        private readonly DatabaseContext _context;
        public DatabaseService(DatabaseContext context)
        {
            _context = context;
        }
    }
}