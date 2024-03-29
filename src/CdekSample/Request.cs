// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using System.Text.Json.Serialization;

namespace CdekSample;

public sealed record class Request
(
  [property: JsonPropertyName("request_uuid")] Guid? Id,
  [property: JsonPropertyName("type")] RequestType Type,
  [property: JsonPropertyName("date_time")] DateTime DateTime,
  [property: JsonPropertyName("state")] RequestState State
);
