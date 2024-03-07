// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using System.Text.Json.Serialization;

namespace CdekSample;

/// <summary>
/// Запрос на получение списка населенных пунктов
/// </summary>
/// <param name="CountryCodes">Массив кодов стран в формате  ISO_3166-1_alpha-2</param>
/// <param name="RegionCode">Код региона СДЭК</param>
/// <param name="FiasGuid">Уникальный идентификатор ФИАС населенного пункта</param>
/// <param name="PostalCode">Почтовый индекс</param>
/// <param name="Code">Код населенного пункта СДЭК</param>
/// <param name="City">Название населенного пункта. Должно соответствовать полностью</param>
/// <param name="Size">Ограничение выборки результата. По умолчанию 1000</param>
/// <param name="Page">Номер страницы выборки результата. По умолчанию 0</param>
/// <param name="Lang">Язык локализации ответа</param>
/// <param name="PaymentLimit">
///   <para>Ограничение на сумму наложенного платежа:</para>
///   <para>-1 - ограничения нет;</para>
///   <para>0 - наложенный платеж не принимается;</para>
/// </param>
public sealed record class CityRequest
(
  [property: JsonPropertyName("country_codes")]     string[]? CountryCodes = default,
  [property: JsonPropertyName("region_code")]            int? RegionCode   = default,
  [property: JsonPropertyName("fias_guid")]             Guid? FiasGuid     = default,
  [property: JsonPropertyName("postal_code")]         string? PostalCode   = default,
  [property: JsonPropertyName("code")]                   int? Code         = default,
  [property: JsonPropertyName("city")]                string? City         = default,
  [property: JsonPropertyName("size")]                   int? Size         = default,
  [property: JsonPropertyName("page")]                   int? Page         = default,
  [property: JsonPropertyName("lang")]               Language Lang         = default,
  [property: JsonPropertyName("payment_limit")] PaymentLimit? PaymentLimit = default
);
