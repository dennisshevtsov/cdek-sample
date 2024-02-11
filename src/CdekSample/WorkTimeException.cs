// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using System.Text.Json.Serialization;

namespace CdekSample;

public sealed record class WorkTimeException
(
  [property: JsonPropertyName("date")]       DateTimeOffset Date,
  [property: JsonPropertyName("time")]       string?        Time,
  [property: JsonPropertyName("is_working")] bool           IsWorking
);
