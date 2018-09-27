# Medmij dotnet

## Installation

First clone the repo:

```shell
$ PATH_TO_CLONE=~/example/medmij-donet
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

Add `using MedMij;` to your `Program.cs` and use the API:

```csharp
using System;
using System.Net.Http;
using System.Threading.Tasks;
using MedMij;

namespace example_medmij
{
    class Program
    {
        async static Task Main(string[] args)
        {
            const string WHITELIST_URL = "http://gids.samenbeter.org/openpgoexamples/1.0/whitelist-voorbeeld-v1.0.xml";
            const string ZAL_URL = "http://gids.samenbeter.org/openpgoexamples/1.0/zorgaanbiederslijst-voorbeeld-v1.0.xml";
            const string OCL_URL = "http://gids.samenbeter.org/openpgoexamples/1.0/oauthclientlist-voorbeeld-v1.0.xml";

            using (var c = new HttpClient())
            {
                var whlxml = c.GetStringAsync(WHITELIST_URL);
                var zalxml = c.GetStringAsync(ZAL_URL);
                var oclxml = c.GetStringAsync(OCL_URL);

                var whitelist = Whitelist.FromXMLData(await whlxml);
                Console.WriteLine(whitelist.Contains("test"));

                var zal = ZorgaanbiedersCollection.FromXMLData(await zalxml);
                var za = zal.GetByName("umcharderwijk@medmij");
                Console.WriteLine(za.Gegevensdiensten["4"].AuthorizationEndpointUri);

                var ocl = OAuthClientCollection.FromXMLData(await oclxml);
                var oc = ocl.GetByOrganisatienaam("De Enige Echte PGO");
                Console.WriteLine(oc.Hostname);
            }
        }
    }
}
```

Then run your program:

```shell
$ dotnet run
False
https://medmij.za982.xisbridge.net/oauth/authorize
medmij.deenigeechtepgo.nl
```
