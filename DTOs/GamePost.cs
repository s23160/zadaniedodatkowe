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
    }
}