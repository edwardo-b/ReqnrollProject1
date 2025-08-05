using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ApiTest.Resources.Model
{
    
    public class BinaryFile
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("fileName")]
        public string FileName { get; set; } = string.Empty;

        [JsonProperty("filePath")]
        public string FilePath { get; set; } = string.Empty;

        [JsonProperty("repository")]
        public string Repository { get; set; } = string.Empty;

        [JsonProperty("addedBy")]
        public string AddedBy { get; set; } = string.Empty;

        [JsonProperty("addedDate")]
        public DateTime AddedDate { get; set; }

        [JsonProperty("modifiedBy")]
        public string ModifiedBy { get; set; } = string.Empty;

        [JsonProperty("modifiedDate")]
        public DateTime ModifiedDate { get; set; }
    }
    public class HealthCheckResponse
    {
        [JsonProperty("status")]
        public string Status { get; set; } = string.Empty;

        [JsonProperty("results")]
        public Dictionary<string, HealthCheckResult> Results { get; set; } = new();
    }
    public class HealthCheckResult
    {
        [JsonProperty("status")]
        public string Status { get; set; } = string.Empty;

        [JsonProperty("description")]
        public string Description { get; set; } = string.Empty;

        [JsonProperty("error")]
        public string? Error { get; set; }

        [JsonProperty("data")]
        public Dictionary<string, object> Data { get; set; } = new();
    }
}
