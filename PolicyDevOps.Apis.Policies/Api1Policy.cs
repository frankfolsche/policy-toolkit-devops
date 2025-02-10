using Azure.ApiManagement.PolicyToolkit.Authoring;
using Azure.ApiManagement.PolicyToolkit.Authoring.Expressions;

namespace PolicyDevOps.Apis.Policies;

[Document]
public class Api1Policy : IDocument
{
    public void Inbound(IInboundContext context)
    {
        context.Base();
        context.SetHeader("X-Hello", "Api1");
        context.SetVariable("backendUrl", "{{api1BackEndUrl-{environment}}}");

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