// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using System.Text.Json.Serialization;

namespace CdekSample;

public sealed record class CalculatorLocation
(
  [property: JsonPropertyName("code")]         int?    Code        = null,
  [property: JsonPropertyName("postal_code")]  string? PostalCode  = null,
  [property: JsonPropertyName("country_code")] string? CountryCode = null,
  [property: JsonPropertyName("city")]         string? City        = null,
  [property: JsonPropertyName("address")]      string? Address     = null
);
