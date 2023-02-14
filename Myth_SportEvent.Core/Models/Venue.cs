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
    public class Venue
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string VenueId { get; set; } = null!;
        public string Name { get; set; } = null!;
    }
}
