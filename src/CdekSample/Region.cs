﻿// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using System.Text.Json.Serialization;

namespace CdekSample;

/// <summary>
/// Response to List of Regions request
/// </summary>
/// <param name="CountryCode">Country code in the format ISO_3166-1_alpha-2</param>
/// <param name="Country">Region country name</param>
/// <param name="Prefix">Region name</param>
/// <param name="RegionCode">Region code in the CDEK IS</param>
public sealed record class Region
(
  [property: JsonPropertyName("country_code")] string CountryCode,
  [property: JsonPropertyName("country")]      string Country,
  [property: JsonPropertyName("region")]       string Prefix,
  [property: JsonPropertyName("region_code")]  int?   RegionCode
);
