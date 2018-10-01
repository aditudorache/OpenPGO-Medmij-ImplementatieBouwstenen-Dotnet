// Copyright (c) Zorgdoc.  All rights reserved.  Licensed under the AGPLv3.

namespace MedMij
{
    using System;

    /// <summary>
    /// Een gegevensdienst zoals beschreven op https://afsprakenstelsel.medmij.nl/
    /// </summary>
    public interface IGegevensdienst
    {
        #pragma warning disable SA1623 // StyleCop kan geen Nederlands
        /// <summary>
        /// Geeft de Id van deze gevensdienst.
        /// </summary>
        string Id { get; }

        /// <summary>
        /// Geeft de naam van de zorgaanbieder van deze gevensdienst. Eindigt altijd op "@medmij"
        /// </summary>
        string Zorgaanbiedernaam { get; }

        /// <summary>
        /// Geeft de AuthorizationEndpointUri van deze gevensdienst.
        /// </summary>
        Uri AuthorizationEndpointUri { get; }

        /// <summary>
        /// Geeft de TokenEndpointUri van deze gevensdienst.
        /// </summary>
        Uri TokenEndpointUri { get; }
    }
}
