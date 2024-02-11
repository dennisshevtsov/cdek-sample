// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using System.Text.Json.Serialization;

namespace CdekSample;

public sealed record class WorkTime
(
  [property: JsonPropertyName("day")]  int    Day,
  [property: JsonPropertyName("time")] string Time
);
