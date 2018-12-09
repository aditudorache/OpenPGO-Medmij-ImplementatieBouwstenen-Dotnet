# Medmij dotnet

The Medmij for .Net git project is a .NET component that implements the base functionality for accessing the MedMij data.
It consists of 3 projects:
* `MedMij` - the library component. This can be included and used in .NET projects that acces MedMij data
* `MedMij.Xunit` - the unittests project
* `MedMij.Example` - the example project with working code for usage of the MedMij component


## Installation

First clone, restore and build  repo:

```shell
$ PATH_TO_CLONE=~/example/medmij-dotnet
$ git clone https://github.com/Zorgdoc/medmij-dotnet.git $PATH_TO_CLONE
Cloning into ...
...
$

$ dotnet restore
...

$ dotnet build
...
```

To run the Example project:

```shell
$ cd $PATH_TO_CLONE/MedMij.Example
$ dotnet run
...
```


To add a reference to your project

```shell
$ cd path_to_your_project/
$ dotnet add reference $PATH_TO_CLONE/MedMij
Reference `..\medmij-donet\MedMij\MedMij.csproj` added to the project.
```

## How to use

See the MedMij.Example project for working code examples for each scenario


## Testing

For the unittests is Xunit test framework used.

To run the tests use

```shell
$ cd $PATH_TO_CLONE/MedMij.Xunit
$ dotnet test
...
```

or

```shell
$ dotnet watch test
...
```
