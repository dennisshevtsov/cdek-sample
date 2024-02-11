// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using System.Text.Json.Serialization;

namespace CdekSample;

public sealed record class Region
(
  [property: JsonPropertyName("country_code")] string CountryCode,
  [property: JsonPropertyName("country")]      string Country,
  [property: JsonPropertyName("region")]       string Prefix,
  [property: JsonPropertyName("region_code")]  int?   RegionCode
);
