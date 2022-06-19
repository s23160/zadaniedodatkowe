using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace zadaniedodatkowe.Entities.Models
{
    public class GameCompany
    {
        public int IdGame {get; set;}
        public int IdCompany {get; set;}
        public virtual Game Game {get; set;}
        public virtual Company Company {get; set;}

    }
}