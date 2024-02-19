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
///   <para>1 - "интернет-магазин"</para>
///   <para>2 - "доставка" </para>
///   <para>По умолчанию - 1</para>
/// </param>
/// <param name="AdditionalOrderTypes">
///   <para>Дополнительный тип заказа:</para>
///   <para>2 - для сборного груза(LTL)</para>
///   <para>4 - для Forward</para>
///   <para>6 - для "Фулфилмент. Приход"</para>
///   <para>7 - для "Фулфилмент. Отгрузка"</para>
/// </param>
/// <param name="Currency">
///   <para>Валюта, в которой необходимо произвести расчет</para>
///   <para>По умолчанию - валюта договора</para>
/// </param>
/// <param name="Lang">
///   <para>Язык вывода информации о тарифах</para>
///   <para>Возможные значения: rus, eng, zho</para>
///   <para>По умолчанию - rus</para>
/// </param>
/// <param name="FromLocation">Адрес отправления</param>
/// <param name="ToLocation">Адрес получения</param>
/// <param name="Packages">Список информации по местам (упаковкам)</param>
public sealed record class CalculatorByTariffListRequest
(
  DateTimeOffset? Date,
  int? Type,
  int[]? AdditionalOrderTypes,
  Currency? Currency,
  string? Lang,
  CalculatorLocation FromLocation,
  CalculatorLocation ToLocation,
  Package[] Packages
)
{
  /// <summary>
  ///   <para>Дата и время планируемой передачи заказа</para>
  ///   <para>По умолчанию - текущая</para>
  /// </summary>
  [JsonPropertyName("date")]
  public DateTimeOffset? Date { get; } = Date;

  /// <summary>
  ///   <para>Тип заказа (для проверки доступности тарифа и дополнительных услуг по типу заказа):</para>
  ///   <para>1 - "интернет-магазин"</para>
  ///   <para>2 - "доставка" </para>
  ///   <para>По умолчанию - 1</para>
  /// </summary>
  [JsonPropertyName("type")]
  public int? Type { get; } = Type;

  /// <summary>
  ///   <para>Дополнительный тип заказа:</para>
  ///   <para>2 - для сборного груза(LTL)</para>
  ///   <para>4 - для Forward</para>
  ///   <para>6 - для "Фулфилмент. Приход"</para>
  ///   <para>7 - для "Фулфилмент. Отгрузка"</para>
  /// </summary>
  [JsonPropertyName("additional_order_types")]
  public int[]? AdditionalOrderTypes { get; } = AdditionalOrderTypes;

  /// <summary>
  ///   <para>Валюта, в которой необходимо произвести расчет</para>
  ///   <para>По умолчанию - валюта договора</para>
  /// </summary>
  [JsonPropertyName("currency")]
  [JsonConverter(typeof(CurrencyJsonConverter))]
  public Currency? Currency { get; } = Currency;

  /// <summary>
  ///   <para>Язык вывода информации о тарифах</para>
  ///   <para>Возможные значения: rus, eng, zho</para>
  ///   <para>По умолчанию - rus</para>
  /// </summary>
  [JsonPropertyName("lang")]
  public string? Lang { get; } = Lang;

  /// <summary>
  /// Адрес отправления
  /// </summary>
  [JsonPropertyName("from_location")]
  public CalculatorLocation FromLocation { get; } = FromLocation;

  /// <summary>
  /// Адрес получения
  /// </summary>
  [JsonPropertyName("to_location")]
  public CalculatorLocation ToLocation { get; } = ToLocation;

  /// <summary>
  /// Список информации по местам (упаковкам)
  /// </summary>
  [JsonPropertyName("packages")]
  public Package[] Packages { get; } = Packages;
};
