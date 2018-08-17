//  Copyright (c) Zorgdoc.  All Rights Reserved.  Licensed under the AGPLv3.

namespace MedMij
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

        public const string WhitelistInvalidXML = "<hhhu";

        public const string WhitelistURL = "https://raw.githubusercontent.com/GidsOpenStandaarden/OpenPGO/6bb34321ceff9fd6e53dd243090b8f4b6aad7760/Resources/MedMij_Whitelist_example.xml";
    }
}