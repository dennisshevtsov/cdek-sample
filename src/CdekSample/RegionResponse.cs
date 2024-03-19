// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using System.Text.Json.Serialization;

namespace CdekSample;

/// <summary>
/// Response to List of Regions request
/// </summary>
/// <param name="CountryCode">Country code in the format ISO_3166-1_alpha-2</param>
/// <param name="Country">Region country name</param>
/// <param name="Region">Region name</param>
/// <param name="RegionCode">Region code in the CDEK IS</param>
public sealed record class RegionResponse
(
  [property: JsonPropertyName("country_code")] CountryCode  CountryCode,
  [property: JsonPropertyName("country")]      string       Country,
  [property: JsonPropertyName("region")]       string       Region,
  [property: JsonPropertyName("region_code")]  RegionCode?  RegionCode
);
