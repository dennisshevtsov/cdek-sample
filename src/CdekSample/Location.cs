// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using System.Text.Json.Serialization;

namespace CdekSample;

/// <summary>
/// Address
/// </summary>
/// <param name="CountryCode">Country code in the ISO_3166-1_alpha-2 format</param>
/// <param name="RegionCode">Region code from the CDEK base</param>
/// <param name="Region">Region name</param>
/// <param name="CityCode">CDEK location code ("List of Cities" method)</param>
/// <param name="City">City name</param>
/// <param name="FiasGuid">City code FIAS</param>
/// <param name="PostalCode">Postcode</param>
/// <param name="Longitude">Coordinates of location (longitude) in degrees</param>
/// <param name="Latitude">Coordinates of location (latitude) in degrees</param>
/// <param name="Address">Address (street, house, office) in the specified city</param>
/// <param name="AddressFull">Full address, including country, region, city, etc.</param>
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
