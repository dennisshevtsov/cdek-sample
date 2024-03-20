// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using System.Text.Json.Serialization;

namespace CdekSample;

public record class OrderRequest
(
  TariffCode                TariffCode,
  OrderType?                      Type = null,
  AdditionalOrderType? AdditionalTypes = null,
  string?                       Number = null
)
{
  [JsonPropertyName("type")]
  [JsonPropertyOrder(1)]
  [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
  public OrderType? Type { get; } = Type;

  [JsonPropertyName("additional_order_types")]
  [JsonPropertyOrder(2)]
  [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
  public AdditionalOrderType? AdditionalTypes { get; } = AdditionalTypes;

  [JsonPropertyName("number")]
  [JsonPropertyOrder(3)]
  [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
  public string? Number { get; } = Number;

  [JsonPropertyName("tariff_code")]
  [JsonPropertyOrder(4)]
  [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
  public TariffCode TariffCode { get; } = TariffCode;
}
