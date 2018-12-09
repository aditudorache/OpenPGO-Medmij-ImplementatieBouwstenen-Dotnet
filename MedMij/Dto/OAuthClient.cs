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

        /// <summary>
        /// Gets de hostname van een OAuth Client van een "Dienstverleners persoon"
        /// </summary>
        public string Hostname { get; }

        /// <summary>
        /// Gets de unieke en gebruiksvriendelijke naam van een "Dienstverleners persoon"
        /// </summary>
        public string Organisatienaam { get; }
    }
}