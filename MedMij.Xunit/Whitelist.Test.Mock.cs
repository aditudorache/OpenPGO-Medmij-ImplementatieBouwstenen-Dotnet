// Copyright (c) Adrian Tudorache. All Rights Reserved. Licensed under the AGPLv3 (see License.txt for details).

namespace MedMij.Xunit
{
    public static class WhitelistTestMock
    {
        public const string WhiltelistExampleXML = @"<?xml version=""1.0"" encoding=""UTF-8""?>
<!--File version: 5-->
<Whitelist xmlns=""xmlns://afsprakenstelsel.medmij.nl/whitelist/release2/"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xsi:schemaLocation=""xmlns://afsprakenstelsel.medmij.nl/whitelist/release2/ MedMij_Whitelist.xsd"">
    <Tijdstempel>2018-04-16T10:43:41+01:00</Tijdstempel>
    <Volgnummer>28654</Volgnummer>
    <MedMijNodes>
        <MedMijNode>
            <Hostname>medmij.deenigeechtepgo.nl</Hostname>
        </MedMijNode>
        <MedMijNode>
            <Hostname>pgocluster68.personalhealthprovider.net</Hostname>
        </MedMijNode>
        <MedMijNode>
            <Hostname>78834.umcharderwijk.nl</Hostname>
        </MedMijNode>
        <MedMijNode>
            <Hostname>medmij.za982.xisbridge.net</Hostname>
        </MedMijNode>
        <MedMijNode>
            <Hostname>medmij.za983.xisbridge.net</Hostname>
        </MedMijNode>
        <MedMijNode>
            <Hostname>medmij.xisbridge.net</Hostname>
        </MedMijNode>
        <MedMijNode>
            <Hostname>rcf-rso.nl</Hostname>
        </MedMijNode>
    </MedMijNodes>
</Whitelist>";

        public const string WhiltelistSingleXML = @"<?xml version=""1.0"" encoding=""UTF-8""?>
<!--File version: 5-->
<Whitelist xmlns=""xmlns://afsprakenstelsel.medmij.nl/whitelist/release2/"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xsi:schemaLocation=""xmlns://afsprakenstelsel.medmij.nl/whitelist/release2/ MedMij_Whitelist.xsd"">
    <Tijdstempel>2018-04-16T10:43:41+01:00</Tijdstempel>
    <Volgnummer>28654</Volgnummer>
    <MedMijNodes>
        <MedMijNode>
            <Hostname>x.yz</Hostname>
        </MedMijNode>
    </MedMijNodes>
</Whitelist>";

        public const string WhitelistXSDFail1 = "<test/>";

        public const string WhitelistXSDFail2 = @"<Whitelist xmlns=""xmlns://afsprakenstelsel.medmij.nl/whitelist/release2/""/>";

        public const string InvalidXML = "<hhhu";
    }
}