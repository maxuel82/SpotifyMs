using Newtonsoft.Json;

namespace SpotifyMs.Domain.Streaming.Aggregates
{
    public class BandaCosmo
    {
        [JsonProperty(PropertyName = "id")]
        public Guid Id { get; set; }
        [JsonProperty(PropertyName = "nome")]
        public String Nome { get; set; }
        [JsonProperty(PropertyName = "descricao")]
        public String Descricao { get; set; }
        [JsonProperty(PropertyName = "backdrop")]
        public String Backdrop { get; set; }

        [JsonProperty(PropertyName = "partitionKey")]
        public string PartitionKey = "banda-partition";

    }
}
