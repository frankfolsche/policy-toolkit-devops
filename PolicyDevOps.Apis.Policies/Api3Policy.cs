using Azure.ApiManagement.PolicyToolkit.Authoring;
using Azure.ApiManagement.PolicyToolkit.Authoring.Expressions;

namespace PolicyDevOps.Apis.Policies;

[Document]
public class Api3Policy : IDocument
{
    public void Inbound(IInboundContext context)
    {
        context.Base();
        context.SetVariable("backendUrl", "{{api2BackEndUrl-{environment}}}");
        context.SetHeader("X-Hello", "Api3");

        context.SetBackendService(new SetBackendServiceConfig
        {
            BaseUrl = "{{api2BackEndUrl}}"
        });
    }
}