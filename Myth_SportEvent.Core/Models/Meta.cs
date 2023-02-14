using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Myth_SportEvent.Core.Models
{
    public class Meta
    {
        [Key]
        public int MetaId { get; set; }
        [JsonProperty("update_id")]
        public long UpdateId { get; set; }
        [JsonProperty("update_idSpecified")]
        public bool UpdateIdSpecified { get; set; }
        [JsonProperty("update_action")]
        public string UpdateAction { get; set; }
        [JsonProperty("update_date")]
        public DateTime UpdateDate { get; set; }
        [JsonProperty("language")]
        public string Language { get; set; }
    }
}
