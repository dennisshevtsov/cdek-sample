// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using System.Text.Json.Serialization;

namespace CdekSample;

/// <summary>
///   <para>Адрес получения</para>
///   <para>Идентификация города производится по следующему алгоритму в порядке приоритетности:</para>
///   <para>1. По уникальному коду города СДЭК.Значения передаются в атрибутах from_location.code и to_location.code.</para>
///   <para>2. По почтовому индексу города.Значения передаются в атрибутах from_location.postal_code и to_location.postal_code.В качестве уточняющих параметров могут быть переданы код страны и наименование города.</para>
///   <para>3. По строке адреса.Значения передаются в атрибутах from_location.address и to_location.address.</para>
/// </summary>
/// <param name="Code">Код населенного пункта СДЭК (метод "Список населенных пунктов")</param>
/// <param name="PostalCode">Почтовый индекс</param>
/// <param name="CountryCode">Код страны в формате  ISO_3166-1_alpha-2 (по умолчанию RU)</param>
/// <param name="City">Название города</param>
/// <param name="Address">Полная строка адреса</param>
public sealed record class CalculatorLocation
(
  [property: JsonPropertyName("code")]         int?    Code        = null,
  [property: JsonPropertyName("postal_code")]  string? PostalCode  = null,
  [property: JsonPropertyName("country_code")] string? CountryCode = null,
  [property: JsonPropertyName("city")]         string? City        = null,
  [property: JsonPropertyName("address")]      string? Address     = null
);
