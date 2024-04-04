using BOFWorkFlowEngine.Model;

namespace BOFWorkFlowEngine.Core.Interfaces
{
    public interface IWorkFlowScheme: ISchemeParser, ISerializeScheme
    {
        Scheme GetScheme();
        Scheme GetSchemeByValue(string scheme);
        void SetSchemeByCode(string schemeCode);
        void SetSchemeByValue(string scheme);
        string ISerializeScheme(Scheme scheme);
    }
}
