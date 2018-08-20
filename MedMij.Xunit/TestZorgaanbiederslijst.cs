// Copyright (c) Zorgdoc.  All Rights Reserved.  Licensed under the AGPLv3.

namespace MedMij.Xunit
{
    using System.Threading.Tasks;
    using System.Xml;
    using global::Xunit;

    public class TestZorgaanbiedrslijst
    {
        [Theory]
        [InlineData(TestData.ZorgaanbiederslijstExampleXML)]
        public void WhitelistParseOK(string xmlData)
        {
            Zorgaanbiederslijst.FromXMLData(xmlData);
        }
    }
}
