// Copyright (c) Adrian Tudorache. All Rights Reserved. Licensed under the AGPLv3 (see License.txt for details).

namespace MedMij
{
    using System;

    /// <summary>
    /// Een gegevensdienst zoals beschreven op https://afsprakenstelsel.medmij.nl/
    /// </summary>
    public interface IGegevensdienst
    {
        /// <summary>
        /// Gets de Id van deze gevensdienst.
        /// </summary>
        string Id { get; }

        /// <summary>
        /// Gets de naam van de zorgaanbieder van deze gevensdienst. Eindigt altijd op "@medmij"
        /// </summary>
        string Zorgaanbiedernaam { get; }

        /// <summary>
        /// Gets de AuthorizationEndpointUri van deze gevensdienst.
        /// </summary>
        Uri AuthorizationEndpointUri { get; }

        /// <summary>
        /// Gets de TokenEndpointUri van deze gevensdienst.
        /// </summary>
        Uri TokenEndpointUri { get; }
    }
}
