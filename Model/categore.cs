using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebApplication1.Model
{
    public class categore
    {
        [Key]
        public int ID { get; set; }
        public string  Name { get; set; }

        [JsonIgnore]
        public virtual ICollection<product> products { get; set; }

    }
}
