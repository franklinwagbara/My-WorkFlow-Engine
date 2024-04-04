namespace BOFWorkFlowEngine.Model
{
    public class Command
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<ParameterRef>? InputParameters { get; set; }
    }
}
