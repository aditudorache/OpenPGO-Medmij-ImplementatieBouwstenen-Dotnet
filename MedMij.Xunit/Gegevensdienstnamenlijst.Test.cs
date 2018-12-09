// Copyright (c) Adrian Tudorache. All Rights Reserved. Licensed under the AGPLv3 (see License.txt for details).

namespace MedMij.Xunit
{
    using System;
    using System.Threading.Tasks;
    using System.Xml;
    using global::Xunit;

    public class GegevensdienstnamenlijstTest: IClassFixture<GegevensdienstnamenlijstTest>
    {
        [Theory]
        [InlineData(GegevensdienstnamenlijstTestMock.GegevensdienstnamenlijstExampleXML)]
        [InlineData(GegevensdienstnamenlijstTestMock.GegevensdienstnamenlijstSingleXML)]
        public void GegevensdienstnamenlijstParseOK(string xmlData)
        {
            var gegevensdienstnamenlijst = Gegevensdienstnamenlijst.FromXMLData(xmlData);
        }

        [Theory]
        [InlineData(GegevensdienstnamenlijstTestMock.InvalidXML)]
        public void GegevensdienstnamenlijstInvalidXML(string xmlData)
        {
            Assert.ThrowsAny<XmlException>(() => Gegevensdienstnamenlijst.FromXMLData(xmlData));
        }

        [Theory]
        [InlineData(GegevensdienstnamenlijstTestMock.GegevensdienstnamenlijstXSDFail1)]
        [InlineData(GegevensdienstnamenlijstTestMock.GegevensdienstnamenlijstXSDFail2)]
        public void GegevensdienstnamenlijstXSDFail(string xmlData)
        {
            Assert.ThrowsAny<System.Xml.Schema.XmlSchemaException>(
                () => Gegevensdienstnamenlijst.FromXMLData(xmlData));
        }

        [Theory]
        [InlineData("1")]
        public void GegevensdienstnamenlijstContains(string id)
        {
            var gegevensdienstnamenlijst = Gegevensdienstnamenlijst.FromXMLData(GegevensdienstnamenlijstTestMock.GegevensdienstnamenlijstExampleXML);
            Assert.NotNull(gegevensdienstnamenlijst);
            var result = gegevensdienstnamenlijst.GetMapIdToName();
            Assert.NotNull(result);
            Assert.True(result.ContainsKey(id));
        }

        [Theory]
        [InlineData("NaN")]
        [InlineData("-1")]
        [InlineData("")]
        public void GegevensdienstnamenlijstNotContains(string id)
        {
            var gegevensdienstnamenlijst = Gegevensdienstnamenlijst.FromXMLData(GegevensdienstnamenlijstTestMock.GegevensdienstnamenlijstExampleXML);
            Assert.NotNull(gegevensdienstnamenlijst);
            var result = gegevensdienstnamenlijst.GetMapIdToName();
            Assert.NotNull(result);
            Assert.False(result.ContainsKey(id));
        }
    }
}
