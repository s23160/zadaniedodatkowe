using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using zadaniedodatkowe.Entities.Models;

namespace zadaniedodatkowe.Services
{
    public interface IDatabaseService
    {
        public IQueryable<Company> GetCompanyById(int idCompany);
        public Task Create<T>(T entity) where T : class;
        public Task SaveChanges();
    }
}