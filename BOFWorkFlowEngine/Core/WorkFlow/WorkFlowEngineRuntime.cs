using BOFWorkFlowEngine.Core.Constants;
using BOFWorkFlowEngine.Core.Types;
using BOFWorkFlowEngine.Exceptions;
using BOFWorkFlowEngine.Model;

namespace BOFWorkFlowEngine.Core.WorkFlow
{
    public class WorkFlowEngineRuntime 
    {
        private List<Process> _processes;
        private List<WorkFlowScheme> _schemes;
        private List<Parameter> _parameters;
        public Process CurrentProcessInstance { get; internal set; } 

        public WorkFlowEngineRuntime()
        {
            _processes = new List<Process>();
            _schemes = new List<WorkFlowScheme>();
            _parameters = new List<Parameter>();
        }

        public Process CreateProcessInstance(Guid processId, string processName, string schemeCode)
        {
            WorkFlowScheme? scheme = _schemes?.FirstOrDefault(x => x.Scheme.Code.ToLower() == schemeCode.ToLower());
            if(scheme == null)
            {
                scheme = new WorkFlowScheme(schemeCode);
            }

            _schemes?.Add(scheme);
            var initialActivity = scheme.Scheme.GetInitialActivity();

            var newProcess = new Process(processId, processName, initialActivity, initialActivity.State, null, null, scheme.Scheme.Commands, scheme.Scheme.Activities, scheme.Scheme.Actors, scheme.Scheme.Transitions, scheme.Scheme.Parameters, scheme.Scheme);
            CurrentProcessInstance = newProcess;
            _processes.Add(newProcess);
            return newProcess;
        }

        public void ExcecuteCommand(Command command)
        {
            if (CurrentProcessInstance == null) throw new CurrentProcessInstanceNotSetException();

            //Todo: check if this actor has the permission to execute this command.

            //Get the current activity
            var currentActivity = CurrentProcessInstance.CurrentActivity;

            if(currentActivity == null) throw new Exception("Current Activity can not be null");

            //Get all transitions leaving this activity and that are of Command Trigger type
            var transition = CurrentProcessInstance.Transitions?.FirstOrDefault(x => x.FromActivityName.ToLower() == currentActivity.Name.ToLower() && x.Triggers.Any(x => x.Name.ToLower() == command.Name.ToLower() && x.Type.ToLower() == TRIGGER_TYPE.COMMAND.ToLower())) ?? throw new NotFoundException($"No transition was found for this command={command.Name}");

            if (CurrentProcessInstance.Activities == null || CurrentProcessInstance.Activities.Count == 0)
                throw new NotFoundException("List of activities is null, no activities exist to search from.");

            transition.ToActivity = CurrentProcessInstance.Activities.FirstOrDefault(x => x.Name.ToLower() == transition.ToActivityName.ToLower());

            if (transition.ToActivity == null) throw new NotFoundException("ToActivity cannot be null.");

            transition.FromActivity = CurrentProcessInstance.Activities.FirstOrDefault(x => x.Name.ToLower() == transition.FromActivityName.ToLower());

            if (transition.FromActivity == null) throw new NotFoundException("FromActivity cannot be null.");

            currentActivity = transition.ToActivity;
            currentActivity.ExecuteActions();
            CurrentProcessInstance.CurrentActivity = currentActivity;
        }

        public void SetProcesses(List<Process> processes)
        {
            _processes = processes; 
        }
        public void AddProcess(Process process)
        {
            _processes.Add(process);
        }
        public void RemoveProcess(Process process)
        {
            if(_processes == null) return;
            _processes.Remove(process);
        }
        public List<Process>? GetProcesses()
        {
            return _processes;
        }
        public Process? GetProcessInstance(string name)
        {
            return _processes?.FirstOrDefault(x => x.Name == name);
        }
        public void AddWorkFlowScheme(WorkFlowScheme scheme)
        {
            _schemes.Add(scheme);
        }
        public void AddWorkFlowScheme(string schemeCode)
        {
            _schemes.Add(new WorkFlowScheme(schemeCode));
        }
        public void RemoveWorkFlowScheme(string schemeCode)
        {
            if (_schemes == null) return;

            var scheme = _schemes.Find(x => x.Scheme.Code == schemeCode);

            if (scheme == null) return;

            _schemes.Remove(scheme);
        }
        public void SetParameters(List<Parameter> parameters)
        {
            _parameters = parameters;
        }
        public void AddParameter(Parameter parameter)
        {
            _parameters.Add(parameter);
        }
        public void RemoveParameter(Parameter parameter)
        {
            _parameters?.Remove(parameter);
        }
    }
}
