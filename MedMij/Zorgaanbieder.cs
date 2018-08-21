// Copyright (c) Zorgdoc.  All rights reserved.  Licensed under the AGPLv3.

namespace MedMij
{
    /// <summary>
    /// Een zorgaanbieder zoals beschreven op https://afsprakenstelsel.medmij.nl/
    /// </summary>
    public class Zorgaanbieder
    {
        internal Zorgaanbieder(string naam)
        {
            this.Naam = naam;
        }

        // StyleCop kan geen Nederlands
        #pragma warning disable SA1623 // PropertySummaryDocumentationMustMatchAccessors
        /// <summary>
        /// Geeft de unieke en gebruiksvriendelijke naam van een zorgaanbieder
        /// </summary>
        public string Naam { get; }
    }
}
