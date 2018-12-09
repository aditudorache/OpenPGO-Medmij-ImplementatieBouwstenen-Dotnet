# Medmij dotnet

## Installation

First clone the repo:

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

See the MedMij.Example project for code examples


## Testing

```shell
$ cd $PATH_TO_CLONE/MedMij.Xunit
$ dotnet watch test
...
```
