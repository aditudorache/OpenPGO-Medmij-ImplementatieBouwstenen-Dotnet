# Build stage
FROM microsoft/dotnet:2.1-sdk AS build-env

WORKDIR /src

# restore
COPY MedMij/MedMij.csproj ./MedMij/
RUN dotnet restore MedMij/MedMij.csproj
COPY MedMij.Xunit/MedMij.Xunit.csproj ./MedMij.Xunit/
RUN dotnet restore MedMij.Xunit/MedMij.Xunit.csproj

# copy src
COPY MedMij ./MedMij
COPY MedMij.Xunit ./MedMij.Xunit/

# test
RUN dotnet test MedMij.Xunit/MedMij.Xunit.csproj
