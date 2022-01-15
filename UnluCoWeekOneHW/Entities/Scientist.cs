using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UnluCoWeekOneHW.Entities
{
    public class Scientist
    {
        [Required]
        [Key]
        public int ScientistId { get; }
        public string ScientistName { get; set; }
        public string ScientistSecondName { get; set; }
        public string ScientistNationality { get; set; }
        public int Popularity { get; set; }
        public string ScientistEmail { get; set; }
        public string ScientistFieldOfStudy { get; set; }
        public string ScientistUniversity { get; set; }
        public bool isActive { get; set; } = true;

    }
}
