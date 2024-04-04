namespace BOFWorkFlowEngine.Model
{
    public class Parameter
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public string? Purpose { get; set; }
    }
}
