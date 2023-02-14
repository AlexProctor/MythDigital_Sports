using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Myth_SportEvent.Core.Models
{
    public class SportsGender
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string SportsGenderId { get; set; } = null!;
    }
}
