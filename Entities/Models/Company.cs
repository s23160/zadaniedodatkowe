using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace zadaniedodatkowe.Entities.Models
{
    public class Company
    {
        public int IdCompany {get; set;}
        public string Name{get; set;}
        public string Location{get; set;}
        public DateTime CreationDate{get; set;}
        public virtual ICollection<GameCompany> GameCompanies {get; set;}

    }
}