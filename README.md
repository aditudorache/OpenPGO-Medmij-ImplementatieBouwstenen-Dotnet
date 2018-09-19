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
using MedMij;

namespace example_medmij
{
    class Program
    {
        static void Main(string[] args)
        {
            var zal = MedMij.ZorgaanbiedersCollection.FromXMLData("...");
            var uri = zal.GetByName("test").Gegevensdiensten["4"].AuthorizationEndpointUri;
            System.Console.WriteLine(uri);
        }
    }
}
```

Then run your program:

```shell
$ dotnet run

Unhandled Exception: System.Xml.XmlException: Data at the root level is invalid. Line 1, position 1.
```
