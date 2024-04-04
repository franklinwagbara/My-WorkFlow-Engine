using BOFWorkFlowEngine.Core.WorkFlow;

namespace BOFWorkFlowEngine.Core.Interfaces
{
    internal interface IWorkFlowEngineBuilder
    {
        WorkFlowEngineRuntime Build();
    }
}
