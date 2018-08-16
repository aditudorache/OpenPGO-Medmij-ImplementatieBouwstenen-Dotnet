using System;
using Xunit;

namespace MedMij.Xunit
{
    public class TestWhitelist
    { 
        [Theory] 
        [InlineData(TestData.WhiltelistExampleXML)]
        public void WhiteListParseOK(string xmlData)
        {
            var whitelist = WhiteList.FromXMLData(xmlData);
        }

        [Theory] 
        [InlineData(TestData.WhitelistNietXSD)]
        [InlineData(TestData.WhitelistInvalidXML)]
        public void WhiteListParseNotOK(string xmlData)
        {
            Assert.ThrowsAny<Exception>(() => WhiteList.FromXMLData(xmlData));
        }
    }
}
