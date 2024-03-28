// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using System.Text.Json.Serialization;

namespace CdekSample;

public sealed record class Seller
(
  string?       Name = null,
  string?        Inn = null,
  string?      Phone = null,
  int? OwnershipForm = null,
  string?    Address = null
)
{
  [JsonPropertyName("name")]
  [JsonPropertyOrder(1)]
  [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
  public string? Name { get; set; } = Name;

  [JsonPropertyName("inn")]
  [JsonPropertyOrder(2)]
  [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
  public string? Inn { get; set; } = Inn;

  [JsonPropertyName("phone")]
  [JsonPropertyOrder(3)]
  [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
  public string? Phone { get; set; } = Phone;

  [JsonPropertyName("ownership_form")]
  [JsonPropertyOrder(4)]
  [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
  public int? OwnershipForm { get; set; } = OwnershipForm;

  [JsonPropertyName("address")]
  [JsonPropertyOrder(5)]
  [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
  public string? Address { get; set; } = Address;
}
