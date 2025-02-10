using Azure.ApiManagement.PolicyToolkit.Authoring.Expressions;
using NSubstitute;

namespace PolicyDevOps.Apis.Policies.Tests
{
    public class Api1PolicyTest : SharedPolicyTest
    {
        [Fact]
        public void GetUrlTest()
        {
            this.GetUrl(Api1Policy.GetUrl);
        }
    }
}