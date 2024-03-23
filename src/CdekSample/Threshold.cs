// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using System.Text.Json.Serialization;

namespace CdekSample;

public readonly record struct Threshold
(
  [property: JsonPropertyName("threshold")] int Value,
  [property: JsonPropertyName("sum")] decimal Sum,

  [property: JsonPropertyName("vat_sum"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
  decimal? VatSum = null,

  [property: JsonPropertyName("vat_rate"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
  VatRate? VatRate = null
);
