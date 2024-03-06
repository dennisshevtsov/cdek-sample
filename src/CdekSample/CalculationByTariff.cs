// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using System.Text.Json.Serialization;

namespace CdekSample;

/// <summary>
/// Расчет по коду тарифа
/// </summary>
/// <param name="Code">Код тарифа (подробнее см. приложение 2)</param>
/// <param name="Name">Название тарифа на языке вывода</param>
/// <param name="Description">Описание тарифа на языке вывода</param>
/// <param name="DeliveryMode">Режим тарифа (подробнее см. приложение 3)</param>
/// <param name="DeliverySum">Стоимость доставки</param>
/// <param name="PeriodMin">Минимальное время доставки (в рабочих днях)</param>
/// <param name="PeriodMax">Максимальное время доставки (в рабочих днях)</param>
/// <param name="CalendarMin">Минимальное время доставки (в календарных днях)</param>
/// <param name="CalendarMax">Максимальное время доставки (в календарных днях)</param>
public sealed record class CalculationByTariff
(
  [property: JsonPropertyName("tariff_code")]        int          Code,
  [property: JsonPropertyName("tariff_name")]        string       Name,
  [property: JsonPropertyName("tariff_description")] string       Description,
  [property: JsonPropertyName("delivery_mode")]      DeliveryMode DeliveryMode,
  [property: JsonPropertyName("delivery_sum")]       float        DeliverySum,
  [property: JsonPropertyName("period_min")]         int          PeriodMin,
  [property: JsonPropertyName("period_max")]         int          PeriodMax,
  [property: JsonPropertyName("calendar_min")]       int?         CalendarMin,
  [property: JsonPropertyName("calendar_max")]       int?         CalendarMax
);
