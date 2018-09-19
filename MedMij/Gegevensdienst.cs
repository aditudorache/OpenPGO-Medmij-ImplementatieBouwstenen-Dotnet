// Copyright (c) Zorgdoc.  All rights reserved.  Licensed under the AGPLv3.

namespace MedMij
{
    using System;

    /// <summary>
    /// Een gegevensdienst zoals beschreven op https://afsprakenstelsel.medmij.nl/
    /// </summary>
    public class Gegevensdienst
    {
        internal Gegevensdienst(string id, Uri authorizationEndpointUri, Uri tokenEndpointUri)
        {
            this.Id = id;
            this.AuthorizationEndpointUri = authorizationEndpointUri;
            this.TokenEndpointUri = tokenEndpointUri;
        }

        #pragma warning disable SA1623 // StyleCop kan geen Nederlands
        /// <summary>
        /// Geeft de binnen de zorgaanbieder unieke id van de gegevensdienst
        /// </summary>
        public string Id { get; }

        /// <summary>
        /// Geeft de AuthorizationEndpointUri van deze gevensdienst.
        /// </summary>
        public Uri AuthorizationEndpointUri { get; }

        /// <summary>
        /// Geeft de TokenEndpointUri van deze gevensdienst.
        /// </summary>
        public Uri TokenEndpointUri { get; }
    }
}
