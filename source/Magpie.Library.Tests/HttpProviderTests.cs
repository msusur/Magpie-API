using System;
using Magpie.Library.Http;
using Magpie.Library.Http.Exceptions;
using Xunit;

namespace Magpie.Library.Tests
{
    public class HttpProviderTests
    {
        const string ValidUrlSample = "http://www.google.com";
        const string InvalidUrlSample = "http://www.google.";

        [Fact]
        public void ShouldSetUrlOptionsIfTheUrlIsValid()
        {
            var provider = HttpCall.To(ValidUrlSample);
            Assert.Equal(ValidUrlSample, provider.Options.TargetUrl);
        }

        [Fact]
        public void ShouldThrowExceptionIfTheUrlIsNotValid()
        {
            Assert.Throws<InvalidUrlException>(() => HttpCall.To(InvalidUrlSample));
        }

        [Fact]
        public void ShouldAddSingleHeader()
        {
            string header = "test-header";
            string value = "well";
            var call = HttpCall.To(ValidUrlSample).AddHeader(header, value);
            Assert.True(call.Options.Headers.ContainsKey(header));
            Assert.Equal(value, call.Options.Headers[header]);
        }

        [Fact]
        public void ShouldAddInterceptor()
        {
            var call = HttpCall.To(ValidUrlSample).InterceptWith<TestInterceptor>();
            Assert.Equal(1, call.Options.Interceptors.Count);
        }

        [Fact]
        public void ShouldMakeCallWithGenericHttpMethod()
        {
            Action<CallResponse> callback = c => { };
            var result = HttpCall
                .To("http://localhost:8088");
            //.Execute("TESTMETHOD", callback);
        }
    }

    public class TestInterceptor : BaseInterceptor
    {
    }
}