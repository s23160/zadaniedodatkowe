using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using zadaniedodatkowe.Entities;
using zadaniedodatkowe.Entities.Models;

namespace zadaniedodatkowe.Services
{
    public class DatabaseService : IDatabaseService
    {
        private readonly DatabaseContext _context;
        public DatabaseService(DatabaseContext context)
        {
            _context = context;
        }

        public async Task Create<T>(T entity) where T : class
        {
            await _context.Set<T>().AddAsync(entity);
        }

        public IQueryable<Company> GetCompanyById(int idCompany)
        {
            return _context.Companies.Where(e => e.IdCompany == idCompany);
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}