// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using System.Text.Json.Serialization;

namespace CdekSample;

public sealed record class CalculatorByTariffCodeResponse
(
  [property: JsonPropertyName("delivery_sum")]                  float DeliverySum,
  [property: JsonPropertyName("period_min")]                      int PeriodMin,
  [property: JsonPropertyName("period_max")]                      int PeriodMax,
  [property: JsonPropertyName("weight_calc")]                     int WeightCalc,
  [property: JsonPropertyName("calendar_min")]                   int? CalendarMin,
  [property: JsonPropertyName("calendar_max")]                   int? CalendarMax,
  [property: JsonPropertyName("services")] AdditionalServiceResponse? Services,
  [property: JsonPropertyName("total_sum")]                     float TotalSum,
  [property: JsonPropertyName("currency")]                   Currency Currency
);
