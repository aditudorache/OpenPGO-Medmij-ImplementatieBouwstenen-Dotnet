// Copyright (c) Zorgdoc.  All rights reserved.  Licensed under the AGPLv3.

namespace MedMij
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;

    /// <summary>
    /// Een zorgaanbieder zoals beschreven op https://afsprakenstelsel.medmij.nl/
    /// </summary>
    public class Zorgaanbieder
    {
        internal Zorgaanbieder(string naam, IDictionary<string, Gegevensdienst> gegevensdiensten)
        {
            this.Naam = naam;
            this.Gegevensdiensten = new ReadOnlyDictionary<string, Gegevensdienst>(gegevensdiensten);
        }

        // StyleCop kan geen Nederlands
        #pragma warning disable SA1623 // PropertySummaryDocumentationMustMatchAccessors
        /// <summary>
        /// Geeft de unieke en gebruiksvriendelijke naam van een zorgaanbieder
        /// </summary>
        public string Naam { get; }

        /// <summary>
        /// Geeft de lijst met gegevensdiensten die horen bij deze zorgaanbieder
        /// </summary>
        public IReadOnlyDictionary<string, Gegevensdienst> Gegevensdiensten { get; }
    }
}
