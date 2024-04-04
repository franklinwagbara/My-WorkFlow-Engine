using Newtonsoft.Json;

namespace BOFWorkFlowEngine.Model
{
    public class Activity
    {
        public Guid Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; internal set; } = string.Empty;
        [JsonProperty("isInitial")]
        public bool IsInitial { get; internal set; }
        [JsonProperty("isFinal")]
        public bool IsFinal { get; internal set; }
        [JsonProperty("state")]
        public string? StateName { get; internal set; }
        public State? State { get; internal set; }
        [JsonProperty("actions")]
        public List<Action>? Actions { get; internal set; }

        public void ExecuteActions()
        {
            Console.WriteLine("Executing Actions");
        }
    }
}
