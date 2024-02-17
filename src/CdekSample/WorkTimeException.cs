// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using System.Text.Json.Serialization;

namespace CdekSample;

/// <summary>
/// Office schedule exceptions
/// </summary>
/// <param name="Date">Date</param>
/// <param name="Time">The period of work on the specified date. If they don’t work on this day, it is not displayed</param>
/// <param name="IsWorking">Sign of a working / non-working day on a specified date</param>
public sealed record class WorkTimeException
(
  [property: JsonPropertyName("date")]       DateTimeOffset Date,
  [property: JsonPropertyName("time")]       string?        Time,
  [property: JsonPropertyName("is_working")] bool           IsWorking
);
