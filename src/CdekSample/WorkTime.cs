// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using System.Text.Json.Serialization;

namespace CdekSample;

/// <summary>
/// Opening hours for every day
/// </summary>
/// <param name="Day">Ordinal number of a day (Monday = 1, Sunday = 7)</param>
/// <param name="Time">Opening hours for these days. If the pickup point does not work on this day, no period is specified</param>
public sealed record class WorkTime
(
  [property: JsonPropertyName("day")]  int    Day,
  [property: JsonPropertyName("time")] string Time
);
