// Copyright (c) Adrian Tudorache. All Rights Reserved. Licensed under the AGPLv3 (see License.txt for details).

namespace MedMij
{
    internal class MedMijDefinitions
    {
        public const string Gegevensdienstnamenlijst = "Gegevensdienstnamenlijst";
        public const string GegevensdienstnamenlijstNamespace = "xmlns://afsprakenstelsel.medmij.nl/gegevensdienstnamenlijst/release1/";
        public const string OAuthclientlist = "OAuthclientlist";
        public const string OAuthclientlistNamespace = "xmlns://afsprakenstelsel.medmij.nl/oauthclientlist/release2/";
        public const string Whitelist = "Whitelist";
        public const string WhitelistNamespace = "xmlns://afsprakenstelsel.medmij.nl/whitelist/release2/";
        public const string Zorgaanbiederslijst = "Zorgaanbiederslijst";
        public const string ZorgaanbiederslijstNamespace = "xmlns://afsprakenstelsel.medmij.nl/zorgaanbiederslijst/release2/";

        public static string XsdName(string entityName)
        {
            return $"MedMij_{entityName}.xsd";
        }
    }
}
