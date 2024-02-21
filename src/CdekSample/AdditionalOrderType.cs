﻿// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace CdekSample;

/// <summary>
/// Дополнительный тип заказа
/// </summary>
public readonly record struct AdditionalOrderType
{
  public AdditionalOrderType(): this(code: 0, name: "None") { }

  private AdditionalOrderType(int code, string name) => (Code, Name) = (code, name);

  private int Code { get; }

  /// <summary>
  /// Имя для логгирования
  /// </summary>
  private string Name { get; }

  public override string ToString() => Name;

  private static AdditionalOrderType From(int code)
  {
    if (code == AdditionalOrderType.None         ) return AdditionalOrderType.None;
    if (code == AdditionalOrderType.LessTruckLoad) return AdditionalOrderType.LessTruckLoad;
    if (code == AdditionalOrderType.Forward      ) return AdditionalOrderType.Forward;
    if (code == AdditionalOrderType.FulfilmentIn ) return AdditionalOrderType.FulfilmentIn;
    if (code == AdditionalOrderType.FulfilmentOut) return AdditionalOrderType.FulfilmentOut;

    throw new Exception($"Invalid code to create AdditionalOrderType: {code}");
  }

  public static implicit operator AdditionalOrderType(int code)  => AdditionalOrderType.From(code);
  public static implicit operator int(AdditionalOrderType value) => value.Code;

  /// <summary>
  /// Значение по умолчанию (невалидное)
  /// </summary>
  public static readonly AdditionalOrderType None = new();

  /// <summary>
  /// 2 - для сборного груза (LTL)
  /// </summary>
  public static readonly AdditionalOrderType LessTruckLoad = new(code: 2, name: "LessTruckLoad");

  /// <summary>
  /// 4 - для Forward
  /// </summary>
  public static readonly AdditionalOrderType Forward = new(code: 4, name: "Forward");

  /// <summary>
  /// 6 - для "Фулфилмент. Приход"
  /// </summary>
  public static readonly AdditionalOrderType FulfilmentIn = new(code: 6, name: "FulfilmentIn");

  /// <summary>
  /// для "Фулфилмент. Отгрузка"
  /// </summary>
  public static readonly AdditionalOrderType FulfilmentOut = new(code: 7, name: "FulfilmentOut");
}