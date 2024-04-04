using BOFWorkFlowEngine.Model;

namespace BOFWorkFlowEngine.Core.Interfaces
{
    public interface ISchemeParser
    {
        Scheme Parse(string scheme);
    }
}
