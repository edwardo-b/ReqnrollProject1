using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReqnrollProject1.API.Models
{
    public partial class Pet
    {
        public Pet(long id, string name, string status)
        {
            Id = id;
            Name = name;
            Status = status;
        }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("photoUrls")]
        public object[]? PhotoUrls { get; set; }

        [JsonProperty("tags")]
        public Tag[]? Tags { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }
    }

    public partial class Tag
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }
    }
}
