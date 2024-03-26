// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using System.Text.Json.Serialization;

namespace CdekSample;

public sealed record class Item
(
  string              Name,
  string           WareKey,
  Money            Payment,
  float               Cost,
  int               Amount,
  int               Weight,
  int?         WeightGross = null,
  string?         NameI18n = null,
  string?            Brand = null,
  CountryCode? CountryCode = null,
  string?         Material = null,
  bool?            WifiGsm = null,
  string?              Url = null
)
{
  [JsonPropertyName("name")]
  [JsonPropertyOrder(1)]
  public string Name { get; } = Name;

  [JsonPropertyName("ware_key")]
  [JsonPropertyOrder(2)]
  public string WareKey { get; } = WareKey;

  [JsonPropertyName("payment")]
  [JsonPropertyOrder(3)]
  public Money Payment { get; } = Payment;

  [JsonPropertyName("cost")]
  [JsonPropertyOrder(4)]
  public float Cost { get; } = Cost;

  [JsonPropertyName("amount")]
  [JsonPropertyOrder(7)]
  public int Amount { get; } = Amount;

  [JsonPropertyName("weight")]
  [JsonPropertyOrder(5)]
  public int Weight { get; } = Weight;

  [JsonPropertyName("weight_gross")]
  [JsonPropertyOrder(6)]
  [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
  public int? WeightGross { get; } = WeightGross;

  [JsonPropertyName("name_i18n")]
  [JsonPropertyOrder(8)]
  [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
  public string? NameI18n { get; } = NameI18n;

  [JsonPropertyName("brand")]
  [JsonPropertyOrder(9)]
  [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
  public string? Brand { get; } = Brand;

  [JsonPropertyName("country_code")]
  [JsonPropertyOrder(10)]
  [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
  public CountryCode? CountryCode { get; } = CountryCode;

  [JsonPropertyName("material")]
  [JsonPropertyOrder(11)]
  [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
  public string? Material { get; } = Material;

  [JsonPropertyName("wifi_gsm")]
  [JsonPropertyOrder(12)]
  [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
  public bool? WifiGsm { get; } = WifiGsm;

  [JsonPropertyName("url")]
  [JsonPropertyOrder(13)]
  [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
  public string? Url { get; } = Url;
}
