using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace Myth_SportEvent.Core.Models
{
    public class SportsOrganisation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string SportsOrganisationId { get; set; } = null!;

        [JsonIgnore]
        public ICollection<SportsEvent> SportsEvents { get; set; }  
    }
}
