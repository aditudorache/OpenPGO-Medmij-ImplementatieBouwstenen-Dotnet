// Copyright (c) Zorgdoc.  All rights reserved.  Licensed under the AGPLv3.

namespace MedMij
{
    /// <summary>
    /// Een zorgaanbieder zoals beschreven op https://afsprakenstelsel.medmij.nl/
    /// </summary>
    public class Zorgaanbieder
    {
        // StyleCop kan geen Nederlands
        #pragma warning disable SA1623 // PropertySummaryDocumentationMustMatchAccessors
        #pragma warning disable SA1642 // ConstructorSummaryDocumentationMustBeginWithStandardText
        /// <summary>
        /// Initialiseer een nieuwe <see cref="Zorgaanbieder"/>.
        /// </summary>
        /// <param name="naam">De unieke en gebruiksvriendelijke naam van een zorgaanbieder</param>
        internal Zorgaanbieder(string naam)
        {
            this.Naam = naam;
        }

        /// <summary>
        /// Geeft de unieke en gebruiksvriendelijke naam van een zorgaanbieder
        /// </summary>
        public string Naam { get; }
    }
}
