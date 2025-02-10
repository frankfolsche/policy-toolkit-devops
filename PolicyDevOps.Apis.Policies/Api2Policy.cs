using Azure.ApiManagement.PolicyToolkit.Authoring;
using Azure.ApiManagement.PolicyToolkit.Authoring.Expressions;

namespace PolicyDevOps.Apis.Policies;

[Document]
public class Api2Policy : IDocument
{
    public void Inbound(IInboundContext context)
    {
        context.Base();
        context.SetVariable("backendUrl", "{{api2BackEndUrl-{environment}}}");
        context.SetHeader("X-Hello", "Api2");

        context.SetBackendService(new SetBackendServiceConfig
        {
            BaseUrl = GetUrl(context.ExpressionContext)
        });

    }

    public static string GetUrl(IExpressionContext context)
    {
        var customers = context.Request.Url.Query["customer"];
        var customer = customers.First().ToLower();
        return ((string)context.Variables["backendUrl"]).Replace("{customer}", customer);
    }
}