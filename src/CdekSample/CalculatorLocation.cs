// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using System.Text.Json.Serialization;

namespace CdekSample;

public sealed record class CalculatorLocation
(
  [property: JsonPropertyName("code")]         int     Code,
  [property: JsonPropertyName("postal_code")]  string  PostalCode,
  [property: JsonPropertyName("country_code")] string? CountryCode,
  [property: JsonPropertyName("city")]         string? City,
  [property: JsonPropertyName("address")]      string  Address
);
