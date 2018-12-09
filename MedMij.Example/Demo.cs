// Copyright (c) Adrian Tudorache. All Rights Reserved. Licensed under the AGPLv3 (see License.txt for details).

using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace MedMij.Example
{
    public static class Demo
    {
        async public static Task Run()
        {
            const string WHITELIST_URL = "https://afsprakenstelsel.medmij.nl/download/attachments/22348803/MedMij_Whitelist_example.xml?version=1&modificationDate=1538136425019&api=v2";
            const string ZAL_URL = "https://afsprakenstelsel.medmij.nl/download/attachments/22348803/MedMij_Zorgaanbiederslijst_example.xml?version=1&modificationDate=1538136425025&api=v2";
            const string OCL_URL = "https://afsprakenstelsel.medmij.nl/download/attachments/22348803/MedMij_OAuthclientlist_example.xml?version=1&modificationDate=1538136425022&api=v2";
            const string GNL_URL = "https://afsprakenstelsel.medmij.nl/download/attachments/22348803/MedMij_Gegevensdienstnamenlijst_example.xml?version=1&modificationDate=1538136425017&api=v2";

            var serviceCollection = new ServiceCollection().AddHttpClient();
            var factory = serviceCollection.BuildServiceProvider().GetRequiredService<IHttpClientFactory>();

            using (var c = new HttpClient())
            {
                var whlxml = c.GetStringAsync(WHITELIST_URL);
                var zalxml = c.GetStringAsync(ZAL_URL);
                var oclxml = c.GetStringAsync(OCL_URL);
                var gnlxml = c.GetStringAsync(GNL_URL);

                Console.WriteLine($"OCL: \n=================");
                var ocl = MedMij.OAuthclientlist.FromXMLData(await oclxml);
                var oc = ocl.GetByOrganisatienaam("De Enige Echte PGO");
                Console.WriteLine($"OAuth hostname: {oc.Hostname}\n");


                Console.WriteLine($"Whitelist: \n=================");
                var whitelist = MedMij.Whitelist.FromXMLData(await whlxml);
                Console.WriteLine($"Is {oc.Hostname} on whitelist: {whitelist.IsMedMijNode(oc.Hostname)}\n");


                Console.WriteLine($"ZAL: \n=================");
                var zal = MedMij.Zorgaanbiederslijst.FromXMLData(await zalxml);
                var za = zal.GetByName("umcharderwijk@medmij");
                var geg = za.Gegevensdiensten["4"];
                Console.WriteLine($"AuthorizationEndpointUri: {geg.AuthorizationEndpointUri}");
                Console.WriteLine($"TokenEndpointUri: {geg.TokenEndpointUri}\n");

                Console.WriteLine($"GNL: \n=================");
                var gnl = MedMij.Gegevensdienstnamenlijst.FromXMLData(await gnlxml);
                var gn = gnl.GetMapIdToName()["2"];
                Console.WriteLine($"Weergavenaam : {gn}");

                Console.WriteLine($"Authorization: \n=================");
                var zaAuthenticationUri = MedMij.Oauth.PGOOAuth.MakeAuthUri(
                        gegevensdienst: geg,
                        clientId: oc.Hostname,
                        redirectUri: "https://pgo.example.com/oauth",
                        state: "abcd");
                Console.WriteLine("Link to ZA:\n{0}\n", zaAuthenticationUri);

                var pgoRedirectUrl = MedMij.Oauth.ZAOAuth.MakeRedirectURL(
                        baseUri: "https://pgo.example.com/oauth",
                        state: "abc",
                        authCode: "xyz");
                Console.WriteLine("Redirect to PGO:\n{0}\n", pgoRedirectUrl);

                Console.WriteLine("Get token:");
                var tokenTask = MedMij.Oauth.PGOOAuth.GetAccessToken(
                    gegevensdienst: geg,
                    authorizationCode: "xyz",
                    redirectUri: "https://pgo.example.com/oauth",
                    httpClientFactory: factory
                );
                await Task.Delay(100);
                Console.WriteLine($"Task status: {tokenTask.Status}");
                Console.WriteLine($"Task exception: {tokenTask.Exception?.Message ?? "none."}");
            }
        }
    }
}
