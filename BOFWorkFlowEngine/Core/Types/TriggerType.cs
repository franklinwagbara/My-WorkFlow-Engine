using BOFWorkFlowEngine.Core.Constants;

namespace BOFWorkFlowEngine.Core.Types
{
    public abstract class TriggerType
    {
        public virtual string Value { get; } = TRIGGER_TYPE.AUTO;
    }

    public class AutoTrigger: TriggerType
    {
        public override string Value => TRIGGER_TYPE.AUTO;
    }

    public class CommandTrigger : TriggerType
    {
        public override string Value => TRIGGER_TYPE.COMMAND;
    }

    public class TimeTrigger : TriggerType
    {
        public override string Value => TRIGGER_TYPE.TIMER;
    }
}
