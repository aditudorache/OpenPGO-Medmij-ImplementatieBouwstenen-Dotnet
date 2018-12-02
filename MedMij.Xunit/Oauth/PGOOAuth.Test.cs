// Copyright (c) Adrian Tudorache. All Rights Reserved. Licensed under the AGPLv3 (see License.txt for details).

namespace MedMij.Xunit
{
    using System.Net;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using global::Xunit;
    using Moq;
    using Moq.Protected;
    using MedMij.Oauth;

    public class PGOOAuthTest
    {
        [Fact]
        public void TestMakeAuthUri()
        {
            const string ZANAAM = "za@medmij";
            const string ID = "5";
            const string SCOPE = "za~5";
            const string ZAAUTH = "https://za.example.com/auth";
            const string PGO_REDIR = "https://pgo.example.com/my-endpoint";
            const string PGO_ID = "pgo.example.com";

            var gegevensdienstMock = new Mock<IGegevensdienst>();
            gegevensdienstMock.Setup(geg => geg.Zorgaanbiedernaam).Returns(ZANAAM);
            gegevensdienstMock.Setup(geg => geg.Id).Returns(ID);
            gegevensdienstMock.Setup(geg => geg.AuthorizationEndpointUri).Returns(new System.Uri(ZAAUTH));

            var url = PGOOAuth.MakeAuthUri(
                gegevensdienst: gegevensdienstMock.Object,
                clientId: PGO_ID,
                redirectUri: PGO_REDIR,
                state: "abc"
            );

            Assert.StartsWith(ZAAUTH, url.ToString());
            Assert.Contains($"client_id={PGO_ID}", url.Query);
            Assert.Contains($"scope={SCOPE}", url.Query);
        }

        [Fact]
        public async void TestGetAccessToken()
        {
            const string TOKEN = "ABC";
            const string URI = "https://example.com/token";
            var facmoq = StringClientFactoryMock(TOKEN, out var handlerMock);
            var gegevensdienstMock = new Mock<IGegevensdienst>();
            gegevensdienstMock.Setup(geg => geg.TokenEndpointUri).Returns(new System.Uri(URI));

            var t = await PGOOAuth.GetAccessToken(
                gegevensdienst: gegevensdienstMock.Object,
                authorizationCode: "test123",
                redirectUri: "https://pgo.example.com/redir",
                httpClientFactory: facmoq
            );

            Assert.Equal(TOKEN, t);

            handlerMock.Protected().Verify(
                "SendAsync",
                Times.Exactly(1),
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>()
            );

            handlerMock.Protected().Verify(
                "SendAsync",
                Times.Exactly(1),
                ItExpr.Is<HttpRequestMessage>(req => req.Method == HttpMethod.Post && req.RequestUri.ToString().StartsWith(URI)),
                ItExpr.IsAny<CancellationToken>()
            );
        }

        private static IHttpClientFactory StringClientFactoryMock(string returnValue, out Mock<HttpMessageHandler> handlerMock)
        {
            handlerMock = new Mock<HttpMessageHandler>();
            handlerMock.Protected()
                       .Setup<Task<HttpResponseMessage>>(
                           "SendAsync",
                           ItExpr.IsAny<HttpRequestMessage>(),
                           ItExpr.IsAny<CancellationToken>())
                       .ReturnsAsync(
                           new HttpResponseMessage()
                           {
                               StatusCode = HttpStatusCode.OK,
                               Content = new StringContent(returnValue),
                           })
                       .Verifiable();
            var httpClient = new HttpClient(handler: handlerMock.Object);
            var facmoq = new Mock<IHttpClientFactory>();
            facmoq.Setup(f => f.CreateClient(It.IsAny<string>())).Returns(() => httpClient);
            return facmoq.Object;
        }
    }
}
