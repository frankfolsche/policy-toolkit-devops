using Azure.ApiManagement.PolicyToolkit.Authoring.Expressions;
using NSubstitute;
using FluentAssertions;

namespace PolicyDevOps.Apis.Policies.Tests
{
    public class SharedPolicyTest
    {
        public void GetUrl(Func<IExpressionContext, string> getUrl)
        {
            var context = Substitute.For<IExpressionContext>();
            context.Variables["backendUrl"].Returns("some-{customer}-url");
            var queryDictionary = new Dictionary<string, string[]>
            {
                { "customer", new[] { "partner" } }
            };
            ConfigureQuery(context, queryDictionary, "customers");

            // Act
            var result = getUrl(context);

            // Assert
            result.Should().Be("some-partner-url");
        }

        private void ConfigureQuery(IExpressionContext expressionContext, Dictionary<string, string[]> queryDictionary, string path)
        {
            // Create a mock for IRequest
            var requestMock = Substitute.For<IRequest>();

            // Create a mock for IUrl
            var urlMock = Substitute.For<IUrl>();
            var apiMock = Substitute.For<IContextApi>();

            // Set up the Url property on IRequest to return the mocked IUrl
            requestMock.Url.Returns(urlMock);
            apiMock.Path.Returns(path);

            // Set up the Query property on IUrl to return the provided dictionary
            urlMock.Query.Returns(queryDictionary);

            // Set up the Request property on IExpressionContext to return the mocked IRequest
            expressionContext.Request.Returns(requestMock);
            expressionContext.Api.Returns(apiMock);
        }
    }
}