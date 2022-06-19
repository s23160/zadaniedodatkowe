using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace zadaniedodatkowe.Entities.Models
{
    public class Game
    {
        public int IdGame {get; set;}
        public string Name {get; set;}
        public DateTime? ReleaseDate {get; set;}
        public string Description {get; set;}
        public virtual ICollection<GameCompany> GameCompanies {get; set;}

        
    }
}