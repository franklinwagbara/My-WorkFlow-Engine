namespace BOFWorkFlowEngine.Model
{
    public class ParameterRef
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool IsRequired { get; set; } = false;
    }
}
