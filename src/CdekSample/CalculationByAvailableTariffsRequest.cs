// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using System.Text.Json.Serialization;

namespace CdekSample;

/// <summary>
/// Запрос на расчет по коду тарифа
/// </summary>
/// <param name="Date">
///   <para>Дата и время планируемой передачи заказа</para>
///   <para>По умолчанию - текущая</para>
/// </param>
/// <param name="Type">
///   <para>Тип заказа (для проверки доступности тарифа и дополнительных услуг по типу заказа):</para>
///   <para>По умолчанию - "интернет-магазин"</para>
/// </param>
/// <param name="AdditionalOrderTypes">
/// Дополнительный тип заказа
/// </param>
/// <param name="Currency">
///   <para>Валюта, в которой необходимо произвести расчет</para>
///   <para>По умолчанию - валюта договора</para>
/// </param>
/// <param name="Language">
///   <para>Язык вывода информации о тарифах</para>
///   <para>По умолчанию - rus</para>
/// </param>
/// <param name="From">Адрес отправления</param>
/// <param name="To">Адрес получения</param>
/// <param name="Packages">Список информации по местам (упаковкам)</param>
public sealed record class CalculationByAvailableTariffsRequest
(
  CalculationLocation                    From,
  CalculationLocation                      To,
  CalculationPackage[]                          Packages,
  DateTimeOffset?                        Date = null,
  OrderType?                             Type = null,
  AdditionalOrderType[]? AdditionalOrderTypes = null,
  Currency?                          Currency = null,
  Language?                          Language = null
)
{
  /// <summary>
  ///   <para>Дата и время планируемой передачи заказа</para>
  ///   <para>По умолчанию - текущая</para>
  /// </summary>
  [JsonPropertyName("date")]
  [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
  public DateTimeOffset? Date { get; } = Date;

  /// <summary>
  /// Тип заказа (для проверки доступности тарифа и дополнительных услуг по типу заказа)
  /// </summary>
  [JsonPropertyName("type")]
  [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
  public OrderType? Type { get; } = Type;

  /// <summary>
  /// Дополнительный тип заказа
  /// </summary>
  [JsonPropertyName("additional_order_types")]
  [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
  public AdditionalOrderType[]? AdditionalOrderTypes { get; } = AdditionalOrderTypes;

  /// <summary>
  ///   <para>Валюта, в которой необходимо произвести расчет</para>
  ///   <para>По умолчанию - валюта договора</para>
  /// </summary>
  [JsonPropertyName("currency")]
  [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
  public Currency? Currency { get; } = Currency;

  /// <summary>
  /// Язык вывода информации о тарифах
  /// </summary>
  [JsonPropertyName("lang")]
  [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
  public Language? Language { get; } = Language;

  /// <summary>
  /// Адрес отправления
  /// </summary>
  [JsonPropertyName("from_location")]
  public CalculationLocation From { get; } = From;

  /// <summary>
  /// Адрес получения
  /// </summary>
  [JsonPropertyName("to_location")]
  public CalculationLocation To { get; } = To;

  /// <summary>
  /// Список информации по местам (упаковкам)
  /// </summary>
  [JsonPropertyName("packages")]
  public CalculationPackage[] Packages { get; } = Packages;
};
