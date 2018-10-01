# Medmij dotnet

## Installation

First clone the repo:

```shell
$ PATH_TO_CLONE=~/example/medmij-dotnet
$ git clone https://github.com/Zorgdoc/medmij-dotnet.git $PATH_TO_CLONE
Cloning into ...
...
$
```

Then start a new project and add the reference:

```shell
$ dotnet new console -o example_medmij
The template "Console Application" was created successfully.
...

$ cd example_medmij/
$ dotnet add reference $PATH_TO_CLONE/MedMij
Reference `..\medmij-donet\MedMij\MedMij.csproj` added to the project.
```

## Usage

Use the API in `Program.cs`:

```csharp
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace example_medmij
{
    class Program
    {
        async static Task Main(string[] args)
        {
            const string WHITELIST_URL = "http://gids.samenbeter.org/openpgoexamples/1.0/whitelist-voorbeeld-v1.0.xml";
            const string ZAL_URL = "http://gids.samenbeter.org/openpgoexamples/1.0/zorgaanbiederslijst-voorbeeld-v1.0.xml";
            const string OCL_URL = "http://gids.samenbeter.org/openpgoexamples/1.0/oauthclientlist-voorbeeld-v1.0.xml";

            var serviceCollection = new ServiceCollection().AddHttpClient();
            var factory = serviceCollection.BuildServiceProvider().GetRequiredService<IHttpClientFactory>();

            using (var c = new HttpClient())
            {
                var whlxml = c.GetStringAsync(WHITELIST_URL);
                var zalxml = c.GetStringAsync(ZAL_URL);
                var oclxml = c.GetStringAsync(OCL_URL);

                var ocl = MedMij.OAuthClientCollection.FromXMLData(await oclxml);
                var oc = ocl.GetByOrganisatienaam("De Enige Echte PGO");
                Console.WriteLine($"OAuth hostname: {oc.Hostname}\n");

                var whitelist = MedMij.Whitelist.FromXMLData(await whlxml);
                Console.WriteLine($"Is {oc.Hostname} on whitelist: {whitelist.Contains(oc.Hostname)}\n");

                var zal = MedMij.ZorgaanbiedersCollection.FromXMLData(await zalxml);
                var za = zal.GetByName("umcharderwijk@medmij");
                var geg = za.Gegevensdiensten["4"];
                Console.WriteLine($"AuthorizationEndpointUri: {geg.AuthorizationEndpointUri}\n");

                Console.WriteLine(
                    "Link to ZA:\n{0}\n",
                    MedMij.PGOOAuth.MakeAuthUri(
                        gegevensdienst: geg,
                        clientId: oc.Hostname,
                        redirectUri: "https://pgo.example.com/oauth",
                        state: "abcd"));

                Console.WriteLine(
                    "Redirect to PGO:\n{0}\n",
                    MedMij.ZAOAuth.MakeRedirectURL(
                        baseUri: "https://pgo.example.com/oauth",
                        state: "abc",
                        authCode: "xyz"));

                Console.WriteLine("Get token:");
                var tokenTask = MedMij.PGOOAuth.GetAccessToken(
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


```

Then run your program:

```shell
$ dotnet run
OAuth hostname: medmij.deenigeechtepgo.nl

Is medmij.deenigeechtepgo.nl on whitelist: True

AuthorizationEndpointUri: https://medmij.za982.xisbridge.net/oauth/authorize

Link to ZA:
https://medmij.za982.xisbridge.net/oauth/authorize?response_type=code&client_id=medmij.deenigeechtepgo.nl&redirect_uri=https%3A%2F%2Fpgo.example.com%2Foauth&scope=umcharderwijk~4&state=abcd

Redirect to PGO:
https://pgo.example.com/oauth/cb?code=xyz&state=abc

Get token:
Task status: Faulted
Task exception: One or more errors occurred. (No such device or address)
```
