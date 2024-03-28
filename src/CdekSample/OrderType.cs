// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using System.Text.Json.Serialization;

namespace CdekSample;

/// <summary>
/// Тип заказа (для проверки доступности тарифа и дополнительных услуг по типу заказа)
/// </summary>
[JsonConverter(typeof(OrderTypeJsonConverter))]
public readonly struct OrderType
{
  private OrderType(int code) => Code = code;

  private int Code { get; }

  public override string ToString() => Code.ToString();

  private static OrderType From(int code)
  {
    if (code == OrderType.OnlineStore.Code) return OrderType.OnlineStore;
    if (code == OrderType.Delivery.Code   ) return OrderType.Delivery;

    throw new Exception($"Invalid code to create OrderType {code}");
  }

  public static implicit operator OrderType(int code)         => OrderType.From(code);
  public static implicit operator int(OrderType orderType)    => orderType.Code;
  public static implicit operator string(OrderType orderType) => orderType.ToString();

  /// <summary>
  /// Интернет-магазин
  /// </summary>
  public static readonly OrderType OnlineStore = new(code: 1);

  /// <summary>
  /// Доставка
  /// </summary>
  public static readonly OrderType Delivery = new(code: 2);
}
