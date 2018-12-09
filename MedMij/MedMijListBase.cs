// Copyright (c) Adrian Tudorache. All Rights Reserved. Licensed under the AGPLv3 (see License.txt for details).

namespace MedMij
{
    using System.Collections.Generic;
    using System.Xml.Linq;

    /// <summary>
    /// The base class for the MedMij lists
    /// </summary>
    /// <typeparam name="T">The data structure used in the list</typeparam>
    public abstract class MedMijListBase<T>
    {
        /// <summary>
        /// Gets or sets the data list
        /// </summary>
        public List<T> Data { get; set; }

        /// <summary>
        /// Parses the xml document to the list
        /// </summary>
        /// <param name="doc">The xml document</param>
        /// <returns>A list with data</returns>
        protected abstract List<T> ParseXml(XDocument doc);
    }
}