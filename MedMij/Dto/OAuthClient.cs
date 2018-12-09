// Copyright (c) Adrian Tudorache. All Rights Reserved. Licensed under the AGPLv3 (see License.txt for details).

namespace MedMij
{
    /// <summary>
    /// Een OAuth client zoals beschreven op https://afsprakenstelsel.medmij.nl/
    /// </summary>
    public class OAuthClient
    {
        internal OAuthClient(string hostname, string organisatienaam)
        {
            this.Hostname = hostname;
            this.Organisatienaam = organisatienaam;
        }

        // StyleCop kan geen Nederlands
        #pragma warning disable SA1623 // PropertySummaryDocumentationMustMatchAccessors
        /// <summary>
        /// Geeft de hostname van een OAuth Client van een "Dienstverleners persoon"
        /// </summary>
        public string Hostname { get; }

        /// <summary>
        /// Geeft de unieke en gebruiksvriendelijke naam van een "Dienstverleners persoon"
        /// </summary>
        public string Organisatienaam { get; }
    }
}