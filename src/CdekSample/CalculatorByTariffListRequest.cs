// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using System.Text.Json.Serialization;

namespace CdekSample;

public sealed record class CalculatorByTariffListRequest
(
  [property: JsonPropertyName("date")]                   DateTimeOffset?    Date,
  [property: JsonPropertyName("type")]                   int?               Type,
  [property: JsonPropertyName("additional_order_types")] int[]?             AdditionalOrderTypes,
  [property: JsonPropertyName("currency")]               int?               Currency,
  [property: JsonPropertyName("lang")]                   string?            Lang,
  [property: JsonPropertyName("from_location")]          CalculatorLocation FromLocation,
  [property: JsonPropertyName("to_location")]            CalculatorLocation ToLocation,
  [property: JsonPropertyName("packages")]               Package[]          Packages
);
