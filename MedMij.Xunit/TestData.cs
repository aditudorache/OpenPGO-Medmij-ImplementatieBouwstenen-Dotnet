// Copyright (c) Adrian Tudorache. All Rights Reserved. Licensed under the AGPLv3 (see License.txt for details).

namespace MedMij.Xunit
{
    public static class TestData
    {
        public const string WhiltelistExampleXML = @"<?xml version=""1.0"" encoding=""UTF-8""?>
<!--File version: 2-->
<Whitelist xmlns=""xmlns://afsprakenstelsel.medmij.nl/whitelist/release2/"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xsi:schemaLocation=""xmlns://afsprakenstelsel.medmij.nl/whitelist/release2/ MedMij_Whitelist.xsd"">
    <Tijdstempel>2018-04-16T10:43:41+01:00</Tijdstempel>
    <Volgnummer>28654</Volgnummer>
    <MedMijNodes>
        <MedMijNode>specimen-stelselnode.medmij.nl</MedMijNode>
        <MedMijNode>medmij.deenigeechtepgo.nl</MedMijNode>
        <MedMijNode>pgocluster68.personalhealthprovider.net</MedMijNode>
        <MedMijNode>78834.umcharderwijk.nl</MedMijNode>
        <MedMijNode>medmij.za982.xisbridge.net</MedMijNode>
        <MedMijNode>medmij.za983.xisbridge.net</MedMijNode>
        <MedMijNode>medmij.xisbridge.net</MedMijNode>
        <MedMijNode>rcf-rso.nl</MedMijNode>
    </MedMijNodes>
</Whitelist>";

        public const string WhiltelistSingleXML = @"<Whitelist xmlns=""xmlns://afsprakenstelsel.medmij.nl/whitelist/release2/"">
    <Tijdstempel>2018-04-16T10:43:41+01:00</Tijdstempel>
    <Volgnummer>1</Volgnummer>
    <MedMijNodes>
        <MedMijNode>x.yz</MedMijNode>
    </MedMijNodes>
</Whitelist>";

        public const string WhitelistXSDFail1 = "<test/>";

        public const string WhitelistXSDFail2 = @"<Whitelist xmlns=""xmlns://afsprakenstelsel.medmij.nl/whitelist/release2/""/>";

        public const string InvalidXML = "<hhhu";

        public const string WhitelistURL = "https://raw.githubusercontent.com/GidsOpenStandaarden/OpenPGO/6bb34321ceff9fd6e53dd243090b8f4b6aad7760/Resources/MedMij_Whitelist_example.xml";

