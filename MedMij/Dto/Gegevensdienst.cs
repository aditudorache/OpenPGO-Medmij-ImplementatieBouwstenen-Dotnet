// Copyright (c) Adrian Tudorache. All Rights Reserved. Licensed under the AGPLv3 (see License.txt for details).

namespace MedMij
{
    using System;

    /// <summary>
    /// Een gegevensdienst zoals beschreven op https://afsprakenstelsel.medmij.nl/
    /// </summary>
    public class Gegevensdienst : IGegevensdienst
    {
        internal Gegevensdienst(string id, string zorgaanbiedernaam, Uri authorizationEndpointUri, Uri tokenEndpointUri)
        {
            this.Id = id;
            this.Zorgaanbiedernaam = zorgaanbiedernaam;
            this.AuthorizationEndpointUri = authorizationEndpointUri;
            this.TokenEndpointUri = tokenEndpointUri;
        }

        /// <summary>
        /// Gets de binnen de zorgaanbieder unieke id van de gegevensdienst
        /// </summary>
        public string Id { get; }

        /// <summary>
        /// Gets de naam van de zorgaanbieder van deze gevensdienst. Eindigt altijd op "@medmij"
        /// </summary>
        public string Zorgaanbiedernaam { get; }

        /// <summary>
        /// Gets de AuthorizationEndpointUri van deze gevensdienst.
        /// </summary>
        public Uri AuthorizationEndpointUri { get; }

        /// <summary>
        /// Gets de TokenEndpointUri van deze gevensdienst.
        /// </summary>
        public Uri TokenEndpointUri { get; }
    }
}
