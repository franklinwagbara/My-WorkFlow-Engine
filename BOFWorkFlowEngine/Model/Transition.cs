using Newtonsoft.Json;

namespace BOFWorkFlowEngine.Model
{
    public class Transition
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Classifier { get; set; } = string.Empty;
        [JsonProperty("From")]
        public string FromActivityName { get; internal set; } = string.Empty;
        public Activity? FromActivity { get; internal set; }
        [JsonProperty("To")]
        public string ToActivityName { get; internal set; } = string.Empty;
        public Activity? ToActivity { get; internal set; }
        [JsonProperty("restrictions")]
        public List<Restriction>? Restrictions { get; internal set; }
        [JsonProperty("triggers")]
        public List<Trigger>? Triggers { get; internal set; }
        [JsonProperty("conditions")]
        public List<Condition>? Conditions { get; internal set; }
    }
}
