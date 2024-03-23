// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using System.Text.Json.Serialization;

namespace CdekSample;

public readonly record struct Threshold(int Value, decimal Sum, decimal? VatSum = null, VatRate? VatRate = null)
{
  [JsonPropertyName("threshold")]
  [JsonPropertyOrder(3)]
  [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
  public int Value { get; } = Value;

  [JsonPropertyName("sum")]
  [JsonPropertyOrder(3)]
  [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
  public decimal Sum { get; } = Sum;

  [JsonPropertyName("vat_sum")]
  [JsonPropertyOrder(3)]
  [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
  public decimal? VatSum { get; } = VatSum;

  [JsonPropertyName("vat_rate")]
  [JsonPropertyOrder(4)]
  [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
  public VatRate? VatRate { get; } = VatRate;
}
