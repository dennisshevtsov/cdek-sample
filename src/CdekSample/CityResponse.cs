// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using System.Text.Json.Serialization;

namespace CdekSample;

/// <summary>
/// Response to List of Cities request
/// </summary>
/// <param name="Code">CDEK location code</param>
/// <param name="CityName">City name</param>
/// <param name="FiasGuid">City code according to the Federal Information Address System</param>
/// <param name="CityUuid"></param>
/// <param name="CountryCode">Country code in the format ISO_3166-1_alpha-2</param>
/// <param name="Country">City country name</param>
/// <param name="Region">Region name</param>
/// <param name="RegionCode">Region code in the CDEK IS</param>
/// <param name="SubRegion">Name of region's district</param>
/// <param name="Longitude">Latitude</param>
/// <param name="Latitude">Longitude</param>
/// <param name="TimeZone">City timezone</param>
/// <param name="PaymentLimit">
///  <para>Cash-on-delivery amount limit, possible values:</para>
///  <para>1 – no limit;</para>
///  <para>0 – cash on delivery is not accepted;</para>
///  <para>positive value – the cash-on-delivery amount does not exceed this value.</para>
/// </param>
public sealed record class City
(
  [property: JsonPropertyName("code")]          int     Code,
  [property: JsonPropertyName("city")]          string  CityName,
  [property: JsonPropertyName("fias_guid")]     Guid    FiasGuid,
  [property: JsonPropertyName("city_uuid")]     Guid    CityUuid,
  [property: JsonPropertyName("country_code")]  string  CountryCode,
  [property: JsonPropertyName("country")]       string  Country,
  [property: JsonPropertyName("region")]        string  Region,
  [property: JsonPropertyName("region_code")]   int?    RegionCode,
  [property: JsonPropertyName("sub_region")]    string? SubRegion,
  [property: JsonPropertyName("longitude")]     float?  Longitude,
  [property: JsonPropertyName("latitude")]      float?  Latitude,
  [property: JsonPropertyName("time_zone")]     string? TimeZone,
  [property: JsonPropertyName("payment_limit")] float   PaymentLimit
);
