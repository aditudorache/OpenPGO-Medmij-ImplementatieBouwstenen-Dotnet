
// Copyright (c) Adrian Tudorache. All Rights Reserved. Licensed under the AGPLv3 (see License.txt for details).

namespace MedMij.Xunit
{
    public static class GegevensdienstnamenlijstTestMock
    {
        public const string GegevensdienstnamenlijstExampleXML = @"<?xml version=""1.0"" encoding=""UTF-8""?>
<!--File version: 2-->
<Gegevensdienstnamenlijst xmlns=""xmlns://afsprakenstelsel.medmij.nl/gegevensdienstnamenlijst/release1/"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xsi:schemaLocation=""xmlns://afsprakenstelsel.medmij.nl/gegevensdienstnamenlijst/release1/ MedMij_Gegevensdienstnamenlijst.xsd"">
    <Tijdstempel>2018-07-19T10:43:41+01:00</Tijdstempel>
    <Volgnummer>28800</Volgnummer>
    <Gegevensdiensten>
        <Gegevensdienst>
            <GegevensdienstId>1</GegevensdienstId>
            <Weergavenaam>Basisgegevens Zorg</Weergavenaam>
        </Gegevensdienst>
        <Gegevensdienst>
            <GegevensdienstId>2</GegevensdienstId>
            <Weergavenaam>Medicatieoverzichten</Weergavenaam>
        </Gegevensdienst>
        <Gegevensdienst>
            <GegevensdienstId>3</GegevensdienstId>
            <Weergavenaam>Medicatiegegevens</Weergavenaam>
        </Gegevensdienst>
        <Gegevensdienst>
            <GegevensdienstId>4</GegevensdienstId>
            <Weergavenaam>Laboratoriumresultaten</Weergavenaam>
        </Gegevensdienst>
        <Gegevensdienst>
            <GegevensdienstId>5</GegevensdienstId>
            <Weergavenaam>Meetwaarden vitale functies</Weergavenaam>
        </Gegevensdienst>
        <Gegevensdienst>
            <GegevensdienstId>6</GegevensdienstId>
            <Weergavenaam>Documenten</Weergavenaam>
        </Gegevensdienst>
        <Gegevensdienst>
            <GegevensdienstId>7</GegevensdienstId>
            <Weergavenaam>Afspraken</Weergavenaam>
        </Gegevensdienst>
    </Gegevensdiensten>
</Gegevensdienstnamenlijst>";

        public const string GegevensdienstnamenlijstSingleXML = @"<?xml version=""1.0"" encoding=""UTF-8""?>
<!--File version: 2-->
<Gegevensdienstnamenlijst xmlns=""xmlns://afsprakenstelsel.medmij.nl/gegevensdienstnamenlijst/release1/"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xsi:schemaLocation=""xmlns://afsprakenstelsel.medmij.nl/gegevensdienstnamenlijst/release1/ MedMij_Gegevensdienstnamenlijst.xsd"">
    <Tijdstempel>2018-07-19T10:43:41+01:00</Tijdstempel>
    <Volgnummer>28800</Volgnummer>
    <Gegevensdiensten>
        <Gegevensdienst>
            <GegevensdienstId>1</GegevensdienstId>
            <Weergavenaam>Basisgegevens Zorg</Weergavenaam>
        </Gegevensdienst>
    </Gegevensdiensten>
</Gegevensdienstnamenlijst>";

        public const string GegevensdienstnamenlijstXSDFail1 = "<test/>";

        public const string GegevensdienstnamenlijstXSDFail2 = @"<Gegevensdienstnamenlijst xmlns=""xmlns://afsprakenstelsel.medmij.nl/gegevensdienstnamenlijst/release1/""/>";

        public const string InvalidXML = "<invalid xml ";
    }
}