// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using System.Text.Json.Serialization;

namespace CdekSample;

/// <summary>
/// Дополнительные услуги
/// </summary>
public sealed class AdditionalService
(
  AdditionalServiceCode code,
  string?               parameter,
  float                 sum,
  float                 totalSum,
  float                 discountPercent,
  float                 discountSum,
  float                 vatRate,
  float                 vatSum
)
{
  /// <summary>
  /// Тип дополнительной услуги, код из справочника доп. услуг
  /// </summary>
  [JsonPropertyName("code")]
  [JsonPropertyOrder(1)]
  public AdditionalServiceCode Code { get; } = code;

  /// <summary>
  /// Параметр дополнительной услуги:
  /// <para>1. количество для услуг PACKAGE_1, COURIER_PACKAGE_A2, SECURE_PACKAGE_A2, SECURE_PACKAGE_A3, SECURE_PACKAGE_A4, SECURE_PACKAGE_A5, CARTON_BOX_XS, CARTON_BOX_S, CARTON_BOX_M, CARTON_BOX_L, CARTON_BOX_500GR, CARTON_BOX_1KG, Фото документовCARTON_BOX_2KG, CARTON_BOX_3KG, CARTON_BOX_5KG, CARTON_BOX_10KG, CARTON_BOX_15KG, CARTON_BOX_20KG, CARTON_BOX_30KG, CARTON_FILLER(для всех типов заказа)</para>
  /// <para>2. объявленная стоимость заказа для услуги INSURANCE(для всех типов заказа)</para>
  /// <para>3. длина для услуг BUBBLE_WRAP, WASTE_PAPER</para>
  /// <para>4. количество фотографий для услуги PHOTO_OF_DOCUMENTS</para>
  /// </summary>
  [JsonPropertyName("parameter")]
  [JsonPropertyOrder(0)]
  public string? Parameter { get; } = parameter;

  /// <summary>
  /// Стоимость услуги (в валюте взаиморасчетов)
  /// </summary>
  [JsonPropertyName("sum")]
  [JsonPropertyOrder(1)]
  public float Sum { get; } = sum;

  /// <summary>
  /// общая сумма (итого с НДС и скидкой в валюте взаиморасчётов)
  /// </summary>
  [JsonPropertyName("total_sum")]
  [JsonPropertyOrder(2)]
  public float TotalSum { get; } = totalSum;

  /// <summary>
  /// Процент скидки
  /// </summary>
  [JsonPropertyName("discount_percent")]
  [JsonPropertyOrder(3)]
  public float DiscountPercent { get; } = discountPercent;

  /// <summary>
  /// Общая сумма скидки
  /// </summary>
  [JsonPropertyName("discount_sum")]
  [JsonPropertyOrder(4)]
  public float DiscountSum { get; } = discountSum;

  /// <summary>
  /// Ставка НДС
  /// </summary>
  [JsonPropertyName("vat_rate")]
  [JsonPropertyOrder(5)]
  public float VatRate { get; } = vatRate;

  /// <summary>
  /// сумма НДС
  /// </summary>
  [JsonPropertyName("vat_sum")]
  [JsonPropertyOrder(6)]
  public float VatSum { get; } = vatSum;
}
