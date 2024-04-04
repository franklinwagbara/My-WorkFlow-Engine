namespace BOFWorkFlowEngine.Model
{
    public class Comment
    {
        public Guid Id { get; internal set; }
        public string Value { get; internal set; } = string.Empty;
    }
}