        public const string ZorgaanbiedersCollectionExampleXML = @"<?xml version=""1.0"" encoding=""UTF-8""?>
<!--File version: 2-->
<Zorgaanbiederslijst xmlns=""xmlns://afsprakenstelsel.medmij.nl/zorgaanbiederslijst/release2/"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xsi:schemaLocation=""xmlns://afsprakenstelsel.medmij.nl/zorgaanbiederslijst/release2/ MedMij_Zorgaanbiederslijst.xsd"">
    <Tijdstempel>2018-04-16T12:56:33Z</Tijdstempel>
    <Volgnummer>6</Volgnummer>
    <Zorgaanbieders>
        <Zorgaanbieder>
            <Zorgaanbiedernaam>umcharderwijk@medmij</Zorgaanbiedernaam>
            <Gegevensdiensten>
                <Gegevensdienst>
                    <GegevensdienstId>4</GegevensdienstId>
                    <AuthorizationEndpoint>
                        <AuthorizationEndpointuri>https://medmij.za982.xisbridge.net/oauth/authorize</AuthorizationEndpointuri>
                    </AuthorizationEndpoint>
                    <TokenEndpoint>
                        <TokenEndpointuri>https://medmij.xisbridge.net/oauth/token</TokenEndpointuri>
                    </TokenEndpoint>
                    <Systeemrollen>
                        <Systeemrol>
                            <Systeemrolcode>LAB-1.0.0-LRB-FHIR</Systeemrolcode>
                            <ResourceEndpoint>
                                <ResourceEndpointuri>https://medmij.za982.xisbridge.net/fhir</ResourceEndpointuri>
                            </ResourceEndpoint>
                        </Systeemrol>
                    </Systeemrollen>
                </Gegevensdienst>
                <Gegevensdienst>
                    <GegevensdienstId>6</GegevensdienstId>
                    <AuthorizationEndpoint>
                        <AuthorizationEndpointuri>https://78834.umcharderwijk.nl/oauth/authorize</AuthorizationEndpointuri>
                    </AuthorizationEndpoint>
                    <TokenEndpoint>
                        <TokenEndpointuri>https://78834.umcharderwijk.nl:8099/oauth/token</TokenEndpointuri>
                    </TokenEndpoint>
                    <Systeemrollen>
                        <Systeemrol>
                            <Systeemrolcode>MM-1.0.0-PLB-FHIR</Systeemrolcode>
                            <ResourceEndpoint>
                                <ResourceEndpointuri>https://78834.umcharderwijk.nl:9100/pdfa</ResourceEndpointuri>
                            </ResourceEndpoint>
                        </Systeemrol>
                        <Systeemrol>
                            <Systeemrolcode>MM-1.0.0-PDB-FHIR</Systeemrolcode>
                            <ResourceEndpoint>
                                <ResourceEndpointuri>https://78834.umcharderwijk.nl:9100/pdfa</ResourceEndpointuri>
                            </ResourceEndpoint>
                        </Systeemrol>
                    </Systeemrollen>
                </Gegevensdienst>
            </Gegevensdiensten>
        </Zorgaanbieder>
        <Zorgaanbieder>
            <Zorgaanbiedernaam>radiologencentraalflevoland@medmij</Zorgaanbiedernaam>
            <Gegevensdiensten>
                <Gegevensdienst>
                    <GegevensdienstId>1</GegevensdienstId>
                    <AuthorizationEndpoint>
                        <AuthorizationEndpointuri>https://medmij.za983.xisbridge.net/oauth/authorize</AuthorizationEndpointuri>
                    </AuthorizationEndpoint>
                    <TokenEndpoint>
                        <TokenEndpointuri>https://medmij.xisbridge.net/oauth/token</TokenEndpointuri>
                    </TokenEndpoint>
                    <Systeemrollen>
                        <Systeemrol>
                            <Systeemrolcode>MM-1.0.0-BZB-FHIR</Systeemrolcode>
                            <ResourceEndpoint>
                                <ResourceEndpointuri>https://rcf-rso.nl/rcf/fhir-stu3</ResourceEndpointuri>
                            </ResourceEndpoint>
                        </Systeemrol>
                    </Systeemrollen>
                </Gegevensdienst>
            </Gegevensdiensten>
        </Zorgaanbieder>
    </Zorgaanbieders>
</Zorgaanbiederslijst>";
        public const string ZorgaanbiedersCollectionEmptyExampleXML = @"<?xml version=""1.0"" encoding=""UTF-8""?>
<!--File version: 2-->
<Zorgaanbiederslijst xmlns=""xmlns://afsprakenstelsel.medmij.nl/zorgaanbiederslijst/release2/"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xsi:schemaLocation=""xmlns://afsprakenstelsel.medmij.nl/zorgaanbiederslijst/release2/ MedMij_Zorgaanbiederslijst.xsd"">
    <Tijdstempel>2018-04-16T12:56:33Z</Tijdstempel>
    <Volgnummer>6</Volgnummer>
    <Zorgaanbieders>
    </Zorgaanbieders>
</Zorgaanbiederslijst>";

        public const string ZorgaanbiedersCollectionXSDFail1 = "<test/>";

        public const string ZorgaanbiedersCollectionXSDFail2 = @"<Zorgaanbiederslijst xmlns=""xmlns://afsprakenstelsel.medmij.nl/zorgaanbiederslijst/release2/"" />";

        public const string ZorgaanbiedersCollectionURL = "https://raw.githubusercontent.com/GidsOpenStandaarden/OpenPGO/6bb34321ceff9fd6e53dd243090b8f4b6aad7760/Resources/MedMij_Zorgaanbiederslijst_example.xml";

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
    }
}
