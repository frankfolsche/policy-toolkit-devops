using Azure.ApiManagement.PolicyToolkit.Authoring.Expressions;
using NSubstitute;

namespace PolicyDevOps.Apis.Policies.Tests
{
    public class Api2PolicyTest : SharedPolicyTest
    {
        [Fact]
        public void GetUrlTest()
        {
            this.GetUrl(Api2Policy.GetUrl);
        }
    }
}