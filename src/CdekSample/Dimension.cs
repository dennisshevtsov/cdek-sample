// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using System.Text.Json.Serialization;

namespace CdekSample;

/// <summary>
/// List of locker dimensions (only for type = POSTAMAT)
/// </summary>
/// <param name="Width">Width (in centimeters)</param>
/// <param name="Height">Height (in centimeters)</param>
/// <param name="Depth">Depth (in centimeters)</param>
public sealed record class Dimension
(
  [property: JsonPropertyName("width")]  float Width,
  [property: JsonPropertyName("height")] float Height,
  [property: JsonPropertyName("depth")]  float Depth
);
