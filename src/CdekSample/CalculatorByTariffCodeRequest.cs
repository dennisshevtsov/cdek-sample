// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using System.Text.Json.Serialization;

namespace CdekSample;

/// <summary>
/// Запрос на расчет по коду тарифа
/// </summary>
public sealed class CalculatorByTariffCodeRequest
(
  CalculatorLocation                     from,
  CalculatorLocation                       to,
  Package[]                          packages,
  Tariff                               tariff,
  AdditionalService[]?               services = default,
  DateTimeOffset                         date = default,
  OrderType                              type = default,
  AdditionalOrderType[]? additionalOrderTypes = default,
  Currency                           currency = default
)
{
  /// <summary>
  ///   <para>Дата и время планируемой передачи заказа</para>
  ///   <para>По умолчанию - текущая</para>
  /// </summary>
  [JsonPropertyName("date")]
  [JsonPropertyOrder(1)]
  [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
  public DateTimeOffset Date { get; } = date;

  /// <summary>
  /// Тип заказа (для проверки доступности тарифа и дополнительных услуг по типу заказа)
  /// </summary>
  [JsonPropertyName("type")]
  [JsonPropertyOrder(2)]
  [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
  public OrderType Type { get; } = type;

  /// <summary>
  /// Дополнительный тип заказа
  /// </summary>
  [JsonPropertyName("additional_order_types")]
  [JsonPropertyOrder(3)]
  [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
  public AdditionalOrderType[]? AdditionalOrderTypes { get; } = additionalOrderTypes;

  /// <summary>
  ///   <para>Валюта, в которой необходимо произвести расчет</para>
  ///   <para>По умолчанию - валюта договора</para>
  /// </summary>
  [JsonPropertyName("currency")]
  [JsonPropertyOrder(4)]
  [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
  public Currency Currency { get; } = currency;

  /// <summary>
  /// Код тарифа
  /// </summary>
  [JsonPropertyName("tariff_code")]
  [JsonPropertyOrder(5)]
  public Tariff Tariff { get; } = tariff;

  /// <summary>
  /// Адрес отправления
  /// </summary>
  [JsonPropertyName("from_location")]
  [JsonPropertyOrder(6)]
  public CalculatorLocation From { get; } = from ?? throw new ArgumentNullException(nameof(from));

  /// <summary>
  /// Адрес получения
  /// </summary>
  [JsonPropertyName("to_location")]
  [JsonPropertyOrder(7)]
  public CalculatorLocation To { get; } = to ?? throw new ArgumentNullException(nameof(to));

  /// <summary>
  /// Дополнительные услуги
  /// </summary>
  [JsonPropertyName("services")]
  [JsonPropertyOrder(8)]
  [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
  public AdditionalService[]? Services { get; } = services;

  /// <summary>
  /// Список информации по местам (упаковкам)
  /// </summary>
  [JsonPropertyName("packages")]
  [JsonPropertyOrder(9)]
  public Package[] Packages { get; } = packages ?? throw new ArgumentNullException(nameof(packages));
}
