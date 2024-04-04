using Newtonsoft.Json;

namespace BOFWorkFlowEngine.Model
{
    public class Actor
    {
        public Guid Id { get; internal set; }
        [JsonProperty("name")]
        public string Name { get; internal set; } = string.Empty;
        [JsonProperty("value")]
        public string Value { get; internal set; } = string.Empty;
    }
}
