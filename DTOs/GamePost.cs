using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace zadaniedodatkowe.DTOs
{
    public class GamePost
    {
        [Required]
        public string Name {get; set;}
        public DateTime? ReleaseDate {get; set;}
        [Required]
        public string Description {get; set;}
        [Required]
        public List<GameCompanyPost> Companies { get; set; }

    }
    
    public class GameCompanyPost
    {
        [Required]
        public int IdCompany {get; set;}
    }
}