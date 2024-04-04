namespace BOFWorkFlowEngine.Model
{
    public class Process
    {
        public Guid Id { get; internal set; }
        public string Name { get; internal set; }
        public Activity? CurrentActivity { get; internal set; }
        public string? CurrentActivityName => CurrentActivity?.Name;
        public State? CurrentState { get; internal set; }
        public string? CurrentStateName => CurrentState?.Name;
        public Activity? ExecutedActivity { get; internal set; }
        public State? ExecutedActivityState { get; internal set; }
        public List<Command>? Commands { get; internal set; }
        public List<Activity>? Activities { get; internal set; }
        public List<Actor>? Actors { get; internal set; }
        public List<Transition>? Transitions { get; internal set; }
        public List<Parameter>? Parameters { get; internal set; }
        public Scheme? ProcessScheme { get; internal set; }

        public Process(Guid id, string name, Activity? InitialActivity, State? InitialState, Activity? executedActivity, State? executedActivityState, List<Command>? commands, List<Activity>? activities, List<Actor>? actors, List<Transition>? transitions, List<Parameter>? parameters, Scheme? processScheme)
        {
            Id = id;
            Name = name;
            CurrentActivity = InitialActivity;
            CurrentState = InitialState;
            ExecutedActivity = executedActivity;
            ExecutedActivityState = executedActivityState;
            Commands = commands;
            Activities = activities;
            Actors = actors;
            Transitions = transitions;
            Parameters = parameters;
            ProcessScheme = processScheme;
        }

        public Activity? FindActivity(string ActivityName)
        {
            return Activities?.FirstOrDefault(x => x.Name == ActivityName);
        }
    }
}
