// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using System.Text.Json.Serialization;

namespace CdekSample;

public sealed record class TariffCode
(
  [property: JsonPropertyName("tariff_code")]        int    Code,
  [property: JsonPropertyName("tariff_name")]        string Name,
  [property: JsonPropertyName("tariff_description")] string Description,
  [property: JsonPropertyName("delivery_mode")]      int    DeliveryMode,
  [property: JsonPropertyName("delivery_sum")]       float  DeliverySum,
  [property: JsonPropertyName("period_min")]         int    PeriodMin,
  [property: JsonPropertyName("period_max")]         int    PeriodMax,
  [property: JsonPropertyName("calendar_min")]       int?   CalendarMin,
  [property: JsonPropertyName("calendar_max")]       int?   CalendarMax
);
