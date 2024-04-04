using BOFWorkFlowEngine.Core.Constants;
using BOFWorkFlowEngine.Core.Types;
using Newtonsoft.Json;

namespace BOFWorkFlowEngine.Model
{
    public class Trigger
    {
        public Guid Id { get; internal set; }
        [JsonProperty("nameRef")]
        public string Name { get; internal set; } = string.Empty;
        public string Type { get; internal set; } = TRIGGER_TYPE.COMMAND;
    }
}
