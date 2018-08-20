// Copyright (c) Zorgdoc.  All Rights Reserved.  Licensed under the AGPLv3.

namespace MedMij.Xunit
{
    using System.Threading.Tasks;
    using System.Xml;
    using global::Xunit;

    public class TestZorgaanbiedrsCollection
    {
        [Theory]
        [InlineData(TestData.ZorgaanbiedersCollectionExampleXML)]
        public void ZorgaanbiedersCollectionParseOK(string xmlData)
        {
            ZorgaanbiedersCollection.FromXMLData(xmlData);
        }

        [Theory]
        [InlineData(TestData.ZorgaanbiedersCollectionExampleXML)]
        public void ZorgaanbiedersCollectionIsIterable(string xmlData)
        {
            var col = ZorgaanbiedersCollection.FromXMLData(xmlData);
            foreach (var c in col)
            {
                System.Console.WriteLine(c.Naam);
            }
        }
    }
}
