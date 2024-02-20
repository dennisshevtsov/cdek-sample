// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using System.Text.Json.Serialization;

namespace CdekSample;

/// <summary>
/// Тип заказа (для проверки доступности тарифа и дополнительных услуг по типу заказа)
/// </summary>
[JsonConverter(typeof(OrderTypeJsonConverter))]
public readonly record struct OrderType
{
  private OrderType(int code) => Code = code;

  private int Code { get; }

  private static OrderType From(int code)
  {
    if (code == OrderType.None       ) return OrderType.None;
    if (code == OrderType.OnlineStore) return OrderType.OnlineStore;
    if (code == OrderType.Delivery   ) return OrderType.Delivery;

    throw new Exception("Invalid code to create OrderType");
  }

  public static implicit operator OrderType(int code)      => OrderType.From(code);
  public static implicit operator int(OrderType orderType) => orderType.Code;

  /// <summary>
  /// Значение по умолчание (невалидное)
  /// </summary>
  public static readonly OrderType None = new(0);

  /// <summary>
  /// Интернет-магазин
  /// </summary>
  public static readonly OrderType OnlineStore = new(1);

  /// <summary>
  /// Доставка
  /// </summary>
  public static readonly OrderType Delivery = new(2);
}
