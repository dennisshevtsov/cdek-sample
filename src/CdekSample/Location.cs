// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using System.Text.Json.Serialization;

namespace CdekSample;

public sealed record class Location
(
  [property: JsonPropertyName("country_code")] string  CountryCode,
  [property: JsonPropertyName("region_code")]  int     RegionCode,
  [property: JsonPropertyName("region")]       string  Region,
  [property: JsonPropertyName("city_code")]    int     CityCode,
  [property: JsonPropertyName("city")]         string  City,
  [property: JsonPropertyName("fias_guid")]    Guid?   FiasGuid,
  [property: JsonPropertyName("postal_сode")]  string? PostalCode,
  [property: JsonPropertyName("longitude")]    float   Longitude,
  [property: JsonPropertyName("latitude")]     float   Latitude,
  [property: JsonPropertyName("address")]      string  Address,
  [property: JsonPropertyName("address_full")] string  AddressFull
);
