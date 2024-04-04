namespace BOFWorkFlowEngine.Exceptions
{
    public class CurrentProcessInstanceNotSetException : Exception
    {
        public CurrentProcessInstanceNotSetException(string message = "Current Process Instance was not set") : base(message)
        {
        }
    }
}
