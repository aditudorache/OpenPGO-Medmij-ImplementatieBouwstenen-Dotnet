// Copyright (c) Adrian Tudorache. All Rights Reserved. Licensed under the AGPLv3 (see License.txt for details).

namespace MedMij.Xunit
{
    using System;
    using global::Xunit;
    using MedMij.Oauth;

    public class ZAOAuthTest
    {
        [Fact]
        public void TestMakeRedirectURL()
        {
            const string UriString = "https://example.com";
            var url = ZAOAuth.MakeRedirectURL(baseUri: UriString, state: "abc", authCode: "xyz");

            Assert.Equal(UriString, url.GetLeftPart(UriPartial.Authority));
            Assert.StartsWith("/cb", url.AbsolutePath);
            Assert.Contains("state=abc", url.Query);
            Assert.Contains("code=xyz", url.Query);
        }
    }
}
