// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using System.Text.Json.Serialization;

namespace CdekSample;

/// <summary>
/// Запрос на расчет по коду тарифа
/// </summary>
public sealed record class CalculationByTariffRequest
(
  CalculationLocation                    From,
  CalculationLocation                      To,
  Package[]                          Packages,
  TariffCode                               Tariff,
  AdditionalService[]?               Services = null,
  DateTimeOffset?                        Date = null,
  OrderType?                             Type = null,
  AdditionalOrderType[]? AdditionalOrderTypes = null,
  Currency?                          Currency = null
)
{
  /// <summary>
  ///   <para>Дата и время планируемой передачи заказа</para>
  ///   <para>По умолчанию - текущая</para>
  /// </summary>
  [JsonPropertyName("date")]
  [JsonPropertyOrder(1)]
  [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
  public DateTimeOffset? Date { get; } = Date;

  /// <summary>
  /// Тип заказа (для проверки доступности тарифа и дополнительных услуг по типу заказа)
  /// </summary>
  [JsonPropertyName("type")]
  [JsonPropertyOrder(2)]
  [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
  public OrderType? Type { get; } = Type;

  /// <summary>
  /// Дополнительный тип заказа
  /// </summary>
  [JsonPropertyName("additional_order_types")]
  [JsonPropertyOrder(3)]
  [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
  public AdditionalOrderType[]? AdditionalOrderTypes { get; } = AdditionalOrderTypes;

  /// <summary>
  ///   <para>Валюта, в которой необходимо произвести расчет</para>
  ///   <para>По умолчанию - валюта договора</para>
  /// </summary>
  [JsonPropertyName("currency")]
  [JsonPropertyOrder(4)]
  [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
  public Currency? Currency { get; } = Currency;

  /// <summary>
  /// Код тарифа
  /// </summary>
  [JsonPropertyName("tariff_code")]
  [JsonPropertyOrder(5)]
  public TariffCode Tariff { get; } = Tariff;

  /// <summary>
  /// Адрес отправления
  /// </summary>
  [JsonPropertyName("from_location")]
  [JsonPropertyOrder(6)]
  public CalculationLocation From { get; } = From ?? throw new ArgumentNullException(nameof(From));

  /// <summary>
  /// Адрес получения
  /// </summary>
  [JsonPropertyName("to_location")]
  [JsonPropertyOrder(7)]
  public CalculationLocation To { get; } = To ?? throw new ArgumentNullException(nameof(To));

  /// <summary>
  /// Дополнительные услуги
  /// </summary>
  [JsonPropertyName("services")]
  [JsonPropertyOrder(8)]
  [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
  public AdditionalService[]? Services { get; } = Services;

  /// <summary>
  /// Список информации по местам (упаковкам)
  /// </summary>
  [JsonPropertyName("packages")]
  [JsonPropertyOrder(9)]
  public Package[] Packages { get; } = Packages ?? throw new ArgumentNullException(nameof(Packages));
}
