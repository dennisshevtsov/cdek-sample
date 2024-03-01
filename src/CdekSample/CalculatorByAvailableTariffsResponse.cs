// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using System.Text.Json.Serialization;

namespace CdekSample;

/// <summary>
/// Ответ на расчет по доступным тарифам
/// </summary>
/// <param name="TariffCodes">Доступные тарифы</param>
public sealed record class CalculatorByAvailableTariffsResponse
(
  [property: JsonPropertyName("tariff_codes")] TariffCode[]? TariffCodes
);
