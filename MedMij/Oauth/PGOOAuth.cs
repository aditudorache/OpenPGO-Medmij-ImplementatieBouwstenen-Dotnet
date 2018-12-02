// Copyright (c) Adrian Tudorache. All Rights Reserved. Licensed under the AGPLv3 (see License.txt for details).

namespace MedMij.Oauth
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.WebUtilities;

    /// <summary>
    /// Methodes voor het implementeren van OAuth aan de kant van de PGO
    /// </summary>
    public static class PGOOAuth
    {
        /// <summary>
        /// Geeft een URL waarmee een zorggebruiker een authorization-code kan ophalen bij een zorgaanbieder
        /// </summary>
        /// <returns>De Uri waar de client gaat inloggen.</returns>
        /// <param name="gegevensdienst">De gegevensdienst waar de zorggebruiker gaat inloggen.</param>
        /// <param name="clientId">De clientId van deze PGO.</param>
        /// <param name="redirectUri">De url waar de client weer terugkomt met een authorization-code.</param>
        /// <param name="state">Applicatie-specifieke state. Gebruik dit om de client weer te herkennen bij terugkomst.</param>
        public static Uri MakeAuthUri(IGegevensdienst gegevensdienst, string clientId, string redirectUri, string state)
        {
            if (gegevensdienst == null)
            {
                throw new ArgumentNullException(nameof(gegevensdienst));
            }

            if (clientId == null)
            {
                throw new ArgumentNullException(nameof(clientId));
            }

            if (redirectUri == null)
            {
                throw new ArgumentNullException(nameof(redirectUri));
            }

            if (state == null)
            {
                throw new ArgumentNullException(nameof(state));
            }

            var baseUri = gegevensdienst.AuthorizationEndpointUri;
            var prefix = gegevensdienst.Zorgaanbiedernaam.Replace("@medmij", string.Empty);
            var scope = $"{prefix}~{gegevensdienst.Id}";
            var parms = new Dictionary<string, string>()
            {
                ["response_type"] = "code",
                ["client_id"] = clientId,
                ["redirect_uri"] = redirectUri,
                ["scope"] = scope,
                ["state"] = state,
            };
            return new Uri(QueryHelpers.AddQueryString(baseUri.ToString(), parms));
        }

        /// <summary>
        /// Haalt een access token op bij de ZA
        /// </summary>
        /// <param name="gegevensdienst">De gegevensdienst waarvoor je de access token nodig hebt</param>
        /// <param name="authorizationCode">De authorization-code die je hebt ontvangen van de zorggebruiker</param>
        /// <param name="redirectUri">Dezelfde waarde als in de voorafgaande authorization request</param>
        /// <param name="httpClientFactory">Wordt gebruikt om een HTTP-verbinding met de ZA op te zetten</param>
        /// <param name="cancellationToken">Gebruik dit om de HTTP-request te annuleren</param>
        /// <returns>De access token om bij de patient gegevens op te kunnen halen</returns>
        public static async Task<string> GetAccessToken(
            IGegevensdienst gegevensdienst,
            string authorizationCode,
            string redirectUri,
            IHttpClientFactory httpClientFactory,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            if (gegevensdienst == null)
            {
                throw new ArgumentNullException(nameof(gegevensdienst));
            }

            if (authorizationCode == null)
            {
                throw new ArgumentNullException(nameof(authorizationCode));
            }

            if (redirectUri == null)
            {
                throw new ArgumentNullException(nameof(redirectUri));
            }

            if (httpClientFactory == null)
            {
                throw new ArgumentNullException(nameof(httpClientFactory));
            }

            var parms = new Dictionary<string, string>()
            {
                ["grant_type"] = "authorization_code",
                ["code"] = authorizationCode,
                ["client_id"] = string.Empty,
                ["redirect_uri"] = redirectUri.ToString(),
            };

            var baseUri = gegevensdienst.TokenEndpointUri;
            var url = new Uri(QueryHelpers.AddQueryString(baseUri.ToString(), parms));

            using (var httpClient = httpClientFactory.CreateClient())
            {
                var res = await httpClient.PostAsync(url, null, cancellationToken: cancellationToken)
                                          .ConfigureAwait(false);
                return await res.Content.ReadAsStringAsync().ConfigureAwait(false);
            }
        }
    }
}
