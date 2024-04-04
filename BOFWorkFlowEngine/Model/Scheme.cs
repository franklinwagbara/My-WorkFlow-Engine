using Newtonsoft.Json;

namespace BOFWorkFlowEngine.Model
{
    public class Scheme
    {
        [JsonProperty("code")]
        public string Code { get; set; } = string.Empty;
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("commands")]
        public List<Command>? Commands { get; internal set; }
        [JsonProperty("activities")]
        public List<Activity>? Activities { get; internal set; }
        [JsonProperty("transitions")]
        public List<Transition>? Transitions { get; internal set; }
        [JsonProperty("actors")]
        public List<Actor>? Actors { get; internal set; }
        [JsonProperty("parameters")]
        public List<Parameter>? Parameters { get; internal set; }
        [JsonProperty("comments")]
        public List<Comment>? Comments { get; internal set; }

        public Activity? GetInitialActivity()
        {
            return Activities?.FirstOrDefault(x => x.IsInitial == true);
        }
    }
}
