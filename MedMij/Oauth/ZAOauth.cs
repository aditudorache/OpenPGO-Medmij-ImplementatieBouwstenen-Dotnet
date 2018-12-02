// Copyright (c) Adrian Tudorache. All Rights Reserved. Licensed under the AGPLv3 (see License.txt for details).

namespace MedMij.Oauth
{
    using System;
    using System.Collections.Generic;
    using Microsoft.AspNetCore.WebUtilities;

    /// <summary>
    /// Methodes voor het implementeren van OAuth aan de kant van de zorgaanbieder
    /// </summary>
    public static class ZAOAuth
    {
        /// <summary>
        /// Geeft de URL waar de zorggebruiker naartoe geredirect moet worden.
        /// Geeft de auth code en de de state mee aan PGO
        /// </summary>
        /// <param name="baseUri">De url die verwijst naar de PGO. Deze is doorgegeven door de browser van de zorggebruiker.</param>
        /// <param name="state">De state die de PGO heeft meegegeven aan de </param>
        /// <param name="authCode">de authCode geeft de PGO toegang tot de patientgegevens</param>
        /// <returns>De URL met alle benodigde parameters die de PGO nodig heeft om de OAuth flow af te ronden</returns>
        public static Uri MakeRedirectURL(string baseUri, string state, string authCode)
        {
            if (baseUri == null)
            {
                throw new ArgumentNullException(nameof(baseUri));
            }

            if (state == null)
            {
                throw new ArgumentNullException(nameof(state));
            }

            if (authCode == null)
            {
                throw new ArgumentNullException(nameof(authCode));
            }

            var parms = new Dictionary<string, string>()
            {
                ["code"] = authCode,
                ["state"] = state,
            };
            return new Uri(QueryHelpers.AddQueryString($"{baseUri}/cb", parms));
        }
    }
}
