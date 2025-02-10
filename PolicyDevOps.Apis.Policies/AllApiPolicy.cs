using Azure.ApiManagement.PolicyToolkit.Authoring;
using Azure.ApiManagement.PolicyToolkit.Authoring.Expressions;

namespace PolicyDevOps.Apis.Policies;

[Document]
public class BaseApiPolicy : IDocument
{
    public void Inbound(IInboundContext context)
    {
        context.Cors(new CorsConfig
        {
            AllowCredentials = true,
            AllowedOrigins = ["{{apimUrl}}", "{{devportalUrl}}"],
            AllowedMethods = ["*"],
            AllowedHeaders = ["*"],
            ExposeHeaders = ["*"],
            PreflightResultMaxAge = 300
        });
    }
}