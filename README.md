# WeatherSuggest

## Overview

Simple Weather App that displays the current weather of a city and gives activity recommendations.

Developed with Blazor WebAssembly and ASP.NET Core.

.NET Version: 7.0

## Deployment

https://weathersuggest.azurewebsites.net/

## Table of Contents

- [Installation](#installation)
- [Configuration](#configuration)
- [Testing](#testing)
- [Packages Used](#packages-used)
- [API Used](#api-used)

## Installation

```bash
# Example installation command
git clone https://github.com/jannik-ebert/WeatherSuggest.git
cd WeatherSuggest
dotnet build
dotnet run
```

## Configuration

Generate API Key: https://openweathermap.org/api

```js
// Example configuration file (appsettings.json)
{
  "ApiSettings": {
    "ApiKey": "your-api-key"
  }
}
```

## Testing

```bash
# Example test command
dotnet test
```

## Packages Used

* Blazor.Bootstrap: Version 1.10.4
* Newtonsoft.Json: Version 13.0.3
* AutoMapper: Version 12.0.1
* bunit.web: Version 1.26.64

## API Used

OpenWeatherMap
  * [Weather API](https://openweathermap.org/api)
  * [Geocoding API](https://openweathermap.org/api/geocoding-api)

