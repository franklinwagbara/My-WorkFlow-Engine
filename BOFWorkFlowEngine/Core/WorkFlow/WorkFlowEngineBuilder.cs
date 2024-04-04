using BOFWorkFlowEngine.Core.Interfaces;
using BOFWorkFlowEngine.Exceptions;

namespace BOFWorkFlowEngine.Core.WorkFlow
{
    public class WorkFlowEngineBuilder : IWorkFlowEngineBuilder
    {
        private WorkFlowEngineRuntime _workFlowEngineRuntime;
        private string _schemeCode = string.Empty;

        public WorkFlowEngineBuilder()
        {
            _workFlowEngineRuntime = new WorkFlowEngineRuntime();
        }

        public WorkFlowEngineBuilder AddWorkFlowScheme(string schemeCode)
        {
            _schemeCode = schemeCode ?? throw new ArgumentNullException(nameof(schemeCode));
            return this;
        }

        public WorkFlowEngineRuntime Build()
        {
            _workFlowEngineRuntime.AddWorkFlowScheme(_schemeCode);
            return _workFlowEngineRuntime;
        }
    }
}
