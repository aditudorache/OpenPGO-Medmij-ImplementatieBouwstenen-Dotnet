// Copyright (c) Adrian Tudorache. All Rights Reserved. Licensed under the AGPLv3 (see License.txt for details).

namespace MedMij.Xunit
{
    public static class OAuthclientlistTestMock
    {
        public const string OAuthClientCollectionExampleXML = @"<?xml version=""1.0"" encoding=""UTF-8""?>
<!--File version: 2-->
<OAuthclientlist xmlns=""xmlns://afsprakenstelsel.medmij.nl/oauthclientlist/release2/"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xsi:schemaLocation=""xmlns://afsprakenstelsel.medmij.nl/oauthclientlist/release2/ MedMij_OAuthclientlist.xsd"">
    <Tijdstempel>2018-04-16T11:41:59Z</Tijdstempel>
    <Volgnummer>522</Volgnummer>
    <OAuthclients>
        <OAuthclient>
            <Hostname>medmij.deenigeechtepgo.nl</Hostname>
            <OAuthclientOrganisatienaam>De Enige Echte PGO</OAuthclientOrganisatienaam>
        </OAuthclient>
        <OAuthclient>
            <Hostname>pgocluster68.personalhealthprovider.net</Hostname>
            <OAuthclientOrganisatienaam>Unstealth Health Midden-Nederland</OAuthclientOrganisatienaam>
        </OAuthclient>
    </OAuthclients>
</OAuthclientlist>";

        public const string OAuthClientCollectionEmptyExampleXML = @"<?xml version=""1.0"" encoding=""UTF-8""?>
<!--File version: 2-->
<OAuthclientlist xmlns=""xmlns://afsprakenstelsel.medmij.nl/oauthclientlist/release2/"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xsi:schemaLocation=""xmlns://afsprakenstelsel.medmij.nl/oauthclientlist/release2/ MedMij_OAuthclientlist.xsd"">
    <Tijdstempel>2018-04-16T11:41:59Z</Tijdstempel>
    <Volgnummer>522</Volgnummer>
    <OAuthclients/>
</OAuthclientlist>";

        public const string OAuthClientCollectionXSDFail1 = "<test/>";

        public const string OAuthClientCollectionXSDFail2 = @"<Test xmlns=""xmlns://afsprakenstelsel.medmij.nl/zorgaanbiederslijst/release2/"" />";

        public const string OAuthClientCollectionURL = "https://raw.githubusercontent.com/GidsOpenStandaarden/OpenPGO/6bb34321ceff9fd6e53dd243090b8f4b6aad7760/Resources/MedMij_Zorgaanbiederslijst_example.xml";

        public const string InvalidXML = "<hhhu";
    }
}
