![Nuget](https://img.shields.io/nuget/v/Orng.Starwatch.API)

# Orng.Starwatch.API
Minimal Starwatch API interface in .NET 6.0.

Work in progress, implementations subject to change at any time.
Nuget is [here](https://www.nuget.org/packages/Orng.Starwatch.API).

## Setup
In the Nuget Package Manager, search for Orng.Starwatch.API and install the latest version,
or in the package manager console use ``Install-Package Orng.Starwatch.API``

## Example
```cs
using Orng.Starwatch.API;

var api = new ApiClient("https://starwatch.somesite.com:8000", "bot_example", "postman");
api.SendRconCommand("say Hello World!");
```

