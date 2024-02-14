// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using System.Text.Json.Serialization;

namespace CdekSample;

public sealed record class Package
(
  [property: JsonPropertyName("weight")] int  Weight,
  [property: JsonPropertyName("length")] int? Length = null,
  [property: JsonPropertyName("width")]  int? Width  = null,
  [property: JsonPropertyName("height")] int? Height = null
);
