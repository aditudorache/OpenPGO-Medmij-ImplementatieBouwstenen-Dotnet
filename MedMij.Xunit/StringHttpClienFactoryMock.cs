// Copyright (c) Zorgdoc.  All Rights Reserved.  Licensed under the AGPLv3.

namespace MedMij.Xunit
{
    using System.Net;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;

    class StringHttpClienFactoryMock : IHttpClientFactory
    {
        private string _result;

        public StringHttpClienFactoryMock(string result)
        {
            _result = result;
        }

        public class MockMessageHandler : HttpMessageHandler
        {
            private string _result;

            public MockMessageHandler(string result)
            {
                _result = result;
            }

            protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                var r = new HttpResponseMessage(HttpStatusCode.OK);
                r.Content = new StringContent(_result);
                return Task.FromResult(r);
            }
        }

        public HttpClient CreateClient(string name)
            => new HttpClient(new MockMessageHandler(_result));
    }
}
