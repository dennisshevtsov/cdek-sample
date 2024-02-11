// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using System.Text.Json.Serialization;

namespace CdekSample;

public sealed record class Phone
(
  [property: JsonPropertyName("number")]     string  Number,
  [property: JsonPropertyName("additional")] string? Additional
);
