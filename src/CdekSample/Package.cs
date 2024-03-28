// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using System.Text.Json.Serialization;

namespace CdekSample;

public sealed record class Package
(
  string   Number,
  int      Weight,
  int?     Length = null,
  int?      Width = null,
  int?     Height = null,
  string? Comment = null,
  Item[]?   Items = null
)
{
  [JsonPropertyName("number")]
  [JsonPropertyOrder(1)]
  public string Number { get; } = Number;

  [JsonPropertyName("weight")]
  [JsonPropertyOrder(2)]
  public int Weight { get; } = Weight;

  [JsonPropertyName("length")]
  [JsonPropertyOrder(3)]
  [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
  public int? Length { get; } = Length;

  [JsonPropertyName("width")]
  [JsonPropertyOrder(4)]
  [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
  public int? Width { get; } = Width;

  [JsonPropertyName("height")]
  [JsonPropertyOrder(5)]
  [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
  public int? Height { get; } = Height;

  [JsonPropertyName("comment")]
  [JsonPropertyOrder(6)]
  [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
  public string? Comment { get; } = Comment;

  [JsonPropertyName("items")]
  [JsonPropertyOrder(6)]
  [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
  public Item[]? Items { get; } = Items;
}
