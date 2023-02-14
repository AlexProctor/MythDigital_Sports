using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Myth_SportEvent.Core.Models
{
    public class Sport
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string SportId { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? SportsDisciplineId { get; set; }
        public string? SportsGenderId { get; set; }

        [ForeignKey("SportsGenderId")]
        public SportsGender? Gender { get; set; }

        [ForeignKey("SportsDisciplineId")]
        public SportsDiscipline? Discipline { get; set; }
    }
}
